using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerce.Web.Filters
{
    public class RoleAuthorizationAttribute : Attribute, IActionFilter
    {
        private readonly string[] _allowedRoles;

        public RoleAuthorizationAttribute(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var email = session.GetString("Email");
            var role = session.GetString("Role");

            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
            else if(!_allowedRoles.Contains(role))
            {
                context.Result = new ViewResult { ViewName = "Error" };
            }
        }
    }
}