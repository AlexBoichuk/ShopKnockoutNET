using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.UOW;
using Microsoft.AspNet.Identity;


namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        private readonly string _includeProperties = "ListProducts.Product";

        public void AddProduct(int idProduct, int quantity, string userId)
        {
            var orders = _unitOfWork.OrderRepository.GetAll().Where(x => x.IsSubmited == false);
            Order order = orders.FirstOrDefault(x => x.User.Id == userId);
            User user = _unitOfWork.UserRepository.GetAll().FirstOrDefault(x => x.Id == userId);
            if (order == null)
            {
                Order newOrder = new Order();
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = quantity,
                    ProductId = idProduct
                };
                newOrder.ListProducts.Add(orderDetail);
                user.Orders.Add(newOrder);
                _unitOfWork.OrderRepository.Add(newOrder);
                _unitOfWork.Save();
            }
            else
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Quantity = quantity,
                    ProductId = idProduct
                };
                order.ListProducts.Add(orderDetail);
                _unitOfWork.Save();
            }
        }


        public Order GetBasket(string userId)
        {
            var orders = _unitOfWork.OrderRepository.GetAll().Where(x => x.IsSubmited == false).ToList();
            return orders.FirstOrDefault(x => x.User.Id == userId);
        }


        public void Buy(int idOrder, string userId)
        {
            Order order = _unitOfWork.OrderRepository.GetAll().FirstOrDefault(x => x.Id == idOrder);
            order.IsSubmited = true;
            _unitOfWork.Save();
        }


        public IQueryable<Order> GetAllOrders(string userId)
        {
            return _unitOfWork.OrderRepository.GetAll().Where(x => x.User.Id == userId && x.IsSubmited == true);
        }


        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
