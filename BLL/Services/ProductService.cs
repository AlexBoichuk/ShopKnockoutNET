using DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Services
{
    public class ProductService : IProductService, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public IQueryable<Product> GetAll()
        {
            return _unitOfWork.ProductRepository.GetAll();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
