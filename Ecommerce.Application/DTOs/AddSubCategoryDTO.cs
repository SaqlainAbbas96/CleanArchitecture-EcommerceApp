namespace Ecommerce.Application.DTOs
{
    public record AddSubCategoryDTO(
        int categoryId,
        string? subCategoryName,
        string? description,
        bool isActive);
}
