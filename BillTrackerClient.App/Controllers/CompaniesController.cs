using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    [Authorize]
    public class CompaniesController : ControllerHelper
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetCompanyDropDown([FromQuery]string search, int? index = null)
        {
            var companyDropDown = await _companyService.GetCompanyDropDownAsync(search, index);

            if (companyDropDown.Count > 0)
            {
                return Ok(companyDropDown);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddCompany([FromBody] PostCompanyViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return NoContent();
                }

                var coreComment = new CoreCompany(model, UserId);

                await _companyService.AddCompanyAsync(coreComment);

                return Ok(_companyService.CompanyAddedOKMessage);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
