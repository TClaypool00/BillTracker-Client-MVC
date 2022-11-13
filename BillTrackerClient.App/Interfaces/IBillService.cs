using BillTrackerClient.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface IBillService
    {
        public Task<List<BillModel>> GetBillsAsync(int userId);
        public Task<BillModel> GetBillByIdAsync(int billId);
        public Task<bool> AddBillAsync(BillModel model);
        public Task<bool> UpdateBillAsync(BillModel model);
        public Task<bool> BillExistsAsync(int billId);
        public Task<bool> UserHasBillAsync(int billId, int userId);
    }
}
