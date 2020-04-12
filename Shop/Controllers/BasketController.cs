using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Shop.Models;


namespace Shop.Controllers
{
        public class BasketController : Controller
        {
            private readonly IOrderService _orderService;
            public BasketController(IOrderService orderService)
            {
                _orderService = orderService;
            }

            [HttpPost]
            public ActionResult Add(int productId, int quantity)
            {
                if (ModelState.IsValid)
                {
                    var userId = User.Identity.GetUserId();

                    _orderService.AddProduct(productId, quantity, userId);
                }

                return RedirectToAction("Products", "Home");
            }


        public ActionResult Basket()
        {
            return View();
        }
        public JsonResult GetMyBasket()
            {
                var userId = User.Identity.GetUserId();
                var basket = _orderService.GetBasket(userId);
                var basketProducts = basket.ListProducts;
                var basketList = basketProducts.Select(x => new ProductModel
                {
                        Qty = x.Quantity,
                        Name = x.Product.Name,
                        Total = x.Quantity * x.Product.Price
                }).ToList();
                var basketModel = new
                {
                    BasketId = basket.Id,
                    BasketProducts = basketList
                };

                return Json(basketModel, JsonRequestBehavior.AllowGet);
            }


        [HttpPost]
        public ActionResult Buy(BasketModel basket)
        {
            var userId = User.Identity.GetUserId();
            _orderService.Buy(basket.BasketId, userId);
            return View("EmptyBasket");
        }

        public ActionResult MyOrders()
        {
            return View();
        }

        public JsonResult GetMyOrders()
        {
            var userId = User.Identity.GetUserId();
            List<Order> allOrders = _orderService.GetAllOrders(userId).ToList();
            var orders = allOrders.Select(x => x.ListProducts.Select(p =>  new ProductModel
            {
                Qty = p.Quantity,
                Name = p.Product.Name,
                Total = p.Quantity * p.Product.Price
            })).ToList();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
            {
                _orderService.Dispose();
                base.Dispose(disposing);
            }
        }
    
}