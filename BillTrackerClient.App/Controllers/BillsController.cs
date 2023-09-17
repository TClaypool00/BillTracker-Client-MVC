using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BillTrackerClient.App.Controllers
{
    [Authorize]
    public class BillsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostBillViewModel
            {
                DateDue = DateTime.Now
            };

            return View(model);
        }

        public ActionResult Add(PostBillViewModel model)
        {
            if (ModelState.IsValid)
            {
                return NoContent();
            }

            return View(model);
        }
    }
}
