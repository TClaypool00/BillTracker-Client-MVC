using BillTrackerClient.App.CoreModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface IUserRoleService
    {
        public Task<List<CoreRole>> GetRoleNamesByUserIdAsync(int userId);
    }
}
