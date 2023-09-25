using BillTrackerClient.App.Models.PostModels.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class PostSubscriptionViewModel : PostBaseExpenseViewModel
    {
        [Required(ErrorMessage = "Subscription name is required")]
        [MaxLength(255, ErrorMessage = "Subscription name has a max length of 255")]
        [Display(Name = "Subscription name")]
        public string SubscriptionName { get; set; }

        [Display(Name = "Monthly amount")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Monthly amount is requried")]
        public override double? Price { get => base.Price; set => base.Price = value; }
    }
}
