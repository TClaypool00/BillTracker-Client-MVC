namespace BillTrackerClient.DataAccess.Models
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public string Name { get; set; } = null!;
        public decimal AmountDue { get; set; }
        public bool? IsActive { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
