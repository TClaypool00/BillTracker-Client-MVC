using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Miscellaneou
    {
        public int MiscellaneousId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateOnly DateAdded { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
