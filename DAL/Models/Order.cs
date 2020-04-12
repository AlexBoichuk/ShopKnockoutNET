using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual List<OrderDetail> ListProducts { get; set; } = new List<OrderDetail>();
        public bool IsSubmited { get; set; }
        public virtual User User { get; set; }

   
    }
}
