using BillTrackerClient.App.Models.PostModels.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class PostLoanViewModel : PostBaseExpenseViewModel
    {
        [Required(ErrorMessage = "Loan name is required")]
        [MaxLength(255, ErrorMessage = "Loan name has a max length of 255")]
        [Display(Name = "Loan name")]
        public string LoanName { get; set; }

        [Display(Name = "Monthly amount")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Monthly amount is requried")]
        public override double? Price { get => base.Price; set => base.Price = value; }

        [Display(Name = "Total amount due")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Total amount due is requried")]
        public double? TotalAmountOwed { get; set; }
    }
}
