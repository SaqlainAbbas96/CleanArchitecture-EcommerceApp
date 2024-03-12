using Microsoft.AspNetCore.Http;

namespace Ecommerce.Application.DTOs
{
    public record AddProductDTO(
        string? productName,
        int subCategoryId,
        int supplierId,
        int quantity,
        double listingPrice,
        double retailPrice,
        string? size,
        double discount,
        IFormFile imageUrl,
        string? altText,
        string? description,
        bool isActive);
}
