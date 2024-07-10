using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface IShippingRepository
    {
        Task<string> AddShippingDetail(ShippingDetail model);

        int GetLastShippingId();

    }
}
