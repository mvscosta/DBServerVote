using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;

namespace Vote.DAO.DataAccess
{
    public class FuncionarioDataAccess : BaseDataAccess<Funcionario>, IFuncionarioDataAccess
    {
        IQueryable<IFuncionario> IBaseDataAccess<IFuncionario>.All => base.All;

        public bool Add(IFuncionario value) => base.Add((Funcionario)value);

        public bool Edit(IFuncionario value) => base.Edit((Funcionario)value);

        public bool Remove(IFuncionario value) => base.Remove((Funcionario)value);

        public IFuncionario Find(int id) => base.Find(id);
    }
}
