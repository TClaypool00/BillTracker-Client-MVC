using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public string LoanName { get; set; }
        public bool? IsActive { get; set; }
        public decimal MonthlyAmountDue { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal RemainingAmount { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
