namespace BillTrackerClient.DataAccess.Models
{
    public partial class Vwcompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
