﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User : IdentityUser
    {
        public virtual List<Order> Orders { get; set; }
        public User()
        {
            Orders = new List<Order>();
        }
    }
}
