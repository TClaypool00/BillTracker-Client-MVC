using BillTrackerClient.App.CoreModels.AbstractModels;
using BillTrackerClient.App.Models.PostModels;
using System;

namespace BillTrackerClient.App.CoreModels
{
    public class CoreSubscription : CoreExpense
    {
        #region Private fields
        #region Private model fields
        private readonly PostSubscriptionViewModel _postSubscriptionViewModel;
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
        #endregion

        #region Public properties
        public int SubscriptionId { get; set; }

        public string SubscriptionName { get; set; }
        #endregion
    }
}
