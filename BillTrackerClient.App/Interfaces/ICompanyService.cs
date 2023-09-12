using BillTrackerClient.App.CoreModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface ICompanyService
    {
        public Task<List<SelectListItem>> GetCompanyDropDownAsync(int? index = null);

        public Task<CoreCompany> AddCompanyAsync(CoreCompany company);
    }
}
