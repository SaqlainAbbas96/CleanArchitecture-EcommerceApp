namespace Ecommerce.Application.DTOs
{
    public record CategoryViewModelDTO(
        int categoryId,
        string? categoryName,
        string? description,
        bool isActive);
}
