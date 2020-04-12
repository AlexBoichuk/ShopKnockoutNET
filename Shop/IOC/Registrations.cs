using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Services;
using DAL.UOW;
using Ninject.Modules;

namespace Shop.IOC
{
    public class Registrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}