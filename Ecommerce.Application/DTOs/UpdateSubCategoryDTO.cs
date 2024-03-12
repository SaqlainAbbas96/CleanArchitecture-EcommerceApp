namespace Ecommerce.Application.DTOs
{
    public record UpdateSubCategoryDTO(
        int subCategoryId,
        int categoryId,
        string? subCategoryName,
        string? description,
        bool isActive);
}
