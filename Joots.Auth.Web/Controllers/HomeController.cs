using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joots.Auth.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tokenTimeoutInMinutes = ConfigurationManager.AppSettings["TokenTimeoutInMinutes"] ?? "999";

            return View(tokenTimeoutInMinutes as object);
        }

        [Authorize]
        public ActionResult Protected()
        {

            return new ContentResult {Content = "hello!"};
        }
    }
}