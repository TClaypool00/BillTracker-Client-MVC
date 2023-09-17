using BillTrackerClient.App.DataModels;
using System;

namespace BillTrackerClient.App.CoreModels.AbstractModels
{
    public abstract class CoreExpense
    {
        #region Constructors
        protected CoreExpense()
        {

        }

        protected CoreExpense(Bill bill)
        {
            _bill = bill ?? throw new ArgumentNullException(nameof(bill));

            if (_bill.PaymentHistory is not null)
            {

            }
        }
        #endregion

        #region Private Fields
        private DateTime _dateDue;
        private DateTime? _datePaid;
        private bool _isPaid;
        private bool _isLate;

        #region Data Models private fields
        private readonly Bill _bill;
        #endregion
        #endregion

        #region Public Properties
        protected DateTime DateDue
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

        protected DateTime? DatePaid
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

        protected string DateDueString
        {
            get
            {
                return _dateDue.ToString("F");
            }
        }

        protected string DatePaidString
        {
            get
            {
                if (_datePaid.HasValue)
                {
                    return _datePaid.Value.ToString("F");
                }
                else
                {
                    return "";
                }
            }
        }

        protected bool IsPaid
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

        protected bool IsLate
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
    }
    #endregion
}
