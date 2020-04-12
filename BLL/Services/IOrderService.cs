using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public interface IOrderService : IDisposable
    {
        IQueryable<Order> GetAllOrders(string userId);
        Order GetBasket(string userId);
        void Buy(int id, string userId);
        void AddProduct(int productId, int quantity, string userId);
    }
}
