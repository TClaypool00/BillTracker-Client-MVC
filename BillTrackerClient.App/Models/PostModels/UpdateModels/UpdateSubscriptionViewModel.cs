using BillTrackerClient.App.CustomAnnotations;

namespace BillTrackerClient.App.Models.PostModels.UpdateModels
{
    public class UpdateSubscriptionViewModel : PostSubscriptionViewModel
    {
        [NumberMustBeGreaterThanZero]
        public int SubscriptionId { get; set; }

    }
}
