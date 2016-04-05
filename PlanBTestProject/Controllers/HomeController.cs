using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanBTestProject.Controllers
{
    public class HomeController : MainController
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}