using BillTrackerClient.App.CoreModels;
using BillTrackerClient.App.Interfaces;
using BillTrackerClient.App.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BillTrackerClient.App.Controllers
{
    public class AccountController : ControllerHelper
    {
        private readonly IUserService _userService;
        private readonly IPasswordservice _passwordService;
        private readonly IUserRoleService _userRoleService;

        public AccountController(IPasswordservice passwordService, IUserService userService, IUserRoleService userRoleService)
        {
            _passwordService = passwordService;
            _userService = userService;
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            GetTempSuccessMessage();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (!await _userService.UserExistsByEmailAsync(model.Email))
                {
                    return SetError(_userService.EmailDoesNotExistMessage, model);
                }

                var user = await _userService.GetUserAsync(model.Email);

                if (!_passwordService.VerifyPassword(user.Password, model.Password))
                {
                    return SetError(_userService.PhoneNumberDoesNotExistMessage, model);
                }

                var userRoles = await _userRoleService.GetRoleNamesByUserIdAsync(user.UserId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim("LastName", user.LastName)
                };

                for (int i = 0; i < userRoles.Count; i++)
                {
                    CoreRole role;
                    role = userRoles[i];

                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

                return Home();
            }
            catch (Exception e)
            {
                SetError(e);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                if (await _userService.UserExistsByEmailAsync(model.Email))
                {
                    return SetError(_userService.EmailExistsMessage, model);
                }

                if (await _userService.UserExistsByPhoneNumberAsync(model.PhoneNumber))
                {
                    return SetError(_userService.PhoneNumberExistsMessage, model);
                }

                if (!_passwordService.PasswordMeetsRequirements(model.Password))
                {
                    return SetError(_passwordService.PasswordDoesNotMeetRequirements, model);
                }

                model.Password = _passwordService.HashPassword(model.Password);

                var coreUser = new CoreUser(model);


                if (await _userService.CreateUserAsync(coreUser))
                {
                    SetTempSuccessMessage(_userService.UserCreatedMessage);

                    return RedirectToAction("Login");
                }
            }
            catch (Exception e)
            {
                SetError(e);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
