using BillTrackerClient.App.CoreModels.AbstractModels;
using BillTrackerClient.App.DataModels;
using System.Collections.Generic;
using static BillTrackerClient.App.DataModels.Expense;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreMultiExpense : CoreExpense
    {
        #region Constructors
        public CoreMultiExpense()
        {
            
        }

        public CoreMultiExpense(Expense expense) : base(expense)
        {
            Id = expense.Id;
            Name = expense.Name;
            Type = expense.Type;
        }
        #endregion

        #region Public properties
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ExpenseType Type { get; set; }
        #endregion
    }
}
