using BillTrackerClient.App.Helpers;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    public class BillsController : ControllerHelper
    {
        private readonly IBillService _service;
        private readonly ICompanyService _companyService;

        public BillsController(IBillService service, ICompanyService companyService)
        {
            _service = service;
            _companyService = companyService;
        }

        [HttpGet]
        [Authenitcation]
        public async Task<ActionResult> Add()
        {
            var bill = new BillModel
            {
                DropDown = await _companyService.GetCompanyItemsAsync(UserId)
            };

            return View(bill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(BillModel model)
        {
            model.UserId = UserId;

            try
            {
                if (ModelState.IsValid)
                {
                    if (await _service.AddBillAsync(model))
                    {
                        TempData["success"] = "Bill was added";

                        return Home();
                    } else
                    {
                        ViewBag.error = "Bill could not be added";
                    }

                    return Home();
                }
            } catch (Exception)
            {
                model.DropDown = await _companyService.GetCompanyItemsAsync(UserId);
                ViewBag.error = ErrorMessage;
            }

            return View(model);
        }
    }
}
