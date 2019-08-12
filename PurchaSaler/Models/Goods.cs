using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Models
{
    public class Goods
    {
        [Key]
        public int GoodsID { get; set; }
        
        // [Required(ErrorMessage = "请输入商品名")]
        // [RegularExpression(@"^[\\u4e00-\u9fa5_a-zA-Z0-9-\\w]{1,12}$", ErrorMessage = "限12个字符，支持中英文、数字、减号或下划线")]
        public string GoodsName { get; set; }
        // [Required(ErrorMessage = "请输入价格")]
        // [RegularExpression(@"\d+(\.){0,1}\d{0,2}", ErrorMessage = "请输入正确格式")]
        public decimal Price { get; set; }
        // [Required]
        public string GoodsPhoto { get; set; }
        public string GoodsDescribe { get; set; }
        public int LikeIt { get; set; }
        // [Required(ErrorMessage = "*")]
        public int Flag { get; set; }

        public DateTime Time { get; set; }
        // [Required(ErrorMessage = "请输入库存")]
        // [RegularExpression("^[0-9]*[1-9][0-9]*$", ErrorMessage = "只能输入正整数")]
        public int Stock { get; set; }
        public int Sales { get; set; }


        public int ShopID { get; set; }
        public Shops Shops { get; set; }
    }
}
