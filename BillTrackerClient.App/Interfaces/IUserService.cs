using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetUsersAsync(int index);
        public Task<UserModel> GetUserByEmailAsync(string email);
        public Task<UserModel> GetUserByIdAsync(int id);
        public Task<UserModel> UpdateUserAsync(int id, UserModel model);
        public Task<bool> UserExistsByIdAsync(int id);
        public Task<bool> EmailExistsAsync(string email);
        public Task<bool> PhoneNumberExistsAsync(string phoneNumber);
        public Task AddUserAsync(RegisterModel model);
        public Task RemoveUserAsync(int id);
    }
}
