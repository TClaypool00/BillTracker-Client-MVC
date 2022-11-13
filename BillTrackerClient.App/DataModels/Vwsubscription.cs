using System;
using System.Collections.Generic;

namespace BillTrackerClient.App.DataModels
{
    public partial class Vwsubscription
    {
        public int SubscriptionId { get; set; }
        public string Name { get; set; }
        public decimal AmountDue { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime? DatePaid { get; set; }
        public bool IsPaid { get; set; }
        public bool IsLate { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
