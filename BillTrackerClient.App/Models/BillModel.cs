using BillTrackerClient.App.Models.PartialModels;
using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models
{
    public class BillModel : BaseModelClass
    {
        public int BillId { get; set; }
        [MaxLength(255, ErrorMessage = "Bill  name has max length of 255 characters")]
        [Required(ErrorMessage = "Bill name is required")]
        public string BillName { get; set; }
    }
}
