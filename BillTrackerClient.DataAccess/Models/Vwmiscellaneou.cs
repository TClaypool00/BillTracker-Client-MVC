using System;

namespace BillTrackerClient.DataAccess.Models
{
    public partial class Vwmiscellaneou
    {
        public int MiscellaneousId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateOnly DateAdded { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
