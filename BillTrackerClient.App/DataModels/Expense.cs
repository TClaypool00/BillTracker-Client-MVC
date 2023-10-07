using System.ComponentModel.DataAnnotations.Schema;

namespace BillTrackerClient.App.DataModels
{
    [NotMapped]
    public class Expense
    {
        #region Public Properites
        public int Id { get; set; }

        public string Name { get; set; }

        public PaymentHistory PaymentHistory { get; set; }

        public ExpenseType Type { get; set; }
        #endregion

        #region Enums
        public enum ExpenseType
        {
            Bill,
            Loan,
            Subscription
        }
        #endregion
    }
}
