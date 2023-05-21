using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmitBytesBlog.Admin
{
    public static class HtmlHelpersExtensions
    {

        //https://weblogs.asp.net/ricardoperes/inline-images-in-asp-net-mvc-core
        public static HtmlString CaptchaImage(this IHtmlHelper html)
        {
            var imgBytes = html.ViewContext.HttpContext.Session.CreateCaptcha();
            var base64 = Convert.ToBase64String(imgBytes);
            var img = $"<img src=\"data:image/png;base64,{base64}\" alt=\"captcha\"/>";
            return new HtmlString(img);
        }
    }
}
