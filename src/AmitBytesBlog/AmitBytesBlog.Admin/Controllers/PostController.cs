using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AmitBytesBlog.Admin.Controllers
{
    public class PostController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}