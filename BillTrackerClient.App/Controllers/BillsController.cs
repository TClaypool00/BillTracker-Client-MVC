using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BillTrackerClient.App.Controllers
{
    [Authorize]
    public class BillsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostBillViewModel()
            {
                CompanyDropDown = new List<SelectListItem>()
                {
                    new SelectListItem("Add a company", "")
                }
            };

            return View(model);
        }

        public ActionResult AddAsync(PostBillViewModel model)
        {
            return View(model);
        }
    }
}
