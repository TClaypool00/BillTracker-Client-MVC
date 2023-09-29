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
    public class SubscriptionsController : ControllerHelper
    {
        #region private fields
        private readonly ISubscriptionService _subscriptionService;
        private readonly ICompanyService _companyService;
        #endregion

        #region Constructors
        public SubscriptionsController(ISubscriptionService subscriptionService, ICompanyService companyService)
        {
            _subscriptionService = subscriptionService;
            _companyService = companyService;
        }
        #endregion

        #region View methods
        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostSubscriptionViewModel
            {
                DateDue = DateTime.Now
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> AllSubscriptions([FromQuery] int? index = null, string search = null)
        {
            var coreSubscriptions = await _subscriptionService.GetSubscriptionsAsync(UserId, index, search);
            var subscriptionViewModels = new List<SubscriptionViewModel>();

            if (coreSubscriptions.Count > 0)
            {
                for (int i = 0; i < coreSubscriptions.Count; i++)
                {
                    subscriptionViewModels.Add(new SubscriptionViewModel(coreSubscriptions[i]));
                }
            }

            return View(subscriptionViewModels);
        }
        #endregion

        #region AJAX methods
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PostSubscriptionViewModel model)
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

                if (await _subscriptionService.SubscriptionExistsAsync(model.SubscriptionName, UserId))
                {
                    return BadRequest(_subscriptionService.SubscriptionAlreadyExistsMessage(model.SubscriptionName));
                }

                var coreSubscription = new CoreSubscription(model, UserId)
                {
                    CompanyId = _companyService.GetCompanyIdByNameAsync(model.CompanyText)
                };

                await _subscriptionService.AddSubscriptionAsync(coreSubscription);

                return OKMessage(_subscriptionService.SubscriptionCreatedOKMessage);

            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromBody] UpdateSubscriptionViewModel model)
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

                model.CompanyId = _companyService.GetCompanyIdByNameAsync(model.CompanyText);

                if (!await _subscriptionService.UserOwnsSubscriptionAsync(model.SubscriptionId, UserId))
                {
                    return Unauthorized(UnAuthMessage);
                }

                if (await _subscriptionService.SubscriptionExistsAsync(model.SubscriptionName, UserId, model.SubscriptionId))
                {
                    return BadRequest(_subscriptionService.SubscriptionAlreadyExistsMessage(model.SubscriptionName));
                }

                var coreSubscription = new CoreSubscription(model, UserId);

                await _subscriptionService.UpdateSubscriptionAsync(coreSubscription);

                var viewModel = new SubscriptionViewModel(coreSubscription, _subscriptionService.SubscriptionUpdatedOKMessage);

                return OKMessage(viewModel);
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }

        public async Task<ActionResult> SubscriptionIsActive([FromBody] PostActiveViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(DisplayErrorMessages());
                }

                if (!await _subscriptionService.UserOwnsSubscriptionAsync(model.Id, UserId))
                {
                    return Unauthorized(UnAuthMessage);
                }

                await _subscriptionService.ToggleSubscriptionIsActive(model.Id, model.IsActive);

                return OKMessage(_subscriptionService.SubscriptionToggleMessage(model.IsActive));
            }
            catch (Exception e)
            {
                return InternalError(e);
            }
        }
        #endregion
    }
}
