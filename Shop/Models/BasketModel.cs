using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class BasketModel
    {
        public int BasketId { get; set; }
        public List<ProductModel> BasketProducts { get; set; } = new List<ProductModel>();
    }

}