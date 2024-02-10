using Ecommerce.Application.DTOs;
using Ecommerce.Application.Mappers;
using Ecommerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = _productRepository.GetProducts();
            return products.Select(product => ProductMapper.MapToDTO(product));
        }
    }
}
