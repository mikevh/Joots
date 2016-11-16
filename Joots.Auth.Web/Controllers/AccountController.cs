using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Joots.Auth.Web.ViewModels;

namespace Joots.Auth.Web.Controllers
{
    [Authorize]
    [RoutePrefix("account")]
    public class AccountController : Controller
    {
        internal static List<UserModel> Users = new List<UserModel>();

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public ActionResult Register(UserModel vm)
        {
            if (vm == null || !ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Users.Add(vm);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


    }
}
