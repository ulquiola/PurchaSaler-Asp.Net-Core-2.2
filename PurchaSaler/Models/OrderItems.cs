using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Models
{
    public class OrderItems
    {       
        public int OrderItemsID { get; set; }
        public int OrderID { get; set; }
        public int GoodsID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Number { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
