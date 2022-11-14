using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ActionResult> Add()
        {
            var model = new LoanModel
            {
                DropDown = await _companyService.GetCompanyItemsAsync(UserId)
            };

            return View(model);
        }
    }
}
