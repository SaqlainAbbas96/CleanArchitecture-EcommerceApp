namespace Ecommerce.Application.DTOs
{
    public record SupplierViewModelDTO(
        int supplierId,
        string? supplierName,
        string? companyName,
        string? contactTitle,
        string? Address,
        string email,
        string mobileNo,
        string phoneNo,
        string fax,
        string city,
        string country,
        bool isActive);
}
