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
    public class SubscriptionsController : ControllerHelper
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly ICompanyService _companyService;

        public SubscriptionsController(ISubscriptionService subscriptionService, ICompanyService companyService)
        {
            _subscriptionService = subscriptionService;
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostSubscriptionViewModel
            {
                DateDue = DateTime.Now
            };

            return View(model);
        }

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
    }
}
