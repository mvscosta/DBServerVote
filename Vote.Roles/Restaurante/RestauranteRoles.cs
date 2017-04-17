using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vote.DAO;

namespace Vote.Roles.Restaurant
{
    public class RestauranteRoles
    {
        public static bool ValidaRestaurante(VoteEF db, int idRestaurante)
        {
            if (db == null)
                db = new VoteEF();

            return (db.Restaurantes.Find(idRestaurante) ?? new Restaurante() { Ativo = false }).Ativo;
        }

        public static bool ValidaRestaurante(VoteEF db, string nomeRestaurante)
        {
            if (db == null)
                db = new VoteEF();

            var rest = db.Restaurantes.Where(r => r.Nome == nomeRestaurante);

            if (!rest.Any() || rest.Count() > 1)
                return false;
            else
            {
                return true;
            }
        }

    }
}
