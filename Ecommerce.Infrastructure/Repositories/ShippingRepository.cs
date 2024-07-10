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
    public class ShippingRepository : IShippingRepository
    {
        private readonly AppDbContext _db;
        public ShippingRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddShippingDetail(ShippingDetail model)
        {
            await _db.AddAsync(model);
            _db.SaveChanges();

            return "added sucessfully";
        }

        public int GetLastShippingId()
        {
            int shippingId = _db.ShippingDetails.Max(x => x.shippingId);
            return shippingId;
        }
    }
}
