using System.ComponentModel.DataAnnotations;

namespace BillTrackerClient.App.Models.PostModels.UpdateModels
{
    public class UpdateBillViewModel : PostBillViewModel
    {
        [Range(1, int.MaxValue)]
        public int BillId { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }
}
