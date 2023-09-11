using BillTrackerClient.App.CoreModels;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface IUserService
    {
        #region public methods
        public Task<bool> CreateUserAsync(CoreUser user);

        public Task<bool> UserExistsByEmailAsync(string email, int? userId = null);

        public Task<bool> UserExistsByPhoneNumberAsync(string phoneNumber, int? userId = null);

        public Task<CoreUser> GetUserAsync(string email);
        #endregion

        #region public properties
        public string UserCreatedMessage { get; }

        public string EmailExistsMessage { get; }

        public string PhoneNumberExistsMessage { get; }

        public string EmailDoesNotExistMessage { get; }

        public string PhoneNumberDoesNotExistMessage { get; }
        #endregion

    }
}
