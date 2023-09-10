using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class CompanyService : ServiceHelper, ICompanyService, IGeneralService
    {
        private readonly BillTrackerContext _context;

        public CompanyService(BillTrackerContext context)
        {
            _context = context;
        }

        public Task<SelectListItem> AddCompanyAsync(AddCompanyModel model, int userId)
        {
            //var dataCompany = Mapper.MapCompany(model, userId);
            //await _context.AddAsync(dataCompany);

            //return Mapper.MapCompany(dataCompany);

            throw new NotImplementedException();
        }

        public Task<bool> CompanyExistsAsync(int id)
        {
            return _context.Companies.AnyAsync(c => c.CompanyId == id);
        }

        public Task<List<CompanyModel>> GetCompaniesAsync(int userId, int? index = null)
        {
            //var companies = await GetDataCompaniesAsync(userId, index);
            //var companyModels = new List<CompanyModel>();

            //for (int i = 0; i < companies.Count; i++)
            //{
            //    companyModels.Add(Mapper.MapCompanyModel(companies[i]));
            //}

            //return companyModels;

            throw new NotImplementedException();
        }

        public Task<List<SelectListItem>> GetCompanyItemsAsync(int userId, int? index = null)
        {
            //List<Company> companies;
            //var companyItems = new List<CompanyItem>();

            //companies = await GetDataCompaniesAsync(userId, index);

            //companyItems.Add(new CompanyItem
            //{
            //    CompanyId = 0,
            //    CompanyName = DefaultValue
            //});

            //for (int i = 0; i < companies.Count; i++)
            //{
            //    companyItems.Add(Mapper.MapCompany(companies[i]));
            //}

            //return companyItems;

            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task<CompanyModel> UpdateCompanyAsync(int id, CompanyModel model)
        {
            //var oldCompany = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            //var newCompany = Mapper.MapCompany(model);

            //_context.Entry(oldCompany).CurrentValues.SetValues(oldCompany);

            //await SaveAsync();

            //return model;

            throw new NotImplementedException();

        }

        private async Task<List<Company>> GetDataCompaniesAsync(int userId, int? index = null)
        {
            if (await _context.Companies.Where(c => c.UserId == userId).CountAsync() > 10)
            {
                return await _context.Companies.Where(_c => _c.UserId == userId)
                    .Take(10)
                    .Skip((int)index * 10)
                    .ToListAsync();
            }
            else
            {
                return await _context.Companies.Where(c => c.UserId == userId).ToListAsync();
            }
        }
    }
}
