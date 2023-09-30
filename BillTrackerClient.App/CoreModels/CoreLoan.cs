using BillTrackerClient.App.CoreModels.AbstractModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models.PostModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreLoan : CoreExpense
    {
        #region Constructors
        public CoreLoan()
        {

        }

        public CoreLoan(PostLoanViewModel postLoanViewModel, int userId) : base(postLoanViewModel, userId)
        {
            LoanName = _postLoanViewModel.LoanName;
            TotalAmountOwed = (double)_postLoanViewModel.TotalAmountOwed;
        }

        public CoreLoan(UpdateLoanViewModel updateLoanViewModel, int userId) : base(updateLoanViewModel, userId)
        {
            if (_updateLoanViewModel.LoanId > 0)
            {
                LoanId = _updateLoanViewModel.LoanId;
            }
            else
            {
                throw new ApplicationException(_idCannotBeZero);
            }

            LoanName = _updateLoanViewModel.LoanName;
        }

        public CoreLoan(Loan loan) : base(loan)
        {
            if (_loan.LoanId > 0)
            {
                LoanId = _loan.LoanId;
            }

            LoanName = _loan.LoanName;
            TotalAmountOwed = _loan.TotalAmountOwed;
        }
        #endregion

        #region Public properties
        public int LoanId { get; set; }

        public string LoanName { get; set; }

        public double TotalAmountOwed { get; set; }
        #endregion
    }
}
