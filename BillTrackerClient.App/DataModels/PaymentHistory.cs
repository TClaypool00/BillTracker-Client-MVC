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
        #endregion

        #region Private fields
        #region Data Models private fields
        private readonly CoreBill _coreBill;
        #endregion
        #endregion

        #region Public properties
        [Key]
        [Column(Order = 0)]
        public int HistoryId { get; set; }

        [Column(Order = 1)]
        public int? BillId { get; set; }
        public virtual Bill Bill { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        [Column(Order = 2)]
        public double Price { get; set; }

        [Column(Order = 3)]
        public DateTime DateDue { get; set; }

        [Column(Order = 4)]
        public DateTime? DatePaid { get; set; }
        #endregion
    }
}
