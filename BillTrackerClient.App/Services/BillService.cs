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

        public async Task<int> AddBillAsync(BillModel model)
        {
            var bill = Mapper.MapBill(model);
            bill.IsActive = true;

            await _context.Bills.AddAsync(bill);
            await _context.Paymenthistories.AddAsync(MapHistory(bill.BillId, model.DateDue));
            await SaveAsync();

            return bill.BillId;

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

        public Task<BillModel> UpdateBillAsync(BillModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserHasBillAsync(int billId, int userId)
        {
            return _context.Bills.AnyAsync(b => b.BillId == billId && b.Company.UserId == userId);
        }

        private static Paymenthistory MapHistory(int expenseId, DateOnly date)
        {
            return new Paymenthistory
            {
                ExpenseId = expenseId,
                DateDue = date
            };
        }
    }
}
