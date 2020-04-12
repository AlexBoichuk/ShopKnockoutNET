using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace DAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        GenericRepository<Product> ProductRepository { get; }
        GenericRepository<Order> OrderRepository { get; }
        GenericRepository<OrderDetail> OrderDetailRepository { get; }
        GenericRepository<User> UserRepository { get; }
    }
}
