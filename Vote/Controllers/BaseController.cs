using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vote.DAO;

namespace Vote.Controllers
{
    public abstract class BaseController : Controller
    {
        internal abstract void CarregarViewBag();

        internal VoteEF db = new VoteEF();
        public DateTime DateTimeNow
        {
            get
            {
                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "E. South America Standard Time");
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.HttpContext.User != null &&
                       this.HttpContext.User.Identity != null &&
                       this.HttpContext.User.Identity.IsAuthenticated;
            }
        }
        public Funcionario UsuarioAtual
        {
            get
            {
                var usernameAuthentication = "";
                Funcionario usuario = null;

                if (HttpContext.User.Identity is ClaimsIdentity)
                {
                    usernameAuthentication = (HttpContext.User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "name").Select(c => c.Value).First();
                    usuario = db.Funcionarios.FirstOrDefault(u => u.Ativo && u.Username.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    usernameAuthentication = HttpContext.User.Identity.Name;
                    usuario = db.Funcionarios.FirstOrDefault(u => u.Ativo && u.Username.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));
                }
                if (usuario == null)
                {
                    usuario = new Funcionario {Username = usernameAuthentication};
                }
                return (usuario);
            }
        }

        public bool UsuarioAdministrador()
        {
            if (UsuarioAtual== null)
                return false;

            return UsuarioAtual.Administrador;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}