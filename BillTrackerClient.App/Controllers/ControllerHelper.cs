using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillTrackerClient.App.Controllers
{
    public class ControllerHelper : Controller
    {
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

        private string GetSessionName(string keyName)
        {
            return HttpContext.Session.GetString(keyName);
        }
    }
}
