using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class BillViewModel : UpdateBillViewModel
    {
        #region Private fields

        #region Private Model fields
        private readonly CoreBill _coreBill;
        #endregion
        #endregion

        #region Constructors
        public BillViewModel()
        {

        }

        public BillViewModel(CoreBill coreBill)
        {
            _coreBill = coreBill ?? throw new ArgumentNullException(nameof(coreBill));

            BillId = _coreBill.BillId;
            BillName = _coreBill.BillName;
            DateCreated = _coreBill.DateCreatedString;
            IsActive = _coreBill.IsActive;
            PriceString = _coreBill.PriceString;
            DateDue = _coreBill.DateDue;
            Company = _coreBill.Company.CompanyName;
            DatePaid = _coreBill.DatePaidString;
            DateDueString = _coreBill.DateDueString;
        }
        #endregion

        #region Public Property
        [Display(Name = "Date Created")]
        public string DateCreated { get; set; }

        [Display(Name = "Price")]
        public string PriceString { get; set; }

        public string Company { get; set; }

        [Display(Name = "Date paid")]
        public string DatePaid { get; set; }

        [Display(Name = "Date Due")]
        public string DateDueString { get; set; }
        #endregion
    }
}
