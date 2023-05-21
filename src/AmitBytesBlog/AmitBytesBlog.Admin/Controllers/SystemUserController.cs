using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BE = AmitBytesBlog.Entity;
using DA = AmitBytesBlog.DataAccess;

namespace AmitBytesBlog.Admin.Controllers
{
    public class SystemUserController : BaseController
    {
        public DA.ISystemUserRepository SystemUserRepository { get; }
        public SystemUserController(DA.ISystemUserRepository systemUserRepository, CurrentUser currentUser)
        {
            SystemUserRepository = systemUserRepository;
            if (currentUser.Instance != null)
                SystemUserRepository.CurrentUserId = currentUser.Instance.SystemUserId;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData(IFormCollection fc)
        {
            BE.PageListParameters pageListParameters = base.GetPagedListParameter(fc);
            return null;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BE.SystemUser());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnsureModelValidation]
        public ActionResult Create(BE.SystemUser systemUser)
        {
            try
            {
                systemUser.Password = BE.Encryption.EncryptionHelper.Encrypt(systemUser.Password);
                SystemUserRepository.InsertOne(systemUser);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(systemUser);
                throw;
            }
        }
    }
}