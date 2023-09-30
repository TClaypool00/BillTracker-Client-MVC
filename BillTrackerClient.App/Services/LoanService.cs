using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class LoanService : ServiceHelper, ILoanService
    {
        #region Constructors
        public LoanService(BillTrackerContext context, IConfiguration configuration) : base(context, configuration, "Loan")
        {

        }

        public string LoanCreatedOKMessage => "Loan has been added!";

        public string LoanUpdatedOKMessage => "Loan has been updated!";

        public async Task AddLoanAsync(CoreLoan coreLoan)
        {
            var loan = new Loan(coreLoan);

            try
            {
                await _context.Loans.AddAsync(loan);
                await SaveAsync();

                if (loan.LoanId == 0)
                {
                    throw new ApplicationException(CouldNotAddMessage());
                }

                coreLoan.LoanId = loan.LoanId;

                try
                {
                    var payHistory = new PaymentHistory(coreLoan);

                    await _context.PaymentHistories.AddAsync(payHistory);
                    await SaveAsync();
                }
                catch (Exception)
                {
                    _context.Entry(loan).State = EntityState.Deleted;
                    await SaveAsync();

                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CoreLoan>> GetAllLoansAsync(int userId, int? index = null, string search = null)
        {
            var coreLoans = new List<CoreLoan>();
            List<Loan> loans;

            ConfigureIndex(index);

            if (search is null)
            {
                loans = await _context.Loans
                    .Where(u => u.UserId == userId)
                    .Take(_standardTakeValue)
                    .Skip(_index)
                    .Select(l => new Loan
                    {
                        LoanId = l.LoanId,
                        LoanName = l.LoanName,
                        TotalAmountOwed = l.TotalAmountOwed,
                        IsActive = l.IsActive,
                        Company = new Company
                        {
                            CompanyName = l.Company.CompanyName
                        },
                        PaymentHistory = l.PaymentHistories.FirstOrDefault(d => d.DateDue.Month == DateTime.Now.Month && d.DateDue.Year == DateTime.Now.Year)
                    })
                    .ToListAsync();
            }
            else
            {
                loans = await _context.Loans
                    .Where(u => u.UserId == userId && u.LoanName.Contains(search))
                    .Take(_standardTakeValue)
                    .Skip(_index)
                    .Select(l => new Loan
                    {
                        LoanId = l.LoanId,
                        LoanName = l.LoanName,
                        TotalAmountOwed = l.TotalAmountOwed,
                        IsActive = l.IsActive,
                        Company = new Company
                        {
                            CompanyName = l.Company.CompanyName
                        },
                        PaymentHistory = l.PaymentHistories.FirstOrDefault(d => d.DateDue.Month == DateTime.Now.Month && d.DateDue.Year == DateTime.Now.Year)
                    })
                    .ToListAsync();
            }

            if (loans.Count > 0)
            {
                for (int i = 0; i < loans.Count; i++)
                {
                    coreLoans.Add(new CoreLoan(loans[i]));
                }
            }

            return coreLoans;
        }

        public string LoanAlreadyExistsMessage(string loanName)
        {
            return ModelAlreadyExistsMessage(loanName);
        }

        public Task<bool> LoanExistsAsync(string loanName, int userId, int? id = null)
        {
            if (id is null)
            {
                return _context.Loans.AnyAsync(l => l.LoanName == loanName && l.UserId == userId);
            }
            else
            {
                return _context.Loans.AnyAsync(l => l.LoanName == loanName && l.UserId == userId && l.LoanId == id);
            }
        }

        public string LoanToggleMessage(bool isActive)
        {
            return ToggleIsActiveMssage(isActive);
        }

        public async Task ToggleLoanIsActive(int id, bool isActive)
        {
            var loan = await FindLoanAsync(id);

            try
            {
                loan.IsActive = isActive;
                _context.Loans.Update(loan);
                await SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Detach(loan);
            }
        }

        public async Task UpdateLoanAsync(CoreLoan coreLoan)
        {
            var loan = await FindLoanAsync(coreLoan.LoanId);
            var payHistory = await _context.PaymentHistories.FirstOrDefaultAsync(p => p.SubscriptionId == coreLoan.LoanId && p.DateDue.Month == DateTime.Now.Month && p.DateDue.Year == DateTime.Now.Year);

            try
            {
                loan.LoanName = coreLoan.LoanName;
                loan.IsActive = coreLoan.IsActive;
                loan.TotalAmountOwed = coreLoan.TotalAmountOwed;
                loan.CompanyId = coreLoan.CompanyId;

                _context.Loans.Update(loan);

                payHistory.Price = coreLoan.Price;
                payHistory.DateDue = coreLoan.DateDue;

                _context.PaymentHistories.Update(payHistory);

                await SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> UserOwnsLoanAsync(int id, int? userId = null)
        {
            if (userId is null)
            {
                return _context.Loans.AnyAsync(l => l.LoanId == id);
            }
            else
            {
                return _context.Loans.AnyAsync(l => l.LoanId == id && l.UserId == userId);
            }
        }
        #endregion

        #region Private methods
        private Task<Loan> FindLoanAsync(int id)
        {
            return _context.Loans.FirstOrDefaultAsync(l => l.LoanId == id);
        }
        #endregion
    }
}
