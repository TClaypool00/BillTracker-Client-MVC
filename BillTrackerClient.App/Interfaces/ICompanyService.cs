using BillTrackerClient.App.Models;
using BillTrackerClient.App.Models.PostModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Interfaces
{
    public interface ICompanyService
    {
        public Task<List<CompanyItem>> GetCompanyItemsAsync(int userId, int? index = null);
        public Task<List<CompanyModel>> GetCompaniesAsync(int userId, int? index = null);
        public Task<CompanyItem> AddCompanyAsync(AddCompanyModel model, int userId);
        public Task<CompanyModel> UpdateCompanyAsync(int id, CompanyModel model);
        public Task<bool> CompanyExistsAsync(int id);
    }
}
