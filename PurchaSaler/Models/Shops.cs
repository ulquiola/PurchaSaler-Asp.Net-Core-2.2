using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PurchaSaler.Models
{
    public class Shops
    {
        [Key]
        public int ShopID { get; set; }

        // [Required(ErrorMessage = "请输入商店名")]
        // [RegularExpression(@"^[\\u4e00-\u9fa5_a-zA-Z0-9-\\w]{1,12}$", ErrorMessage = "限12个字符")]
        public string ShopName { get; set; }
        public string ShopDescription { get; set; }
        public Nullable<int> SalesTotal { get; set; }
        //[Required]
        public string ShopPhoto { get; set; }
        //[Required]
        public string TopImage { get; set; }

        public string UserID { get; set; }
        public User Users { get; set; }
    }
}