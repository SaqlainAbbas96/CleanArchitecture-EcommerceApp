namespace Ecommerce.Application.DTOs
{
    public record UpdateSupplierDTO(
        int supplierId,
        string? supplierName,
        string? companyName,
        string? contactTitle,
        string? address,
        string email,
        string mobileNo,
        string phoneNo,
        string fax,
        string city,
        string country,
        bool isActive);
}
