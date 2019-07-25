using System;

namespace PurchaSaler.Models
{
    public class Good
    {
        public int GoodID { get; set; }
        public Nullable<int> ShopID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string GoodTitle { get; set; }
        public string GoodPhoto { get; set; }
        public string GoodDescribe { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Quality { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}