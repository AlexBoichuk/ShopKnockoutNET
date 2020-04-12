using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        private readonly IProductService _productService;


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View(_productService.GetAll().ToList());
        }

        public JsonResult GetProducts()
        {
            return Json(_productService.GetAll().ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _productService.Dispose();
            base.Dispose(disposing);
        }

    }

}