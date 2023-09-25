using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class SubscriptionService : ServiceHelper, ISubscriptionService
    {

        public SubscriptionService(BillTrackerContext context) : base(context, "Subscription")
        {
        }

        public string SubscriptionCreatedOKMessage => "Subscription has been added!";

        public async Task AddSubscriptionAsync(CoreSubscription coreSubscription)
        {
            var dataSubscription = new Subscription(coreSubscription);

            try
            {
                await _context.Subscriptions.AddAsync(dataSubscription);
                await SaveAsync();

                if (dataSubscription.SubscriptionId == 0)
                {
                    throw new ApplicationException(CouldNotAddMessage(_modelString));
                }

                coreSubscription.SubscriptionId = dataSubscription.SubscriptionId;

                try
                {
                    var dataHistory = new PaymentHistory(coreSubscription);
                    await _context.PaymentHistories.AddAsync(dataHistory);
                    await SaveAsync();
                }
                catch (Exception)
                {
                    _context.Subscriptions.Remove(dataSubscription);
                    await SaveAsync();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SubscriptionAlreadyExistsMessage(string subscriptionName)
        {
            return ModelAlreadyExistsMessage(_modelString, subscriptionName);
        }

        public Task<bool> SubscriptionExistsAsync(string subscriptionName, int userId, int? id = null)
        {
            if (id is null)
            {
                return _context.Subscriptions.AnyAsync(s => s.SubscriptionName == subscriptionName && s.UserId == userId);
            }
            else
            {
                return _context.Subscriptions.AnyAsync(s => s.SubscriptionName == subscriptionName && s.UserId == userId && s.SubscriptionId != id);
            }
        }
    }
}
