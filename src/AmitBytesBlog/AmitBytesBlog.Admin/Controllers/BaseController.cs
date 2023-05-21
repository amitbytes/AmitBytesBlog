using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AmitBytesBlog.Entity.Extensions;
using BE = AmitBytesBlog.Entity;

namespace AmitBytesBlog.Admin.Controllers
{
    public class BaseController : Controller
    {

        // Draw value to be return in jquery dataTable response
        protected int Draw { get; set; }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!User.Identity.IsAuthenticated || HttpContext.Session.CurrentUser() == null)
            {
                if (HttpContext.Request.IsAjaxRequest())
                {
                    var result = new { Status = UIConstants.SESSIONTIMEOUT_CODE, Message = UIConstants.SESSIONTIMEOUT_MESSAGE };
                    context.Result = new UnauthorizedObjectResult(result);
                }
                context.Result = new RedirectToRouteResult(new { controller = "Account", action = "Login", returnUrl = HttpContext.Request.Path });
            }

            base.OnActionExecuting(context);
        }

        protected BE.PageListParameters GetPagedListParameter(IFormCollection fc)
        {
            Draw = fc["draw"].ToString().ToInt32();
            var pageIndex = fc["start"].ToString().ToInt32();
            var pageSize = fc["length"].ToString().ToInt32();
            var searchValue = fc["searchValue"].ToString();
            var orderIndex = fc["order[0][column]"].ToString().ToInt32();
            var sortOrder = fc["order[0][dir]"].ToString();
            var columnName = fc[$"columns[{orderIndex}][name]"].ToString();
            BE.PageListParameters parameters = new BE.PageListParameters();
            parameters.PageIndex = pageIndex;
            parameters.PageSize = pageSize;
            parameters.SearchValue = searchValue;
            parameters.SortColumn = columnName;
            parameters.SortDir = sortOrder == "asc" ? BE.SortOrder.ASC : BE.SortOrder.DESC;
            return parameters;
        }
    }
}