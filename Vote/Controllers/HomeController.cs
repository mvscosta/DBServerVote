using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vote.Models;

namespace Vote.Controllers
{
    public class HomeController : BaseController
    {
        internal override void CarregarViewBag()
        {
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Vote!";
            
            return View(new HomeViewModel() { VotosComputadosHoje = Vote.Roles.VoteRoles.VotosComputados(db,DateTimeNow), RestauranteVencedor = Vote.Roles.VoteRoles.ResultadoRestauranteVencedor(db, DateTimeNow) });
        }

        public ActionResult Votar()
        {
            return RedirectToAction("Create", "Votos");
        }

        [Authorize]
        public ActionResult Claims()
        {
            Claim displayName = ClaimsPrincipal.Current.FindFirst(ClaimsPrincipal.Current.Identities.First().NameClaimType);
            ViewBag.DisplayName = displayName != null ? displayName.Value : string.Empty;
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
