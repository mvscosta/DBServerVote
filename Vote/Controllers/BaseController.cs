using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vote.DAO;

namespace Vote.Controllers
{
    public class BaseController : Controller
    {
        internal VoteEF db = new VoteEF();

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
                    usuario = db.Funcionarios.FirstOrDefault(u => u.Username.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    usernameAuthentication = HttpContext.User.Identity.Name;
                    usuario = db.Funcionarios.FirstOrDefault(u => u.Username.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));
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
    }
}