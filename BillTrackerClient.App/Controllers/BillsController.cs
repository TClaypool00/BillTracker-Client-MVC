using BillTrackerClient.App.Helpers;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using BillTrackerClient.App.Models.PostModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BillTrackerClient.App.Controllers
{
    public class BillsController : ControllerHelper
    {
        private readonly IBillService _service;

        public BillsController(IBillService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authenitcation]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BillModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    return Home();
                }
            } catch (Exception)
            {
                ViewBag.error = ErrorMessage;
            }

            return View(model);
        }
    }
}
