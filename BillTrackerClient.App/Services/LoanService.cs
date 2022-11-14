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
    public class LoanService : ILoanService, IGeneralService
    {
        private readonly BillTrackerContext _context;

        public LoanService(BillTrackerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLoanAsync(LoanModel loan)
        {
            var dataLoan = Mapper.MapLoan(loan);

            try
            {
                await _context.Loans.AddAsync(dataLoan);
                await SaveAsync();
                try
                {
                    await _context.Paymenthistories.AddAsync(Mapper.MapHistory(dataLoan.LoanId, loan.DateDue, 2));
                    await SaveAsync();
                }
                catch(Exception)
                {
                    _context.Loans.Remove(dataLoan);
                    await SaveAsync();

                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<LoanModel> GetLoanAsync(int loanId)
        {
            return Mapper.MapLoan(await _context.Vwloans.FirstOrDefaultAsync(l => l.LoanId == loanId));
        }

        public async Task<List<LoanModel>> GetLoansAsync(int userId, int? index = null)
        {
            List<Vwloan> loans;
            var loanModels = new List<LoanModel>();


            if (await _context.Vwloans.CountAsync() <= 10)
            {
                loans = await _context.Vwloans.Where(l => l.UserId == userId).ToListAsync();
            } else
            {
                loans = await _context.Vwloans.Where(l => l.UserId == userId)
                    .Take(10)
                    .Skip((int)index * 10)
                    .ToListAsync();
            }

            for (int i = 0; i < loans.Count; i++)
            {
                loanModels.Add(Mapper.MapLoan(loans[i]));
            }

            return loanModels;
        }

        public Task<bool> LoanExistsAsync(int loanId)
        {
            return _context.Loans.AnyAsync(l => l.LoanId == loanId);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateLoanAsync(LoanModel loan)
        {
            var newloan = Mapper.MapLoan(loan);
            var oldLoan = await _context.Loans.FirstOrDefaultAsync(l => l.LoanId == loan.LoanId);
            Paymenthistory oldHistory;
            Paymenthistory newHistory;

            try
            {
                _context.Entry(oldLoan).CurrentValues.SetValues(newloan);
                await SaveAsync();

                try
                {
                    oldHistory = await _context.Paymenthistories.FirstOrDefaultAsync(h => h.ExpenseId == loan.LoanId && h.TypeId == 2 && h.DateDue.Month == DateTime.Now.Month && h.DateDue.Year == DateTime.Now.Year);
                    newHistory = Mapper.MapHistory(loan.LoanId, loan.DateDue, 2, oldHistory.PaymentId, oldHistory.IsLate, oldHistory.IsPaid);

                    _context.Entry(oldHistory).CurrentValues.SetValues(newHistory);
                    await SaveAsync();
                }
                catch (Exception)
                {
                    _context.Entry(newloan).CurrentValues.SetValues(oldLoan);
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

        public Task<bool> UserHasLoanAsync(int loanId, int userId)
        {
            return _context.Vwloans.AnyAsync(l => l.LoanId == loanId && l.UserId == userId);
        }
    }
}
