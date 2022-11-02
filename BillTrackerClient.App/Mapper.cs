using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models;

namespace BillTrackerClient.App
{
    public class Mapper
    {
        public static User MapUser(RegisterModel model, int? id = null, bool includePassword = false)
        {
            var dataUser = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = includePassword ? model.Password : "",
                PhoneNumber = model.PhoneNum,
                IsAdmin = model.IsAdmin,
            };

            if (id != null)
            {
                dataUser.UserId = model.UserId;
            }

            return dataUser;
        }

        public static User MapUser(UserModel model, bool includePassword = false)
        {
            return new User
            {
                UserId = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = includePassword ? model.Password : "",
                PhoneNumber = model.PhoneNum,
                IsAdmin = model.IsAdmin
            };
        }

        public static UserModel MapUser(User user, bool includePassword = false)
        {
            return new UserModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = includePassword ? user.Password : "",
                PhoneNum = user.PhoneNumber,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
