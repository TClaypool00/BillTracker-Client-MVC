using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class BillService : ServiceHelper, IBillService
    {
        public BillService(BillTrackerContext context) : base(context)
        {
        }

        public string BillUPdatedMessage => "Bill has been updated!";

        public Task<bool> BillNameExistsAsync(string name, int userId, int? id = null)
        {
            if (id is null)
            {
                return _context.Bills.AnyAsync(b => b.BillName == name && b.UserId == userId);
            }
            else
            {
                return _context.Bills.AnyAsync(b => b.BillName == name && b.UserId == userId && b.BillId != id);
            }
        }

        public async Task CreateBillAsync(CoreBill coreBill)
        {
           var dataBill = new Bill(coreBill);

            try
            {
                await _context.Bills.AddAsync(dataBill);
                await SaveAsync();

                if (dataBill.BillId == 0)
                {
                    throw new ApplicationException("Could not add bill");
                }

                coreBill.BillId = dataBill.BillId;
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                var dataHistory = new PaymentHistory(coreBill);
                await _context.PaymentHistories.AddAsync(dataHistory);
                await SaveAsync();
            }
            catch (Exception)
            {
                _context.Bills.Remove(dataBill);
                await SaveAsync();

                throw;
            }
        }

        public async Task<List<CoreBill>> GetAllBillsAsync(int userId, int? index = null, string search = null)
        {
            List<Bill> bills;
            var coreBills = new List<CoreBill>();

            ConfigureIndex(index);

            if (search is null)
            {
                bills = await _context.Bills
                    .Where(u => u.UserId == userId)
                    .Take(10)
                    .Skip(_index)
                    .OrderBy(u => u.BillId)
                    .Select(b => new Bill
                    {
                        BillId = b.BillId,
                        BillName = b.BillName,
                        DateCreated = b.DateCreated,
                        IsActive = b.IsActive,
                        Company = new Company
                        {
                            CompanyName = b.Company.CompanyName
                        },
                        PaymentHistory = b.PaymentHistories.FirstOrDefault(d => d.DateDue.Month == DateTime.Now.Month && d.DateDue.Year == DateTime.Now.Year)
                    })
                    .ToListAsync();
            }
            else
            {
                bills = await _context.Bills
                    .Where(u => u.UserId == userId && u.BillName.Contains(search))
                    .Take(10)
                    .Skip(_index)
                    .OrderBy(u => u.BillId)
                    .Select(b => new Bill
                    {
                        BillId = b.BillId,
                        BillName = b.BillName,
                        DateCreated = b.DateCreated,
                        IsActive = b.IsActive,
                        Company = new Company
                        {
                            CompanyName = b.Company.CompanyName
                        },
                        PaymentHistory = b.PaymentHistories.FirstOrDefault(d => d.DateDue.Month == DateTime.Now.Month && d.DateDue.Year == DateTime.Now.Year)
                    })
                    .ToListAsync();
            }

            if (bills.Count > 0)
            {
                for (int i = 0; i < bills.Count; i++)
                {
                    coreBills.Add(new CoreBill(bills[i]));
                }
            }

            return coreBills;
        }

        public async Task UpdateBillAsync(CoreBill coreBill)
        {
            try
            {
                var oldBill = await _context.Bills.FirstOrDefaultAsync(b => b.BillId == coreBill.BillId);
                oldBill.IsActive = coreBill.IsActive;
                oldBill.BillName = coreBill.BillName;
                oldBill.CompanyId = coreBill.CompanyId;

                
                _context.Bills.Update(oldBill);

                await SaveAsync();

                var payHistory = await _context.PaymentHistories.FirstOrDefaultAsync(d => d.DateDue.Month == DateTime.Now.Month && d.DateDue.Year == DateTime.Now.Year && d.BillId == coreBill.BillId);
                payHistory.Price = coreBill.Price;
                payHistory.DateDue = coreBill.DateDue;

                _context.PaymentHistories.Update(payHistory);
                await SaveAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
