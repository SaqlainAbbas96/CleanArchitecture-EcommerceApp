using Ecommerce.Core.DataModels;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IQueryable<ProductDataModel>> GetProducts();
        Task<string> AddProduct(Product model);
        Task<Product> GetProductById(int id);
        Task<string> UpdateProduct(Product model);
        Task<string> DeleteProduct(int id);
    }
}
