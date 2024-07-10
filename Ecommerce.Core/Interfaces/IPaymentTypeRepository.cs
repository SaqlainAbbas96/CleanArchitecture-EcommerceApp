using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface IPaymentTypeRepository
    {
        Task<List<PaymentType>> GetPaymentTypes();
    }
}
