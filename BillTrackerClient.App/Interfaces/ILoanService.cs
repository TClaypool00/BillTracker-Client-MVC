using BillTrackerClient.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface ILoanService
    {
        public Task<List<LoanModel>> GetLoansAsync(int userId, int? index = null);
        public Task<LoanModel> GetLoanAsync(int loanId);
        public Task<bool> UserHasLoanAsync(int loanId, int userId);
        public Task<bool> AddLoanAsync(LoanModel loan);
        public Task<bool> LoanExistsAsync(int loanId);
        public Task<bool> UpdateLoanAsync(LoanModel loan);
    }
}
