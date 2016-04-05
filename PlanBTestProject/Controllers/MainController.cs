using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanBTestProject.Models;

namespace PlanBTestProject.Controllers
{
    public class MainController : Controller
    {
        protected ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            protected set
            {
                _userManager = value;
            }
        }

        protected override void EndExecute(IAsyncResult asyncResult)
        {
            Boolean result = false;
            string name = string.Empty;
            try
            {
                result = UserManager.IsInRoleAsync(User.Identity.GetUserId(), "Administrador").Result;
                ApplicationUser user = UserManager.Users.FirstOrDefault(u => u.Id == User.Identity.GetUserId());
                ViewBag.Adm = user.Name;
            }
            catch { }
            ViewBag.IsAdm = result;
            base.EndExecute(asyncResult);
        }
    }
}