using Ecommerce.Application.DTOs;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO
            {
                productName = product.productName,
            };
        }
    }
}
