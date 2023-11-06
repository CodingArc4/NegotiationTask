using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NegotiationTask.FIlter
{
    public class NegotiationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var accept = context.HttpContext.Request.Headers["Accept"].ToString().ToLower();

            if (accept.Contains("application/json"))
            {
                context.HttpContext.Response.ContentType = "application/json";
            }
            else if (accept.Contains("text/plain"))
            {
                context.HttpContext.Response.ContentType = "text/plain";
            }
            else if (accept.Contains("text/html"))
            {
                context.HttpContext.Response.ContentType = "text/html";
            }
            else
            {
                context.HttpContext.Response.ContentType = "application/json";
            }
        }
    }
}
