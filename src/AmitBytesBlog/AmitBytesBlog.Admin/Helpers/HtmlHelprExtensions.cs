using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmitBytesBlog.Admin
{
    public static class HtmlHelprExtensions
    {
        #region HTML Helper
        //https://stackoverflow.com/questions/20410623/how-to-add-active-class-to-html-actionlink-in-asp-net-mvc
        public static string IsSelected(this IHtmlHelper htmlHelper, string controller, string action)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.Values["action"] as string;
            string currentController = htmlHelper.ViewContext.RouteData.Values["controller"] as string;
            var returnActive = controller == currentController && action == currentAction;
            return returnActive ? "active" : "";
        }
        #endregion
    }
}
