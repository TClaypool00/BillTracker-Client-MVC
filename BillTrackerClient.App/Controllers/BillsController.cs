using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    [Authorize]
    public class BillsController : ControllerHelper
    {
        private readonly IBillService _billService;
        private readonly ICompanyService _companyService;

        public BillsController(IBillService billService, ICompanyService companyService)
        {
            _billService = billService;
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostBillViewModel
            {
                DateDue = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PostBillViewModel billModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrorMessages());
                }

                if (await _billService.BillNameExistsAsync(billModel.BillName, UserId))
                {
                    return BadRequest($"A bill with the name {billModel.BillName} aready exist");
                }

                var coreBill = new CoreBill(billModel, UserId)
                {
                    CompanyId = _companyService.GetCompanyIdByNameAsync(billModel.CompanyText)
                };

                await _billService.CreateBillAsync(coreBill);


                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("Bill has been created");
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }
    }
}
