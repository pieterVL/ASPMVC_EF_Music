using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CRUDRepository<T> : IRepository<T>
        where T:class
    {
        private DbContext db;
        private DbSet<T> Dbset;
        public CRUDRepository(DbContext Context, DbSet<T> Dbset) {
            this.db = Context;
            this.Dbset = Dbset;
        }
        virtual public List<T> GetAll()
        {
            return Dbset.ToList();
        }

        virtual public T Find(int? id)
        {
            return Dbset.Find(id);
        }

        virtual public void Add(T t)
        {
            Dbset.Add(t);
            db.SaveChanges();
        }

        virtual public void Update(T t)
        {
            db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();        
        }
        virtual public void Delete(T t)
        {
            Dbset.Remove(t);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
