using BillTrackerClient.App.Models.PostModels.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class PostBillViewModel : PostBaseExpenseViewModel
    {
        [Required(ErrorMessage = "Bill name is required")]
        [MaxLength(255, ErrorMessage = "Bill name is has max length of 255")]
        [Display(Name = "Bill name")]
        public string BillName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price is requried")]
        public override double? Price { get => base.Price; set => base.Price = value; }
    }
}
