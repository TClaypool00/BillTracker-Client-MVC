using BillTrackerClient.App.CoreModels;
using System;
using System.ComponentModel.DataAnnotations;
using static BillTrackerClient.App.DataModels.Expense;

namespace BillTrackerClient.App.Models
{
    public class ExpenseViewModel
    {
        #region Private fields
        private readonly CoreMultiExpense _coreMultiExpense;
        #endregion

        #region Constructors
        public ExpenseViewModel()
        {

        }

        public ExpenseViewModel(CoreMultiExpense coreMultiExpense)
        {
            _coreMultiExpense = coreMultiExpense ?? throw new ArgumentNullException(nameof(coreMultiExpense));

            Id = _coreMultiExpense.Id;
            Name = _coreMultiExpense.Name;
            DateDue = _coreMultiExpense.DateDueString;
            Price = _coreMultiExpense.PriceString;
            Type = _coreMultiExpense.Type;
        }
        #endregion

        #region Public Properties
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date Due")]
        public string DateDue { get; set; }

        public string Price { get; set; }

        public ExpenseType Type { get; set; }
        #endregion
    }
}
