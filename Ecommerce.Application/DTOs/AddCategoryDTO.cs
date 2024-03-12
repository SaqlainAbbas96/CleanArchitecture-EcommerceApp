namespace Ecommerce.Application.DTOs
{
    public record AddCategoryDTO(
        string? categoryName,
        string? description,
        bool isActive);
}
