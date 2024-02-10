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
        public double retailPrice { get; set; }
        public int quantity { get; set; }
        public string? size { get; set; }
        public double discount { get; set; }
        public double totalAmount { get; set; }
        public DateTime orderDate { get; set; }
    }
}
