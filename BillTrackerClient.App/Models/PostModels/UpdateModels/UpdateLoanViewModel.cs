using BillTrackerClient.App.CustomAnnotations;

namespace BillTrackerClient.App.Models.PostModels.UpdateModels
{
    public class UpdateLoanViewModel : PostLoanViewModel
    {
        [NumberMustBeGreaterThanZero]
        public int LoanId { get; set; }
    }
}
