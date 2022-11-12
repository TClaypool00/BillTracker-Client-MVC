using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models;
using BillTrackerClient.App.Models.PostModels;

namespace BillTrackerClient.App
{
    public class Mapper
    {
        public static Bill MapBill(BillModel model, int id = 0)
        {
            var dataBill = new Bill
            {
                BillName = model.BillName,
                AmountDue = model.AmountDue,
                CompanyId = model.CompanyId
            };

            if (id != 0)
            {
                dataBill.BillId = id;
            }

            return dataBill;
        }

        public static BillModel MapBill(Vwbill bill)
        {
            return new BillModel
            {
                BillId = bill.BillId,
                BillName = bill.BillName,
                AmountDue = bill.AmountDue,
                IsActive = (bool)bill.IsActive,
                CompanyId = bill.CompanyId,
                DateDue = bill.DateDue,
                FirstName = bill.FirstName,
                LastName = bill.LastName,
                IsLate = bill.IsLate,
                IsPaid = bill.IsPaid,
                UserId = bill.UserId
            };
        }

        public static Company MapCompany(AddCompanyModel model, int userId)
        {
            return new Company
            {
                CompanyName = model.CompanyName,
                UserId = userId
            };
        }

        public static CompanyItem MapCompany(Company company)
        {
            return new CompanyItem
            {
                CompanyName = company.CompanyName,
                CompanyId = company.CompanyId
            };
        }

        public static CompanyModel MapCompanyModel(Company company)
        {
            return new CompanyModel
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                IsActive = (bool)company.IsActive
            };
        }

        public static Company MapCompany(CompanyModel company)
        {
            return new Company
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                IsActive = (bool)company.IsActive
            };
        }

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
