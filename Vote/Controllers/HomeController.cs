using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Vote.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Vote!";

            return View();
        }

        [Authorize]
        public ActionResult Claims()
        {
            Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);
            ViewBag.DisplayName = displayName != null ? displayName.Value : string.Empty;
            return View();
        }
    }
}
