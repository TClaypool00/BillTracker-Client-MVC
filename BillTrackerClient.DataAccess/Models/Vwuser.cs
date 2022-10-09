namespace BillTrackerClient.DataAccess.Models
{
    public partial class Vwuser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public int ProfileId { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal Budget { get; set; }
        public decimal Savings { get; set; }
    }
}
