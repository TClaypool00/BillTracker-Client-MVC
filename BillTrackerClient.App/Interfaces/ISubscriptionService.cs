using BillTrackerClient.App.CoreModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface ISubscriptionService
    {
        #region Public methods
        public Task AddSubscriptionAsync(CoreSubscription coreSubscription);

        public Task<bool> SubscriptionExistsAsync(string subscriptionName, int userId, int? id = null);

        public Task<bool> UserOwnsSubscriptionAsync(int id, int userId);

        public Task UpdateSubscriptionAsync(CoreSubscription coreSubscription);

        public Task ToggleSubscriptionIsActive(int id, bool isActive);

        public Task<List<CoreSubscription>> GetSubscriptionsAsync(int userId, int? index = null, string search = null);

        public string SubscriptionAlreadyExistsMessage(string subscriptionName);

        public string SubscriptionToggleMessage(bool isActive);
        #endregion

        #region Public message properties
        public string SubscriptionCreatedOKMessage { get; }

        public string SubscriptionUpdatedOKMessage { get; }
        #endregion
    }
}
