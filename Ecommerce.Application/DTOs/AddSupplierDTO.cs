namespace Ecommerce.Application.DTOs
{
    public record AddSupplierDTO(
         string? supplierName,
         string? companyName,
         string? contactTitle,
         string? address,
         string email,
         string mobileNo,
         string phoneNo,
         string fax,
         bool isActive,
         string city,
         string country);
}