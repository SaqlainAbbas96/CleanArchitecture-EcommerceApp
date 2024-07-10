using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class OrderDetail
    {
        [Key]
        public int orderDetailId { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string? size { get; set; }
        public double discount { get; set; }
    }
}
