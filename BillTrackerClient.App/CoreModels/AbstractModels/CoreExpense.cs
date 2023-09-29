using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Models.PostModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

namespace BillTrackerClient.App.CoreModels.AbstractModels
{
    public abstract class CoreExpense
    {
        #region Constructors
        protected CoreExpense()
        {

        }

        #region Bills
        public CoreExpense(UpdateBillViewModel updateBillViewModel, int userId)
        {
            _updateBillViewModel = updateBillViewModel ?? throw new ArgumentNullException(nameof(updateBillViewModel));

            DateDue = _updateBillViewModel.DateDue;
            Price = (double)_updateBillViewModel.Price;
            _userId = userId;
            IsActive = _updateBillViewModel.IsActive;
            CompanyId = _updateBillViewModel.CompanyId;
        }

        public CoreExpense(PostBillViewModel postBillViewModel, int userId)
        {
            _postBillViewModel = postBillViewModel ?? throw new ArgumentNullException(nameof(postBillViewModel));
            DateDue = _postBillViewModel.DateDue;
            Price = (double)_postBillViewModel.Price;
            _userId = userId;
            CompanyId = _postBillViewModel.CompanyId;
            IsActive = true;
        }

        protected CoreExpense(Bill bill)
        {
            _bill = bill ?? throw new ArgumentNullException(nameof(bill));

            if (_bill.PaymentHistory is not null)
            {

            }
        }
        #endregion Subscriptions

        #region Subscriptions
        protected CoreExpense(PostSubscriptionViewModel postSubscriptionViewModel, int userId)
        {
            _postSubscriptionViewModel = postSubscriptionViewModel;

            DateDue = _postSubscriptionViewModel.DateDue;
            Price = (double)_postSubscriptionViewModel.Price;
            _userId = userId;
            CompanyId = _postSubscriptionViewModel.CompanyId;
        }

        protected CoreExpense(UpdateSubscriptionViewModel updateSubscriptionViewModel, int userId)
        {
            _updateSubscriptionViewModel = updateSubscriptionViewModel;
            DateDue = _updateSubscriptionViewModel.DateDue;
            Price = (double)_updateSubscriptionViewModel.Price;
            _userId = userId;
            CompanyId= _updateSubscriptionViewModel.CompanyId;

            Company = new CoreCompany(CompanyId, _updateSubscriptionViewModel.CompanyText);
        }

        public CoreExpense(Subscription subscription)
        {
            _subscription = subscription;

            _isActive = _subscription.IsActive;

            if (_subscription.PaymentHistory is not null)
            {
                _dateDue = _subscription.PaymentHistory.DateDue;
                _datePaid = _subscription.PaymentHistory.DatePaid;
                _price = _subscription.PaymentHistory.Price;
            }

            if (_subscription.Company is not null)
            {
                Company = new CoreCompany(_subscription.Company);
            }
        }
        #endregion
        #endregion

        #region Private Fields
        private DateTime _dateDue;
        private DateTime? _datePaid;
        private bool _isPaid;
        private bool _isLate;
        private double _price;
        private int _userId;
        private bool _isActive;

        #region Models private fields
        #region Bills
        private readonly Bill _bill;
        private readonly PostBillViewModel _postBillViewModel;
        private readonly UpdateBillViewModel _updateBillViewModel;
        #endregion
        #region Subscriptions
        private readonly PostSubscriptionViewModel _postSubscriptionViewModel;
        private readonly Subscription _subscription;
        private readonly UpdateSubscriptionViewModel _updateSubscriptionViewModel;
        #endregion
        #endregion
        #endregion

        #region Protected message fields
        protected string _idCannotBeZero = "Id cannot be less than 0";
        #endregion

        #region Public Properties
        public DateTime DateDue
        {
            get
            {
                return _dateDue;
            }
            set
            {
                _dateDue = value;
            }
        }

        public DateTime? DatePaid
        {
            get
            {
                return _datePaid;
            }
            set
            {
                _datePaid = value;
            }
        }

        public string DateDueString
        {
            get
            {
                return $"{_dateDue:yyyy}-{_dateDue:MM}-{_dateDue:dd}";
            }
        }

        public string DatePaidString
        {
            get
            {
                if (_datePaid.HasValue)
                {
                    return _datePaid.Value.ToString("D");
                }
                else
                {
                    return "Not paid";
                }
            }
        }

        public bool IsPaid
        {
            get
            {
                return _isPaid;
            }
            set
            {
                _isPaid = value;
            }
        }

        public bool IsLate
        {
            get
            {
                if (_datePaid is not null)
                {
                    return _datePaid > _dateDue;
                }
                else
                {
                    return DateTime.Now > _dateDue;
                }
            }
            set
            {
                _isLate = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public string PriceString
        {
            get
            {
                return _price.ToString("C");
            }
        }

        public DateTime DateCreated { get; set; }

        public string DateCreatedString
        {
            get
            {
                return DateCreated.ToString("D");
            }
        }

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public CoreUser User { get; set; }

        public CoreCompany Company { get; set; }

        public int CompanyId { get; set; }
    }
    #endregion
}