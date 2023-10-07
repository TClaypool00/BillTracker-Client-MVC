using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    [Authorize]
    public class HomeController : ControllerHelper
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAllService _allService;

        public HomeController(ILogger<HomeController> logger, IAllService allService)
        {
            _logger = logger;
            _allService = allService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            GetTempSuccessMessage();

            var expenses = _allService.GetAllExpensesAsync(UserId);
            var viewModels = new List<ExpenseViewModel>();

            for (int i = 0; i < expenses.Count; i++)
            {
                viewModels.Add(new ExpenseViewModel(expenses[i]));
            }

            return View(viewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
