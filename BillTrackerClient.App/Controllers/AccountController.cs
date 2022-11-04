using BillTrackerClient.App.Helpers;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    public class AccountController : ControllerHelper
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Anonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _service.GetUserByEmailAsync(model.Email);

                    if (user is null)
                    {
                        ViewBag.error = "Incorrect email";
                    } else
                    {
                        if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                        {
                            HttpContext.Session.SetInt32("UserId", user.UserId);
                            HttpContext.Session.SetString("FirstName", user.FirstName);
                            HttpContext.Session.SetString("Email", user.Email);
                            HttpContext.Session.SetString("IsAdmin", user.IsAdmin.ToString());
                            HttpContext.Session.SetString("PhoneNum", user.PhoneNum);

                            return RedirectToAction("Index", "Home");
                        } else
                        {
                            ViewBag.error = "Incorrect password";
                        }
                    }
                }
            } catch (Exception e)
            {
                ViewBag.error = e.Message;
            }

            return View(model);
        }

        [HttpGet]
        [Anonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

                    await _service.AddUserAsync(model);                    

                    TempData["Success"] = "User has been registered";

                    return Redirect("Login");
                }
            } catch (Exception e)
            {
                ViewBag.error = e.Message;
            }

            return View(model);
        }

        [HttpGet]
        [Authenitcation]
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "You have logged out";

            return RedirectToAction("Login");
        }
    }
}
