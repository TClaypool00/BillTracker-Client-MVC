using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

namespace BillTrackerClient.App.Models
{
    public class LoanViewModel : UpdateLoanViewModel
    {
        #region Private fields

        #region Private Model fields
        private CoreLoan _coreLoan;
        #endregion
        #endregion

        #region Constructors
        public LoanViewModel()
        {

        }

        public LoanViewModel(CoreLoan coreLoan)
        {
            Construct(coreLoan);
        }

        public LoanViewModel(CoreLoan coreLoan, string message)
        {
            Construct(coreLoan);

            Message = message;
        }
        #endregion

        #region private methods
        private void Construct(CoreLoan coreLoan)
        {
            _coreLoan = coreLoan ?? throw new ArgumentNullException(nameof(coreLoan));

            LoanId = _coreLoan.LoanId;
            LoanName = _coreLoan.LoanName;
            DateCreated = _coreLoan.DateCreatedString;
            IsActive = _coreLoan.IsActive;
            PriceString = _coreLoan.PriceString;
            DateDue = _coreLoan.DateDue;
            Company = _coreLoan.Company.CompanyName;
            DatePaid = _coreLoan.DatePaidString;
            DateDueString = _coreLoan.DateDueString;
        }
        #endregion
    }
}
