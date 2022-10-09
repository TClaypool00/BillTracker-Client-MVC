using System;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Vwbill
    {
        public int BillId { get; set; }
        public string BillName { get; set; } = null!;
        public decimal AmountDue { get; set; }
        public bool? IsActive { get; set; }
        public DateOnly DateDue { get; set; }
        public DateOnly? DatePaid { get; set; }
        public bool IsPaid { get; set; }
        public bool IsLate { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
