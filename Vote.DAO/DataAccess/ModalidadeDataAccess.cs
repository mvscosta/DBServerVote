using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;

namespace Vote.DAO.DataAccess
{
    public class ModalidadeDataAccess : BaseDataAccess<Modalidade>, IModalidadeDataAccess
    {
        IQueryable<IModalidade> IBaseDataAccess<IModalidade>.All => base.All;

        public bool Add(IModalidade value) => base.Add((Modalidade)value);

        public bool Edit(IModalidade value) => base.Edit((Modalidade)value);

        public bool Remove(IModalidade value) => base.Remove((Modalidade)value);

        public IModalidade Find(int id) => base.Find(id);
    }
}
