using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class SubscriptionService : ServiceHelper, ISubscriptionService
    {

        public SubscriptionService(BillTrackerContext context, IConfiguration configuration) : base(context, configuration, "Subscription")
        {
        }

        public string SubscriptionCreatedOKMessage => "Subscription has been added!";

        public string SubscriptionUpdatedOKMessage => "Subscription has been updated!";

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

        public async Task<List<CoreSubscription>> GetSubscriptionsAsync(int userId, int? index = null, string search = null)
        {
            var coreSubscrptions = new List<CoreSubscription>();
            List<Subscription> subscriptions;

            ConfigureIndex(index);

            if (search is null)
            {
                subscriptions = await _context.Subscriptions
                    .Where(u => u.UserId == userId)
                    .Take(_standardTakeValue)
                    .Skip(_index)
                    .Select(s => new Subscription
                    {
                        SubscriptionId = s.SubscriptionId,
                        SubscriptionName = s.SubscriptionName,
                        IsActive = s.IsActive,
                        Company = new Company
                        {
                            CompanyName = s.Company.CompanyName
                        },
                        PaymentHistory = s.PaymentHistories.FirstOrDefault(d => d.DateDue.Month == DateTime.Now.Month && d.DateDue.Year == DateTime.Now.Year)
                    })
                    .ToListAsync();
            }
            else
            {
                subscriptions = await _context.Subscriptions
                    .Where(u => u.UserId == userId && u.SubscriptionName.Contains(search))
                    .Take(_standardTakeValue)
                    .Skip(_index)
                    .Select(s => new Subscription
                    {
                        SubscriptionId = s.SubscriptionId,
                        SubscriptionName = s.SubscriptionName,
                        IsActive = s.IsActive,
                        Company = new Company
                        {
                            CompanyName = s.Company.CompanyName
                        },
                        PaymentHistory = s.PaymentHistories.FirstOrDefault(d => d.DateDue.Month == DateTime.Now.Month && d.DateDue.Year == DateTime.Now.Year)
                    })
                    .ToListAsync();
            }


            if (subscriptions.Count > 0)
            {
                for (int i = 0; i < subscriptions.Count; i++)
                {
                    coreSubscrptions.Add(new CoreSubscription(subscriptions[i]));
                }
            }

            return coreSubscrptions;

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

        public string SubscriptionToggleMessage(bool isActive)
        {
            return ToggleIsActiveMssage(isActive);
        }

        public async Task ToggleSubscriptionIsActive(int id, bool isActive)
        {
            var subscription = await FindSubscription(id);

            try
            {
                subscription.IsActive = isActive;

                _context.Subscriptions.Update(subscription);

                await SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Detach(subscription);
            }
        }

        public async Task UpdateSubscriptionAsync(CoreSubscription coreSubscription)
        {
            var dataSubscription = await FindSubscription(coreSubscription.SubscriptionId);
            var payHistory = await _context.PaymentHistories.FirstOrDefaultAsync(p => p.SubscriptionId == coreSubscription.SubscriptionId);

            try
            {
                dataSubscription.SubscriptionName = coreSubscription.SubscriptionName;
                dataSubscription.CompanyId = coreSubscription.CompanyId;
                dataSubscription.IsActive = coreSubscription.IsActive;

                _context.Subscriptions.Update(dataSubscription);
                
                payHistory.Price = coreSubscription.Price;
                payHistory.DateDue = coreSubscription.DateDue;

                _context.PaymentHistories.Update(payHistory);

                await SaveAsync();


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Detach(dataSubscription);
                Detach(payHistory);
            }
        }

        public Task<bool> UserOwnsSubscriptionAsync(int id, int userId)
        {
            return _context.Subscriptions.AnyAsync(s => s.SubscriptionId == id && s.UserId == userId);
        }

        private Task<Subscription> FindSubscription(int id)
        {
            return _context.Subscriptions.FirstOrDefaultAsync(s => s.SubscriptionId == id);
        }
    }
}
