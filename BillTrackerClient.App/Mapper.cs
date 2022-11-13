using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models;
using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel;

namespace BillTrackerClient.App
{
    public class Mapper
    {
        public static Bill MapBill(BillModel model)
        {
            var dataBill = new Bill
            {
                BillName = model.BillName,
                AmountDue = (decimal)model.AmountDue,
                CompanyId = model.CompanyId
            };

            if (model.BillId != 0)
            {
                dataBill.BillId = model.BillId;
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

        public static SelectListItem MapCompany(Company company)
        {
            return new SelectListItem
            {
                Text = company.CompanyName,
                Value = company.CompanyId.ToString(),
                Selected = true
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

        public static Paymenthistory MapHistory(int expenseId, DateOnly date, int typeId, int paymentId = 0, bool? isLate = null, bool? isPaid = null)
        {
            var history = new Paymenthistory
            {
                ExpenseId = expenseId,
                DateDue = date,
                TypeId = typeId
            };

            if (paymentId != 0)
            {
                history.PaymentId = paymentId;
            }

            if (isLate is not null)
            {
                history.IsLate = (bool)isLate;
            }

            if (isPaid is not null)
            {
                history.IsPaid = (bool)isPaid;
            }

            return history;
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
