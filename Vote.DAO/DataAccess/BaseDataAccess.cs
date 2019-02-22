using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Vote.Core.Interfaces.DAO;
using Vote.Core.Interfaces.Model;

namespace Vote.DAO.DataAccess
{
    public abstract class BaseDataAccess<T> : IBaseDataAccess<T> where T : class, IBaseModel
    {
        protected readonly VoteEF voteEF = new VoteEF();

        public IQueryable<T> All
        {
            get
            {
                var propInfo = typeof(VoteEF).GetProperties().FirstOrDefault(p => p.PropertyType == typeof(DbSet<T>));

                return (DbSet<T>)propInfo?.GetValue(voteEF);
            }
        }

        public virtual T Find(int id)
        {
            return All.FirstOrDefault(d => d.Id == id);
        }

        public virtual bool Add(T value)
        {
            try
            {
                (this.All as IDbSet<T>).Add(value);
                voteEF.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public virtual bool Edit(T value)
        {
            try
            {
                voteEF.Entry(value).State = EntityState.Modified;
                voteEF.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public virtual bool Remove(T value)
        {
            try
            {
                (this.All as IDbSet<T>).Remove(value);
                voteEF.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }


    }
}
