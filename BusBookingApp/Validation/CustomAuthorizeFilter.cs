using BusBookingApp.bus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace BusBookingApp.Validation
{
    public class CustomAuthorizeFilter : Attribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var users = context.HttpContext.Session.GetObjectFromJson<Login>("logusers");
            if (users == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
                return;
            }
            // Console.WriteLine($"users: {JsonConvert.SerializeObject(users)}");
        }
    }
}