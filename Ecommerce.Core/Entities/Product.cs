using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        
        [Length(2, 40)]
        public string? productName { get; set; }
        
        [DeniedValues(0, "0")]
        public int subCategoryId { get; set; }
        public int supplierId { get; set; }
        public int quantity { get; set; }

        [Range(1, 1000, MinimumIsExclusive = true, MaximumIsExclusive = false)]
        public double listingPrice { get; set; }
        public double retailPrice { get; set; }
        [AllowedValues("S", "M", "L", "XL", "XXL")]
        public string? size { get; set; }
        public double discount { get; set; }

        [Base64String]
        public string? imageUrl { get; set; }
        public string? altText { get; set; }
        public string? description { get; set; }
        public bool isActive { get; set; }
    }
}
