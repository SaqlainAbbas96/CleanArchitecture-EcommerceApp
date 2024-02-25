using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public class AddProductDTO
    {
        public string? productName { get; set; }
        public int subCategoryId { get; set; }
        public int supplierId { get; set; }
        public int quantity { get; set; }
        public double listingPrice { get; set; }
        public double retailPrice { get; set; }
        public string? size { get; set; }
        public double discount { get; set; }
        public IFormFile imageUrl { get; set; }
        public string? altText { get; set; }
        public string? description { get; set; }
        public bool isActive { get; set; }
    }
}
