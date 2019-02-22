using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vote.Core.Interfaces.DAO
{
    public interface IBaseDataAccess<T> where T : class
    {
        IQueryable<T> All { get; }

        T Find(int id);
        bool Add(T value);
        bool Edit(T value);
        bool Remove(T value);
    }
}
