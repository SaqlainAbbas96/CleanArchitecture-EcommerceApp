﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public int userId { get; set; }
        public int paymentId { get; set; }
        public int shippingId { get; set; }
        public double subTotal { get; set; }
        public double deliveryCharges { get; set; }
        public double discount { get; set; }
        public double totalAmount { get; set; }
        public DateTime orderDate { get; set; }
        public bool isCompleted { get; set; }
        public bool dispatched { get; set; } = false;
        public DateTime dispatchedDate { get; set; }
        public bool shipped { get; set; } = false;
        public DateTime shippingDate { get; set; }
        public bool deliver { get; set; } = false;
        public DateTime deliverDate { get; set; }
        public string? notes { get; set; }
        public bool cancelOrder { get; set; } = false;
    }
}
