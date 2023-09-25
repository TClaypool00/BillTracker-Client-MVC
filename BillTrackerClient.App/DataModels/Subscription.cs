using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using BillTrackerClient.App.CoreModels;

namespace BillTrackerClient.App.DataModels
{
    public class Subscription
    {
        #region Private fields
        #region Private model fields
        private readonly CoreSubscription _coreSubscription;
        #endregion
        #endregion

        #region Constructions
        public Subscription()
        {

        }

        public Subscription(CoreSubscription coreSubscription)
        {
            _coreSubscription = coreSubscription ?? throw new ArgumentNullException(nameof(coreSubscription));

            if (_coreSubscription.SubscriptionId > 0)
            {
                SubscriptionId = _coreSubscription.SubscriptionId;
            }

            SubscriptionName = _coreSubscription.SubscriptionName;
            IsActive = true;
            UserId = _coreSubscription.UserId;
            CompanyId = _coreSubscription.CompanyId;
        }
        #endregion

        #region Public properties
        [Key]
        public int SubscriptionId { get; set; }

        [Required]
        [MaxLength(255)]
        public string SubscriptionName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [NotMapped]
        public PaymentHistory PaymentHistory { get; set; }

        public List<PaymentHistory> PaymentHistories { get; set; }
        #endregion
    }
}
