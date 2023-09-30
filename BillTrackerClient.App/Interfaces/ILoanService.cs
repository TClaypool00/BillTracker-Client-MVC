using BillTrackerClient.App.CoreModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface ILoanService
    {
        #region Public methods
        public Task AddLoanAsync(CoreLoan coreLoan);

        public Task<bool> LoanExistsAsync(string loanName, int userId, int? id = null);

        public Task<bool> UserOwnsLoanAsync(int id, int? userId = null);

        public Task UpdateLoanAsync(CoreLoan coreLoan);

        public Task ToggleLoanIsActive(int id, bool isActive);

        public Task<List<CoreLoan>> GetAllLoansAsync(int userId, int? index = null, string search = null);

        public string LoanAlreadyExistsMessage(string loanName);

        public string LoanToggleMessage(bool isActive);
        #endregion

        #region public message Properties
        public string LoanCreatedOKMessage { get; }

        public string LoanUpdatedOKMessage { get; }
        #endregion
    }
}
