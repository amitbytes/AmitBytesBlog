using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using AmitBytesBlog.Entity;
using AmitBytesBlog.Entity.Extensions;
using System.IO;
using Newtonsoft.Json;
using BE = AmitBytesBlog.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmitBytesBlog.Admin
{


    /// <summary>
    /// Session Extensoin Methods
    /// </summary>
    internal static class SessionExtensions
    {
        // https://www.c-sharpcorner.com/article/how-to-return-an-image-result-from-web-api-using-net-core/
        public static byte[] CreateCaptcha(this ISession session)
        {
            using (var image = new Bitmap(1, 1))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {   //Generate randome number
                    var captchaCode = new Random().Next(10000, 99999);
                    SizeF textSize = graphics.MeasureString(captchaCode.ToString(), new Font(FontFamily.GenericSansSerif, 15));

                    // set captcha code to session variable
                    session.Set<int>(Global.SESSION_CAPTCHA_NAME, captchaCode);
                    //var img = new Bitmap((int)textSize.Width, (int)textSize.Height);
                    var img = new Bitmap(50, 15); //50x15=> wXh image
                    var finalImg = Graphics.FromImage(img);
                    finalImg.Clear(Color.White); //background color
                    Brush textBrush = new SolidBrush(Color.Black);
                    finalImg.DrawString(captchaCode.ToString(), new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold), textBrush, 0, 0);
                    finalImg.Save();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        return ms.ToArray();
                    }
                }
            }
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T Get<T>(this ISession session, string key)
        {
            var result = session.GetString(key);
            return result == null ? default : JsonConvert.DeserializeObject<T>(result);
        }

        public static bool IsValidCaptcha(this ISession session, string captcha)
        {
            return session.Get<int>(Global.SESSION_CAPTCHA_NAME) == captcha.ToInt32() ? true : false;
        }

        #region Current User
        public static BE.SystemUser CurrentUser(this ISession session)
        {
            return session.Get<BE.SystemUser>(UIConstants.CURRENTUSER_SESSIONKEY);
        }
        public static void CurrentUser(this ISession session, BE.SystemUser systemUser)
        {
            session.Set<BE.SystemUser>(UIConstants.CURRENTUSER_SESSIONKEY, systemUser);
        }
        #endregion

        #region Ajax Request
        private const string REQUESTEDWITHHEADER = "X-Requested-With";
        private const string XMLHTTPREQUEST = "XMLHttpRequest";
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Headers != null && request.Headers.ContainsKey(REQUESTEDWITHHEADER))
            {
                var headerValue = request.Headers.GetCommaSeparatedValues(REQUESTEDWITHHEADER).FirstOrDefault();
                if (!headerValue.IsEmpty() && headerValue.Equals(XMLHTTPREQUEST, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }
        #endregion

    }

}
