using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwbill
    {
        public int BillId { get; set; }
        public string BillName { get; set; }
        public decimal AmountDue { get; set; }
        public bool? IsActive { get; set; }
        public DateOnly DateDue { get; set; }
        public DateOnly? DatePaid { get; set; }
        public bool IsPaid { get; set; }
        public bool IsLate { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
