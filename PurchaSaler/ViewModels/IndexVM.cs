using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PurchaSaler.Models;

namespace PurchaSaler.ViewModels
{
    public class IndexVM
    {
        

        public string GoodName { get; set; }
        public string ShopName { get; set; }
        public string UserName { get; set; }
        public string GoodPath { get; set; }
        public string GoodDescibe { get; set; }
        public decimal Price { get; set; }
        // public IEnumerable<User> Users { get; set;}
        // public IEnumerable<Shops> Shops { get; set;}
        // public IEnumerable<Goods> Goods { get; set; } 

    }
}