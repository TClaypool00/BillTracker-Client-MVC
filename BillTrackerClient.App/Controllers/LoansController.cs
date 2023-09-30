using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using BillTrackerClient.App.Models.PostModels;
using BillTrackerClient.App.Models.PostModels.UpdateModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    public class LoansController : ControllerHelper
    {
        #region Private fields
        private readonly ILoanService _loanService;
        private readonly ICompanyService _companyService;
        #endregion

        #region Constructors
        public LoansController(ILoanService loanService, ICompanyService companyService)
        {
            _loanService = loanService;
            _companyService = companyService;
        }
        #endregion

        #region View methods
        public ActionResult Add()
        {
            var model = new PostLoanViewModel
            {
                DateDue = DateTime.Now
            };

            return View(model);
        }

        public async Task<ActionResult> AllLoans([FromQuery] int? index = null, string search = null)
        {
            var coreLoans = await _loanService.GetAllLoansAsync(UserId, index, search);
            var loanViewModels = new List<LoanViewModel>();

            if (coreLoans.Count > 0)
            {
                for (int i = 0; i < coreLoans.Count; i++)
                {
                    loanViewModels.Add(new LoanViewModel(coreLoans[i]));
                }
            }

            return View(loanViewModels);

        }
        #endregion

        #region AJAX methods
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PostLoanViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrorMessages());
                }

                if (!await _companyService.CompanyNameExistsAsync(model.CompanyText))
                {
                    return NotFound(_companyService.CompanyNameNotFoundMessage(model.CompanyText));
                }

                if (await _loanService.LoanExistsAsync(model.LoanName, UserId))
                {
                    return BadRequest(_loanService.LoanAlreadyExistsMessage(model.LoanName));
                }

                model.CompanyId = _companyService.GetCompanyIdByNameAsync(model.CompanyText);

                var coreLoan = new CoreLoan(model, UserId);

                await _loanService.AddLoanAsync(coreLoan);

                return OKMessage(_loanService.LoanCreatedOKMessage);
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromBody] UpdateLoanViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrorMessages());
                }

                if (!await _companyService.CompanyNameExistsAsync(model.CompanyText))
                {
                    return NotFound(_companyService.CompanyNameNotFoundMessage(model.CompanyText));
                }

                if (await _loanService.LoanExistsAsync(model.LoanName, UserId, model.LoanId))
                {
                    return BadRequest(_loanService.LoanAlreadyExistsMessage(model.LoanName));
                }

                model.CompanyId = _companyService.GetCompanyIdByNameAsync(model.CompanyText);

                var coreLoan = new CoreLoan(model, UserId);

                await _loanService.UpdateLoanAsync(coreLoan);

                return OKMessage(new LoanViewModel(coreLoan, _loanService.LoanUpdatedOKMessage));
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult> LoanIsActive([FromBody] PostActiveViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrorMessages());
                }

                if (!await _loanService.UserOwnsLoanAsync(model.Id, UserId))
                {
                    return Unauthorized(UnAuthMessage);
                }

                await _loanService.ToggleLoanIsActive(model.Id, model.IsActive);

                return OKMessage(_loanService.LoanToggleMessage(model.IsActive));
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }
        #endregion
    }
}
