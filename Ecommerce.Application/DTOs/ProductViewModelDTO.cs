namespace Ecommerce.Application.DTOs
{
    public record ProductViewModelDTO(
        int productId,
        string? productName,
        int subCategoryId,
        string? subCategoryName,
        int supplierId,
        string supplierName,
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
