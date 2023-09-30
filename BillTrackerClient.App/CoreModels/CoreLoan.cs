using BillTrackerClient.App.CoreModels.AbstractModels;
using BillTrackerClient.App.DataModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreLoan : CoreExpense
    {
        #region Private fields
        #region Model fields
        private readonly Loan _loan;
        #endregion
        #endregion

        #region Constructors
        public CoreLoan(Loan loan)
        {
            _loan = loan ?? throw new Exception(nameof(loan));

            if (_loan.LoanId > 0)
            {
                LoanId = _loan.LoanId;
            }

            LoanName = _loan.LoanName;
        }
        #endregion

        #region Public properties
        public int LoanId { get; set; }

        public string LoanName { get; set; }
        #endregion
    }
}
