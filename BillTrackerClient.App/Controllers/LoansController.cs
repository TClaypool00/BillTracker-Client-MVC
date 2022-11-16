using BillTrackerClient.App.Helpers;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    public class LoansController : ControllerHelper
    {
        private readonly ILoanService _service;
        private readonly ICompanyService _companyService;

        public LoansController(ILoanService service, ICompanyService companyService)
        {
            _service = service;
            _companyService = companyService;
        }

        [HttpGet]
        [Authenitcation]
        public async Task<ActionResult> Add()
        {
            var model = new LoanModel
            {
                DropDown = await _companyService.GetCompanyItemsAsync(UserId)
            };

            return View(model);
        }

        [HttpPost]
        [Authenitcation]
        public async Task<ActionResult> Add(LoanModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _service.AddLoanAsync(model))
                    {
                        TempData["success"] = "Loan has been added";

                        return Home();
                    } else
                    {
                        ViewBag.error = "Loan could not be added";
                    }
                }
            } catch(Exception)
            {
                ViewBag.error = ErrorMessage;
            }

            model.DropDown = await _companyService.GetCompanyItemsAsync(UserId);

            return View(model);
        }
    }
}
