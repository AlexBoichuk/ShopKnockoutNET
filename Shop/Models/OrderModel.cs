﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class OrderModel
    {
        public List<ProductModel> OrderProducts { get; set; } = new List<ProductModel>();
    }
}