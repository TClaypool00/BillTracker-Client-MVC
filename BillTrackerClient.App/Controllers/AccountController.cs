using BillTrackerClient.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillTrackerClient.App.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register(RegisterModel model)
        {
            return View();
        }
    }
}
