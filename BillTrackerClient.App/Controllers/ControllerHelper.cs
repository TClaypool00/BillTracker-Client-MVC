using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillTrackerClient.App.Controllers
{
    public class ControllerHelper : Controller
    {
        protected int UserId
        {
            get
            {
                return (int)HttpContext.Session.GetInt32("UserId");
            }
        }

        protected string FirstName
        {
            get
            {
                return GetSessionName("FirstName");
            }
        }

        protected string LastName
        {
            get
            {
                return GetSessionName("LastName");
            }
        }

        protected string Email
        {
            get
            {
                return GetSessionName("Email");
            }
        }

        protected bool IsAdmin
        {
            get
            {
                return GetSessionName("IsAdmin") == "True";
            }
        }

        protected string PhoneNumber
        {
            get
            {
                return GetSessionName("PhoneNum");
            }
        }

        protected string ErrorMessage
        {
            get
            {
                return "Ann error has occured";
            }
        }

        private string GetSessionName(string keyName)
        {
            return HttpContext.Session.GetString(keyName);
        }
    }
}
