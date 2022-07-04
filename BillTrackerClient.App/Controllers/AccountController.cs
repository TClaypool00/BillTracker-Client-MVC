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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            var result = API<UserModel>.Login(model);

            if (result.GetType() == typeof(UserModel))
            {
                UserModel user = (UserModel)result;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = result;
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = API<RegisterModel>.Post(model, "users", API<RegisterModel>.MethodTypes.Post);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("login");
                }
            }

            return View(model);
        }
    }
}
