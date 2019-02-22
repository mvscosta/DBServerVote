using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;

namespace Vote.DAO.DataAccess
{
    public class CategoriaDataAccess : BaseDataAccess<Categoria>, ICategoriaDataAccess
    {
        IQueryable<ICategoria> IBaseDataAccess<ICategoria>.All => base.All;

        public bool Add(ICategoria value) => base.Add((Categoria)value);

        public bool Edit(ICategoria value) => base.Edit((Categoria)value);
        
        public bool Remove(ICategoria value) => base.Remove((Categoria)value);

        public ICategoria Find(int id) => base.Find(id);
    }
}
