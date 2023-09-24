using BillTrackerClient.App.CoreModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface IBillService
    {
        #region Public methods
        public Task<bool> BillNameExistsAsync(string name, int userId, int? id = null);

        public Task CreateBillAsync(CoreBill coreBill);

        public Task UpdateBillAsync(CoreBill coreBill);

        public Task ActiveBillAsync(int id, bool isActive);

        public Task<List<CoreBill>> GetAllBillsAsync(int userId, int? index = null, string search = null);
        #endregion

        #region Public messages
        public string BillCreatedMessage { get; }

        public string BillUPdatedMessage { get; }
        #endregion
    }
}
