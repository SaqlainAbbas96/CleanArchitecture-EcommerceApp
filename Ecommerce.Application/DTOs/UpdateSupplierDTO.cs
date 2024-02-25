using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public class UpdateSupplierDTO
    {
        public int supplierId { get; set; }
        public string? supplierName { get; set; }
        public string? companyName { get; set; }
        public string? contactTitle { get; set; }
        public string? address { get; set; }
        public string email { get; set; }
        public string mobileNo { get; set; }
        public string phoneNo { get; set; }
        public string fax { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public bool isActive { get; set; }
    }
}
