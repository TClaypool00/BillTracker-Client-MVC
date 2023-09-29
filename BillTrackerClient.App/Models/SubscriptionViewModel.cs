using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

namespace BillTrackerClient.App.Models
{
    public class SubscriptionViewModel : UpdateSubscriptionViewModel
    {
        #region Private fields

        #region Private Model fields
        private readonly CoreSubscription _coreSubscription;
        #endregion
        #endregion

        #region Constructors
        public SubscriptionViewModel()
        {

        }

        public SubscriptionViewModel(CoreSubscription coreSubscription)
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

        public SubscriptionViewModel(CoreSubscription coreSubscription, string message)
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
            Message = message;
        }
        #endregion

        #region Public properties
        public string Message { get; set; }
        #endregion
    }
}
