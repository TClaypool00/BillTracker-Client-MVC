using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwmiscellaneou
    {
        public int MiscellaneousId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DateAdded { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
