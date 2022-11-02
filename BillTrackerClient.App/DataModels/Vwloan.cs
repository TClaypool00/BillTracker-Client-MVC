using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwloan
    {
        public int LoanId { get; set; }
        public string LoanName { get; set; }
        public bool? IsActive { get; set; }
        public decimal MonthlyAmountDue { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal RemainingAmount { get; set; }
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
