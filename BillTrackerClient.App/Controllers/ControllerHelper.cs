using Microsoft.AspNetCore.Mvc;

namespace BillTrackerClient.App.Controllers
{
    public class ControllerHelper : Controller
    {   
        protected ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
