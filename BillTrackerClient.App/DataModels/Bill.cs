using BillTrackerClient.App.CoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTrackerClient.App.DataModels
{
    public class Bill
    {
        #region Constructors
        public Bill()
        {

        }

        public Bill(CoreBill coreBill)
        {
            _coreBill = coreBill ?? throw new ArgumentNullException(nameof(coreBill));

            if (_coreBill.BillId > 0)
            {
                BillId = _coreBill.BillId;
            }

            BillName = _coreBill.BillName;
            UserId = _coreBill.UserId;
        }
        #endregion

        #region Private fields
        #region Models private fields
        private readonly CoreBill _coreBill;
        #endregion
        #endregion

        #region Public properties
        [Key]
        public int BillId { get; set; }

        [Required]
        [MaxLength(255)]
        public string BillName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [NotMapped]
        public PaymentHistory PaymentHistory { get; set; }

        public List<PaymentHistory> PaymentHistories { get; set; }
        #endregion
    }
}
