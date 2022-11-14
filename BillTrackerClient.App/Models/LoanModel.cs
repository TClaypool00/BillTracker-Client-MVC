using BillTrackerClient.App.Models.PartialModels;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class LoanModel : BaseModelClass
    {
        public int LoanId { get; set; }
        [Display(Name = "Loan name")]
        [Required(ErrorMessage = "Loan name is required")]
        [MaxLength(255, ErrorMessage = "Loan name has a max length of 255 characters")]
        public string LoanName { get; set; }
        [Display(Name = "Total amount")]
        [DataType(DataType.Currency)]
        [Range(0.01, int.MaxValue, ErrorMessage = "Loan amount must be at least $0.0.1")]
        public decimal? TotalAmountDue { get; set; }
        [Display(Name = "Remaining amount")]
        [DataType(DataType.Currency)]
        public decimal? RemainingAmount { get; set; }
    }
}
