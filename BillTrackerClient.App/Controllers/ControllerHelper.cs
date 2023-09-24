using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace BillTrackerClient.App.Controllers
{
    public class ControllerHelper : Controller
    {
        #region Protected methods
        #region ActionResult methods
        protected ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }

        protected ActionResult SetError(string errorMessage, object model)
        {
            ViewBag.error = errorMessage;

            return View(model);
        }
        #endregion

        #region void methods
        protected void SetError(Exception exception)
        {
            ViewBag.error = exception.Message;
        }

        protected void SetTempSuccessMessage(string message)
        {
            TempData["Success"] = message;
        }

        protected void GetTempSuccessMessage()
        {
            if (TempData["Success"] is not null)
            {
                ViewBag.success = TempData["Success"];
            }
        }
        #endregion

        #endregion

        #region User claims properties
        protected int UserId
        {
            get
            {
                return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
        }
        #endregion

        #region AJAX methods
        protected ActionResult InternalError(Exception exception)
        {
            return StatusCode(500, exception.Message);
        }

        protected List<string> DisplayErrorMessages()
        {
            var errors = new List<string>();

            foreach (var item in ModelState.Values)
            {
                foreach (var error in item.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return errors;
        }

        protected ActionResult OKMessage(object message)
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(message);
        }
        #endregion
    }
}
