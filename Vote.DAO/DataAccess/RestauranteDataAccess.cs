using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;

namespace Vote.DAO.DataAccess
{
    public class RestauranteDataAccess : BaseDataAccess<Restaurante>, IRestauranteDataAccess
    {
        IQueryable<IRestaurante> IBaseDataAccess<IRestaurante>.All => base.All;

        public bool Add(IRestaurante value) => base.Add((Restaurante)value);

        public bool Edit(IRestaurante value) => base.Edit((Restaurante)value);

        public bool Remove(IRestaurante value) => base.Remove((Restaurante)value);

        public IRestaurante Find(int id) => base.Find(id);
    }
}
