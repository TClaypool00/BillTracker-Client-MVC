﻿using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Paymenthistory
    {
        public int PaymentId { get; set; }
        public int ExpenseId { get; set; }
        public int TypeId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime? DatePaid { get; set; }
        public bool IsLate { get; set; }

        public virtual Type Type { get; set; }
    }
}
