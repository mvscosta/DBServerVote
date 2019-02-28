using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;

namespace Vote.DAO.DataAccess
{
    public class VotoDataAccess : BaseDataAccess<Voto>, IVotoDataAccess
    {
        IQueryable<IVoto> IBaseDataAccess<IVoto>.All => base.All;

        public bool Add(IVoto value) => base.Add((Voto)value);

        public bool Edit(IVoto value) => base.Edit((Voto)value);

        public bool Remove(IVoto value) => base.Remove((Voto)value);

        public IVoto Find(int id) => base.Find(id);
    }
}
