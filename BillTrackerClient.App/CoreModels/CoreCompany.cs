namespace BillTrackerClient.App.CoreModels
{
    public class CoreCompany
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int UserId { get; set; }
        public CoreUser User { get; set; }
    }
}
