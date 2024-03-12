using Microsoft.AspNetCore.Http;

namespace Ecommerce.Application.DTOs
{
    public record UpdateProductDTO(
        int productId,
        string? productName,
        int subCategoryId,
        int supplierId,
        int quantity,
        double listingPrice,
        double retailPrice,
        string? size,
        double discount,
        string? imageUrl,
        string? altText,
        string? description,
        bool isActive);
}
