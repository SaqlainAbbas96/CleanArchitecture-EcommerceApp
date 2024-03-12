namespace Ecommerce.Application.DTOs
{
    public record UpdateCategoryDTO(
        int categoryId,
        string? categoryName,
        string? description,
        bool isActive);
}
