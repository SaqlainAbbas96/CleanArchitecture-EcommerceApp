using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierViewModelDTO>> GetAllSuppliers();
        Task<string> AddSupplier(AddSupplierDTO dto);
        Task<UpdateSupplierDTO> GetSupplierById(int id);
        Task<string> UpdateSupplier(UpdateSupplierDTO dto);
        Task<string> DeleteSupplier(int id);
    }
}
