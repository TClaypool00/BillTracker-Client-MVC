using BillTrackerClient.App.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BillTrackerClient.App.Controllers
{
    public class BillsController : ControllerHelper
    {
        [HttpGet]
        [Authenitcation]
        public ActionResult Add()
        {
            return View();
        }
    }
}
