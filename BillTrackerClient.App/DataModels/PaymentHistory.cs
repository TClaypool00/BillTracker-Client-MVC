using BillTrackerClient.App.CoreModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTrackerClient.App.DataModels
{
    public class PaymentHistory
    {
        #region
        public PaymentHistory()
        {

        }

        public PaymentHistory(CoreBill coreBill)
        {
            _coreBill = coreBill ?? throw new ArgumentNullException(nameof(coreBill));


            DateDue = _coreBill.DateDue;
            Price = _coreBill.Price;
            DateDue = _coreBill.DateDue;
            DatePaid = _coreBill.DatePaid;
            BillId = _coreBill.BillId;

        }

        public PaymentHistory(CoreSubscription coreSubscription)
        {
            _coreSubscription = coreSubscription ?? throw new ArgumentNullException(nameof(coreSubscription));

            DateDue = _coreSubscription.DateDue;
            Price = _coreSubscription.Price;
            DatePaid = _coreSubscription.DatePaid;
            SubscriptionId = _coreSubscription.SubscriptionId;
        }
        #endregion

        #region Private fields
        #region Data Models private fields
        private readonly CoreBill _coreBill;
        private readonly CoreSubscription _coreSubscription;
        #endregion
        #endregion

        #region Public properties
        [Key]
        [Column(Order = 0)]
        public int HistoryId { get; set; }

        [Column(Order = 1)]
        public int? BillId { get; set; }
        public virtual Bill Bill { get; set; }

        [Column(Order = 2)]
        public int? SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }

        [Column(Order = 3)]
        public int? LoanId { get; set; }
        public virtual Loan Loan { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        [Column(Order = 4)]
        public double Price { get; set; }

        [Column(Order = 5)]
        public DateTime DateDue { get; set; }

        [Column(Order = 6)]
        public DateTime? DatePaid { get; set; }
        #endregion
    }
}
