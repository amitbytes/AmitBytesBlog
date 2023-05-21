using AmitBytesBlog.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmitBytesBlog.Admin
{
    public class EnsureModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                context.Result = new ObjectResult(context.ModelState);
                return;
            }
            context.Result = new ViewResult()
            {
                ViewData = ((Controller)context.Controller).ViewData,
                TempData = ((Controller)context.Controller).TempData,
                StatusCode = 400 //Bad Request
            };
        }
    }
}
