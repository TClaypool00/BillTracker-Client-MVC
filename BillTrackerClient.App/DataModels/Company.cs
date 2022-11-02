using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Company
    {
        public Company()
        {
            Bills = new HashSet<Bill>();
            Loans = new HashSet<Loan>();
            Miscellaneous = new HashSet<Miscellaneou>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Miscellaneou> Miscellaneous { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
