using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public System.DateTime OrderTime { get; set; }
        public int Amount { get; set; }
        public string ExpressNumber { get; set; }
        public string OrderState { get; set; }
    }
}
