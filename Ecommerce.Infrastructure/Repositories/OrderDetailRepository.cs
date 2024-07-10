using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext _db;
        public OrderDetailRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<string> Save(OrderDetail orderDetail)
        {
            await _db.OrderDetails.AddAsync(orderDetail);
            _db.SaveChanges();

            return "added successfully";
        }
    }
}
