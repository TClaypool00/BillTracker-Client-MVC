using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface IBillService
    {
        #region Public methods
        public Task<bool> BillNameExistsAsync(string name, int userId);

        public Task CreateBillAsync();
        #endregion
    }
}
