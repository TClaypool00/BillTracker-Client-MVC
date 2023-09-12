using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class CompanyService : ServiceHelper, ICompanyService
    {
        public CompanyService(BillTrackerContext context) : base(context)
        {
        }

        public async Task<CoreCompany> AddCompanyAsync(CoreCompany company)
        {
            var dataCompany = new Company(company);
            await _context.Companies.AddAsync(dataCompany);
            await SaveAsync();

            company.CompanyId = dataCompany.CompanyId;

            return company;
        }

        public Task<List<SelectListItem>> GetCompanyDropDownAsync(int? index = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
