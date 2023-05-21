using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AmitBytesBlog.Admin.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error/{statusCode}")]
        [AllowAnonymous]
        public IActionResult Index(int statusCode)
        {
            //var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch(statusCode)
            {
                case 401:
                    ViewBag.StatusCode = statusCode;
                    ViewBag.ErrorMessage = "Sorry, Your don't have access.";
                    break;
                case 404:
                case 405:
                    ViewBag.StatusCode = statusCode;
                    ViewBag.ErrorMessage = "Sorry, the resource you are looking for could not be found.";
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public ActionResult Error()
        {
            return View();
        }
    }
}