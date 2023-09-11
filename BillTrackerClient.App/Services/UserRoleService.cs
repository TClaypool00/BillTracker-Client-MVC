using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class UserRoleService : ServiceHelper, IUserRoleService
    {
        public UserRoleService(BillTrackerContext context) : base(context)
        {
        }

        public async Task<List<CoreRole>> GetRoleNamesByUserIdAsync(int userId)
        {
            var coreRoles = new List<CoreRole>();
            var dataUserRoles = await _context.UserRoles
                .Where(u => u.UserId == userId)
                .Select(r => new UserRole
                {
                    Role = new Role
                    {
                        RoleId = r.Role.RoleId,
                        RoleName = r.Role.RoleName,
                    }
                }).ToListAsync();

            if (dataUserRoles.Count > 0)
            {
                Role role;
                for (int i = 0; i < dataUserRoles.Count; i++)
                {
                    role = dataUserRoles[i].Role;

                    coreRoles.Add(new CoreRole(role));
                }
            }

            return coreRoles;
        }
    }
}
