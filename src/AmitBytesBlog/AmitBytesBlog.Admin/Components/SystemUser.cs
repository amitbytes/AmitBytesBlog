using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmitBytesBlog.Admin.Models;
namespace AmitBytesBlog.Admin.Componets
{
    public class SystemUser : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            SystemUserVM systemUserVM = new SystemUserVM();
            return View(systemUserVM);
        }
    }
}
