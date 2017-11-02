using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    interface IRepository<T>
        where T: class
    {
        List<T>GetAll();
        T Find(int? id);
        void Add(T t);
        void Update(T t);
        void Delete(T t);

    }
}
