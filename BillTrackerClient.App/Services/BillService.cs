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
    }
}
