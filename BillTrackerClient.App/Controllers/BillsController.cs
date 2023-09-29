using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using BillTrackerClient.App.Models.PostModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    [Authorize]
    public class BillsController : ControllerHelper
    {
        private readonly IBillService _billService;
        private readonly ICompanyService _companyService;
        private readonly IMessageService _messageService;

        public BillsController(IBillService billService, ICompanyService companyService, IMessageService messageService)
        {
            _billService = billService;
            _companyService = companyService;
            _messageService = messageService;
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


                return OKMessage(_billService.BillCreatedMessage);
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }

        [HttpGet]
        public async Task<ActionResult> AllBills([FromQuery]int? index = null, string search = null)
        {

            var coreBills = await _billService.GetAllBillsAsync(UserId, index, search);
            var billModels = new List<BillViewModel>();

            if (coreBills.Count > 0)
            {
                for (int i = 0; i < coreBills.Count; i++)
                {
                    billModels.Add(new BillViewModel(coreBills[i]));
                }
            }

            return View(billModels);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateBill([FromBody] UpdateBillViewModel updateBillViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrorMessages());
                }

                //TODO: Add a validation to check if bill belongs to user

                var coreBill = new CoreBill(updateBillViewModel, UserId)
                {
                    CompanyId = _companyService.GetCompanyIdByNameAsync(updateBillViewModel.CompanyText)
                };

                await _billService.UpdateBillAsync(coreBill);

                return OKMessage(_billService.BillUPdatedMessage);
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ActiveBill([FromBody] PostActiveViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrorMessages());
                }

                await _billService.ActiveBillAsync(model.Id, model.IsActive);

                return OKMessage(_messageService.IsActiveMessage("bill", model.IsActive));
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }
    }
}
