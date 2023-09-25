using BillTrackerClient.App.CoreModels;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface ISubscriptionService
    {
        #region Public methods
        public Task AddSubscriptionAsync(CoreSubscription coreSubscription);

        public Task<bool> SubscriptionExistsAsync(string subscriptionName, int userId, int? id = null);

        public string SubscriptionAlreadyExistsMessage(string subscriptionName);
        #endregion

        #region Public message properties
        public string SubscriptionCreatedOKMessage { get; }
        #endregion
    }
}
