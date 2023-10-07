using BillTrackerClient.App.CoreModels;
using System.Collections.Generic;

namespace BillTrackerClient.App.Interfaces
{
    public interface IAllService
    {
        public List<CoreMultiExpense> GetAllExpensesAsync(int userId, int? index = null);
    }
}
