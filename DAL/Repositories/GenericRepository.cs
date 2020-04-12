using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopContext _db;
        private readonly DbSet<T> dbSet;


        public GenericRepository(ShopContext context)
        {
            _db = context;
            dbSet = context.Set<T>();
        }

        public void Add(T item)
        {
            dbSet.Add(item);
        }

        //public IQueryable<T> GetAll(string includeProperties = "")
        //{
        //    IQueryable<T> query = dbSet;
        //    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }
        //    return query;
        //}

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbSet;


            return query;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
