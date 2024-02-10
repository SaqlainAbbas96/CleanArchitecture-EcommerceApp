using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class PaymentType
    {
        [Key]
        public int paymentTypeId { get; set; }
        public string? paymentGateway { get; set; }
        public string? description { get; set; }
        public bool isActive { get; set; }
    }
}
