using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.CoreModels.PartialCoreModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface ICompanyService
    {
        #region Public methods
        public Task<List<PartialCoreCompany>> GetCompanyDropDownAsync(string search, int? index = null);

        public Task AddCompanyAsync(CoreCompany company);

        public Task<bool> CompanyNameExistsAsync(string name);

        public int GetCompanyIdByNameAsync(string name);

        #region Message functions
        public string CompanyNameNotFoundMessage(string name);

        public string CompanyNameExistsMessage(string name);
        #endregion
        #endregion

        #region Public properties
        public string CompanyAddedOKMessage { get; }
        #endregion
    }
}
