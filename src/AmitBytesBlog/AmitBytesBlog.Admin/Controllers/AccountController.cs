using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmitBytesBlog.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DA = AmitBytesBlog.DataAccess;
using BE = AmitBytesBlog.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AmitBytesBlog.Entity.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace AmitBytesBlog.Admin.Controllers
{

    public class AccountController : Controller
    {
        public DA.ISystemUserRepository SystemUserRepository { get; }
        public AccountController(DA.ISystemUserRepository systemUserRepository)
        {
            SystemUserRepository = systemUserRepository;
        }


        [Route("~/captcha")]
        [Route("[controller]/[action]")]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Captcha()
        {
            return File(HttpContext.Session.CreateCaptcha(), "img/png");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [EnsureModelValidation]
        public async Task<ActionResult> Login(SystemUserVM systemUser, string returnUrl)
        {
            if (!HttpContext.Session.IsValidCaptcha(systemUser.Captcha))
            {
                ModelState.AddModelError("captcha", "Enter valid captcha only");
                return View(systemUser);
            }

            try
            {
                var verifiedUser = SystemUserRepository.AuthenticateSystemUser(systemUser.UserName, systemUser.Password);
                if (verifiedUser != null)
                {
                    var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, systemUser.UserName),
                            new Claim(ClaimTypes.NameIdentifier,systemUser.UserName)
                        };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.Session.CurrentUser(verifiedUser); // set current user
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));

                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid user or password!!");
                return View(systemUser);
            }
            catch (Exception)
            {
                //Log Error
                ModelState.AddModelError(string.Empty, "Internal server error");
                return View(systemUser);
            }

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            HttpContext.Session.Clear();
            ClearCookies();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //return new ObjectResult(new { status = 302, message = "You are logout successfully !!" });
            return RedirectToAction("Login");
        }
        private void ClearCookies()
        {
            //clear all cookies once user logout
            var cookieOption = new CookieOptions() { Expires = DateTime.Now.AddYears(-30) };
            HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme, cookieOption);
            HttpContext.Response.Cookies.Delete(UIConstants.SESSION_COOKIE_NAME, cookieOption);
            HttpContext.Response.Cookies.Delete(UIConstants.XCSRF_COOKIE_NAME, cookieOption);
        }
    }
}