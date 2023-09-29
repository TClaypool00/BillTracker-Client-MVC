using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using System;

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


    }
}
