using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vote.DAO;

namespace Vote.Roles
{
    public class FuncionarioRoles
    {
        public static bool ValidaFuncionario(VoteEF db, int idFuncionario)
        {
            if (db == null)
                db = new VoteEF();

            return (db.Funcionarios.Find(idFuncionario) ?? new Funcionario() { Ativo = false }).Ativo;
        }

        public static Funcionario ValidaFuncionario(VoteEF db, string usernameFuncionario)
        {
            if (db == null)
                db = new VoteEF();

            var func = db.Funcionarios.Where(f=>f.Username == usernameFuncionario);

            if (!func.Any() || func.Count() > 1)
                return null;
            else
            {
                return func.First();
            }
        }

    }
}
