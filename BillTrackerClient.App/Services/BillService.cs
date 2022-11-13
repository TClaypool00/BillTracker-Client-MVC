using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class BillService : IBillService, IGeneralService
    {
        private readonly BillTrackerContext _context;

        public BillService(BillTrackerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBillAsync(BillModel model)
        {
            try
            {
                var bill = Mapper.MapBill(model);
                bill.IsActive = true;

                await _context.Bills.AddAsync(bill);
                await SaveAsync();
                try
                {
                    await _context.Paymenthistories.AddAsync(Mapper.MapHistory(bill.BillId, model.DateDue, 1));
                    await SaveAsync();
                } catch (Exception)
                {
                    _context.Bills.Remove(bill);
                    await SaveAsync();
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> BillExistsAsync(int billId)
        {
            return _context.Bills.AnyAsync(a => a.BillId == billId);
        }

        public async Task<BillModel> GetBillByIdAsync(int billId)
        {
            return Mapper.MapBill(await _context.Vwbills.FirstOrDefaultAsync(b => b.BillId == billId)); 
        }

        public async Task<List<BillModel>> GetBillsAsync(int userId)
        {
            var dataBills = await _context.Vwbills.Where(b => b.UserId == userId).ToListAsync();
            var bills = new List<BillModel>();
            Vwbill bill;

            for (int i = 0; i < dataBills.Count; i++)
            {
                bill = dataBills[i];
                bills.Add(Mapper.MapBill(bill));
            }

            return bills;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBillAsync(BillModel model)
        {
            var oldBill = await _context.Bills.FirstOrDefaultAsync(b => b.BillId == model.BillId);
            var newBill = Mapper.MapBill(model);            

            try
            {
                _context.Entry(oldBill).CurrentValues.SetValues(newBill);
                await SaveAsync();
                try
                {
                    var oldHistory = await _context.Paymenthistories.FirstOrDefaultAsync(h => h.ExpenseId == model.BillId && h.ExpenseId == 1 && h.DateDue.Month == DateTime.Now.Month && h.DateDue.Year == DateTime.Now.Year);

                    if (oldHistory.DateDue != model.DateDue)
                    {
                        var newHistory = Mapper.MapHistory(model.BillId, model.DateDue, 1, oldHistory.PaymentId, oldHistory.IsLate, oldHistory.IsPaid);

                        _context.Entry(oldHistory).CurrentValues.SetValues(newHistory);
                        await SaveAsync();
                    }
                } catch (Exception)
                {
                    _context.Entry(newBill).CurrentValues.SetValues(oldBill);
                    return false;
                }
            } catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Task<bool> UserHasBillAsync(int billId, int userId)
        {
            return _context.Bills.AnyAsync(b => b.BillId == billId && b.Company.UserId == userId);
        }
    }
}
