using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Models
{
    public class GoodsComments
    {
        public int GoodsCommentID { get; set; }
        public int UserID { get; set; }
        public int GoodsID { get; set; }
        public string GoodsCommentContent { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
