using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _dbContext;
        public CartRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = _dbContext.Products.Where(x => x.productId == id).FirstOrDefault();
            return product;
        }
    }
}
