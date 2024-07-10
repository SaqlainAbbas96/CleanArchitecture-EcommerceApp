using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository)
        {
            _paymentTypeRepository = paymentTypeRepository;
        }

        public async Task<List<PaymentType>> GetPaymentTypes()
        {
            List<PaymentType> paymentTypes = await _paymentTypeRepository.GetPaymentTypes();
            return paymentTypes;
        }
    }
}
