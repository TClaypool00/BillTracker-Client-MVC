using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

namespace BillTrackerClient.App.Models
{
    public class SubscriptionViewModel : UpdateSubscriptionViewModel
    {
        #region Private fields

        #region Private Model fields
        private CoreSubscription _coreSubscription;
        #endregion
        #endregion

        #region Constructors
        public SubscriptionViewModel()
        {

        }

        public SubscriptionViewModel(CoreSubscription coreSubscription)
        {
            Construct(coreSubscription);
        }

        public SubscriptionViewModel(CoreSubscription coreSubscription, string message)
        {
            Construct(coreSubscription);

            Message = message;
        }
        #endregion

        #region Private methods
        private void Construct(CoreSubscription coreSubscription)
        {
            _coreSubscription = coreSubscription ?? throw new ArgumentNullException(nameof(coreSubscription));

            SubscriptionId = _coreSubscription.SubscriptionId;
            SubscriptionName = _coreSubscription.SubscriptionName;
            DateCreated = _coreSubscription.DateCreatedString;
            IsActive = _coreSubscription.IsActive;
            PriceString = _coreSubscription.PriceString;
            DateDue = _coreSubscription.DateDue;
            Company = _coreSubscription.Company.CompanyName;
            DatePaid = _coreSubscription.DatePaidString;
            DateDueString = _coreSubscription.DateDueString;
        }
        #endregion
    }
}
