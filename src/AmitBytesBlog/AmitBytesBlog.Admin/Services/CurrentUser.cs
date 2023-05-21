using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE = AmitBytesBlog.Entity;

namespace AmitBytesBlog.Admin
{
    public class CurrentUser
    {
        public IHttpContextAccessor HttpContextAccessor { get; }
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }
        public BE.SystemUser Instance
        {
            get { return HttpContextAccessor.HttpContext.Session.CurrentUser(); }
        }
    }
}
