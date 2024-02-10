using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? username { get; set; }
        public string? gender { get; set; }
        public string? address { get; set; }
        public string? email { get; set; }
        public string? mobileNo { get; set; }
        public string? alternateMobileNo { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public string? postalCode { get; set; }
        public bool isActive { get; set; }
    }
}
