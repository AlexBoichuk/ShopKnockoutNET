using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    interface IGenericRepository<T> where T : class
    {
        //IQueryable<T> GetAll(string includeProperties = "");
        IQueryable<T> GetAll();
        void Add(T item);
        void Delete(int id);
    }
}
