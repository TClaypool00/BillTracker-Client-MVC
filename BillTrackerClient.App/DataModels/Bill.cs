using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public string BillName { get; set; }
        public decimal AmountDue { get; set; }
        public bool? IsActive { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
