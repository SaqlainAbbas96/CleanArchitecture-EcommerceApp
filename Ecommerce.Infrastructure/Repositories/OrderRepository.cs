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
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<string> Save(Order order)
        {
            await _db.Orders.AddAsync(order);
            _db.SaveChanges();

            return "added successfully";
        }

        public int GetRecentOrderId()
        {
            return _db.Orders
                .OrderByDescending(x => x.orderId)
                .Select(x => x.orderId)
                .FirstOrDefault();
        }
    }
}
