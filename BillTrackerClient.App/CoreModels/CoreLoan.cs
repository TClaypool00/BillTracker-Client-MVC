using BillTrackerClient.App.CoreModels.AbstractModels;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreLoan : CoreExpense
    {
        #region Constructors
        public CoreLoan()
        {

        }
        #endregion

        #region Public properties
        public int LoanId { get; set; }

        public string LoanName { get; set; }
        #endregion
    }
}
