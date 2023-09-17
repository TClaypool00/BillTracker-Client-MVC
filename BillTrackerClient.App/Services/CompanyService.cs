using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.CoreModels.PartialCoreModels;
using BillTrackerClient.App.DataModels;
using BillTrackerClient.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Services
{
    public class CompanyService : ServiceHelper, ICompanyService
    {
        #region Constructors
        public CompanyService(BillTrackerContext context) : base(context)
        {
        }
        #endregion

        #region Public Properites
        public string CompanyAddedOKMessage => "Company has been added";
        #endregion

        #region Public methods
        public async Task AddCompanyAsync(CoreCompany company)
        {
            try
            {
                var dataCompany = new Company(company);
                await _context.Companies.AddAsync(dataCompany);
                await SaveAsync();

                if (dataCompany.CompanyId == 0)
                {
                    throw new ApplicationException("Could not add company");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<PartialCoreCompany>> GetCompanyDropDownAsync(string search, int? index = null)
        {
            var companySelectList = new List<PartialCoreCompany>();

            ConfigureIndex(index);

            var companies = await _context.Companies
                .Where(a => a.CompanyName.Contains(search))
                .Take(20)
                .Skip(_index)
                .Select(c => new Company
                {
                    CompanyId = c.CompanyId,
                    CompanyName = c.CompanyName
                })
                .ToListAsync();

            if (companies.Count > 0)
            {
                Company company;
                for (int i = 0; i < companies.Count; i++)
                {
                    company = companies[i];

                    companySelectList.Add(new PartialCoreCompany
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName
                    });
                }
            }

            return companySelectList;
        }

        public int GetCompanyIdByNameAsync(string name)
        {
            return _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == name).Result.CompanyId;
        }

        public Task<bool> CompanyNameExistsAsync(string name)
        {
            return _context.Companies.AnyAsync(x => x.CompanyName == name);
        }
        #region Message functions
        public string CompanyNameExistsMessage(string name)
        {
            return $"A company with the name {name} already exists";
        }

        public string CompanyNameNotFoundMessage(string name)
        {
            return $"A company with the name {name} was not found";
        }
        #endregion
        #endregion
    }
}
