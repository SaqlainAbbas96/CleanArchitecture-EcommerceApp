using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Repositories;

namespace Ecommerce.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierViewModelDTO>> GetAllSuppliers()
        {
            var res = await _supplierRepository.GetSuppliers();
            var suppliers = _mapper.Map<IEnumerable<SupplierViewModelDTO>>(res);
            return suppliers;
        }

        public async Task<string> AddSupplier(AddSupplierDTO dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);
            var res = await _supplierRepository.AddSupplier(supplier);
            return res;
        }

        public async Task<UpdateSupplierDTO> GetSupplierById(int id)
        {
            var res = await _supplierRepository.GetSupplierById(id);
            var supplier = _mapper.Map<UpdateSupplierDTO>(res);
            return supplier;
        }

        public async Task<string> UpdateSupplier(UpdateSupplierDTO dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);
            var res = await _supplierRepository.UpdateSupplier(supplier);
            return res;
        }

        public async Task<string> DeleteSupplier(int id)
        {
            var res = await _supplierRepository.DeleteSupplier(id);
            return res;
        }

    }
}
