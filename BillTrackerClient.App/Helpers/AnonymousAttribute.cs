using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace BillTrackerClient.App.Helpers
{
    public class AnonymousAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (context.HttpContext.Session.GetInt32("UserId") != null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"Controller", "Home" },
                        { "Action", "Index" }
                    });
            }
        }
    }
}
