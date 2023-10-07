using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BillTrackerClient.App.Services
{
    public class AllService : ServiceHelper, IAllService
    {
        public AllService(BillTrackerContext context, IConfiguration configuration) : base(context, configuration, "Expense")
        {

        }

        public List<CoreMultiExpense> GetAllExpensesAsync(int userId, int? index = null)
        {
            ConfigureIndex(index);

            var expenses = new List<CoreMultiExpense>();

            var query = _context.Bills
                .Where(u => u.UserId == userId)
                .Skip(_index)
                .Take(_smallTakeValue)
                .Select(x => new Expense
                {
                    Id = x.BillId,
                    Name = x.BillName,
                    Type = Expense.ExpenseType.Bill,
                    PaymentHistory = x.PaymentHistories.FirstOrDefault(p => p.DateDue.Month == DateTime.Now.Month && p.DateDue.Year == DateTime.Now.Year && p.BillId == x.BillId)
                })
                .AsEnumerable()
                .Union(_context.Loans
                .Where(u => u.UserId == userId)
                .Skip(_index)
                .Take(_smallTakeValue)
                .Select(x => new Expense
                {
                    Id = x.LoanId,
                    Name = x.LoanName,
                    Type = Expense.ExpenseType.Loan,
                    PaymentHistory = x.PaymentHistories.FirstOrDefault(p => p.DateDue.Month == DateTime.Now.Month && p.DateDue.Year == DateTime.Now.Year && p.BillId == x.LoanId)
                }))
                .AsEnumerable()
                .Union(_context.Subscriptions
                .Where(u => u.UserId == userId)
                .Skip(_index)
                .Take(_smallTakeValue)
                .Select(x => new Expense
                {
                    Id = x.SubscriptionId,
                    Name = x.SubscriptionName,
                    Type = Expense.ExpenseType.Subscription,
                    PaymentHistory = x.PaymentHistories.FirstOrDefault(p => p.DateDue.Month == DateTime.Now.Month && p.DateDue.Year == DateTime.Now.Year && p.BillId == x.SubscriptionId)
                }))
                .ToList();

            for (int i = 0; i < query.Count(); i++)
            {
                expenses.Add(new CoreMultiExpense(query.ElementAt(i)));
            }

            return expenses;
        }
    }
}
