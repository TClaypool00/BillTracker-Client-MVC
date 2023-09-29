using BillTrackerClient.App.CoreModels.AbstractModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models.PostModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreSubscription : CoreExpense
    {
        #region Private fields
        #region Private model fields
        private readonly PostSubscriptionViewModel _postSubscriptionViewModel;
        private readonly UpdateSubscriptionViewModel _updateSubscriptionViewModel;
        private readonly Subscription _subscription;
        #endregion
        #endregion

        #region Constructors
        public CoreSubscription()
        {

        }

        public CoreSubscription(PostSubscriptionViewModel postSubscriptionViewModel, int userId) : base(postSubscriptionViewModel, userId)
        {
            _postSubscriptionViewModel = postSubscriptionViewModel ?? throw new ArgumentNullException(nameof(postSubscriptionViewModel));

            SubscriptionName = _postSubscriptionViewModel.SubscriptionName;

        }

        public CoreSubscription(UpdateSubscriptionViewModel updateSubscriptionViewModel, int userId) : base(updateSubscriptionViewModel, userId)
        {
            _updateSubscriptionViewModel = updateSubscriptionViewModel ?? throw new ArgumentNullException(nameof(updateSubscriptionViewModel));

            if (_updateSubscriptionViewModel.SubscriptionId > 0)
            {
                SubscriptionId = _updateSubscriptionViewModel.SubscriptionId;
            } else
            {
                throw new ArgumentException(_idCannotBeZero);
            }

            SubscriptionName = _updateSubscriptionViewModel.SubscriptionName;
            IsActive = _updateSubscriptionViewModel.IsActive;
        }

        public CoreSubscription(Subscription subscription) : base(subscription)
        {
            _subscription = subscription ?? throw new ArgumentNullException(nameof(subscription));

            if (_subscription.SubscriptionId > 0)
            {
                SubscriptionId = _subscription.SubscriptionId;
            }

            SubscriptionName = _subscription.SubscriptionName;
        }
        #endregion

        #region Public properties
        public int SubscriptionId { get; set; }

        public string SubscriptionName { get; set; }
        #endregion
    }
}
