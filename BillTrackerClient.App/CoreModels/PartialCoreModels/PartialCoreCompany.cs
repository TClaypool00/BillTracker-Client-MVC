namespace BillTrackerClient.App.CoreModels.PartialCoreModels
{
    public class PartialCoreCompany
    {
        public PartialCoreCompany()
        {
                
        }

        public PartialCoreCompany(int companyId, string companyName)
        {
            CompanyId = companyId;
            CompanyName = companyName;
        }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
