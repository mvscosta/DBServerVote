using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Vote.DAO;

namespace Vote
{
    public static class HtmlExtensions
    {
        public static Funcionario DadosUsuario<T>(this HtmlHelper<T> html)
        {
            if (html == null)
                throw new ArgumentNullException("html");

            var db = new Vote.DAO.VoteEF();
            var usernameAuthentication = "";
            Funcionario usuario = null;

            if (html.ViewContext.HttpContext.User.Identity is ClaimsIdentity)
            {
                usernameAuthentication = (html.ViewContext.HttpContext.User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "name").Select(c => c.Value).First();
                usuario = db.Funcionarios.Where(u => u.Username.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            }
            else
            {
                usernameAuthentication = html.ViewContext.HttpContext.User.Identity.Name;
                usuario = db.Funcionarios.Where(u => u.Username.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            }
            if (usuario == null)
            {
                usuario = new Funcionario();
                usuario.Username = usernameAuthentication;
            }
            return (usuario);
        }

        public static bool UsuarioAdministrador<T>(this HtmlHelper<T> html)
        {
            var user = DadosUsuario(html);

            if (user == null)
                return false;

            return user.Administrador;
        }
    }
}