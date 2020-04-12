using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ShopContext _db;
        public UnitOfWork(ShopContext context)
        {
            _db = context;
        }

        private GenericRepository<Product> _productRepository;
        private GenericRepository<Order> _orderRepository;
        private GenericRepository<OrderDetail> _orderDetailRepository;
        private GenericRepository<User> _userRepository;

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new GenericRepository<Product>(_db);
                return _productRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new GenericRepository<Order>(_db);
                return _orderRepository;
            }
        }

        public GenericRepository<OrderDetail> OrderDetailRepository
        {
            get
            {
                if (_orderDetailRepository == null)
                    _orderDetailRepository = new GenericRepository<OrderDetail>(_db);
                return _orderDetailRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new GenericRepository<User>(_db);
                return _userRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
