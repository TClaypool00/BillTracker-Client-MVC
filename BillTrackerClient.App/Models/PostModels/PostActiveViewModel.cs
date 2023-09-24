using BillTrackerClient.App.CustomAnnotations;

namespace BillTrackerClient.App.Models.PostModels
{
    public class PostActiveViewModel
    {
        [NumberMustBeGreaterThanZero]
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }
}
