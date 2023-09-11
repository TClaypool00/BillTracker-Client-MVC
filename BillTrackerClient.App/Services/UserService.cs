using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class UserService : ServiceHelper, IUserService
    {
        public UserService(BillTrackerContext context) : base(context)
        {
        }

        public string UserCreatedMessage => "Accounted has been created";

        public string EmailExistsMessage => "Account with the the email address entered has already been created.";

        public string PhoneNumberExistsMessage => "Account with the the phone number entered has already been created.";

        public string EmailDoesNotExistMessage => "Account with the email address entered does not exist.";

        public string PhoneNumberDoesNotExistMessage => "Account with the phone number entered does not exist.";

        public async Task<bool> CreateUserAsync(CoreUser user)
        {
            var dataUser = new User(user);

            try
            {
                await _context.Users.AddAsync(dataUser);
                await SaveAsync();

                try
                {
                    var dataUserRole = new UserRole(dataUser.UserId);
                    await _context.UserRoles.AddAsync(dataUserRole);
                    await SaveAsync();

                    return true;
                }
                catch (Exception)
                {
                    _context.Users.Remove(dataUser);
                    await SaveAsync();

                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CoreUser> GetUserAsync(string email)
        {
            var dataUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return new CoreUser(dataUser);
        }

        public Task<bool> UserExistsByEmailAsync(string email, int? userId = null)
        {
            if (userId is null)
            {
                return _context.Users.AnyAsync(u => u.Email == email);
            }
            else
            {
                return _context.Users.AnyAsync(u => u.Email == email && u.UserId != userId);
            }
        }

        public Task<bool> UserExistsByPhoneNumberAsync(string phoneNumber, int? userId = null)
        {
            if (userId is null)
            {
                return _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
            }
            else
            {
                return _context.Users.AnyAsync(u => u.PhoneNumber == phoneNumber && u.UserId != userId);
            }
        }
    }
}
