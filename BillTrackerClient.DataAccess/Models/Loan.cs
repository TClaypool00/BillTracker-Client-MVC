namespace BillTrackerClient.DataAccess.Models
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public string LoanName { get; set; } = null!;
        public bool? IsActive { get; set; }
        public decimal MonthlyAmountDue { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal RemainingAmount { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
    }
}
