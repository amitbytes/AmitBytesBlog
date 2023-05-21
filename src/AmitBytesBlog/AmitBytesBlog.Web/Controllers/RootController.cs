using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AmitBytesBlog.Web.Controllers
{

    [Route("")]
    public class RootController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{year:int}/{month:int}/{day:int}/{post}")]
        public IActionResult Story(int year,int month,int day,string post)
        {
            var result = $"{year}/{month}/{day}/{post}";
            return View("Post");
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return Content("Contact Page");
        }
        [Route("about")]
        public IActionResult About()
        {
            return Content("about");
        }
    }
}