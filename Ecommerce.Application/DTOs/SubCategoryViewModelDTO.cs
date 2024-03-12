namespace Ecommerce.Application.DTOs
{
    public record SubCategoryViewModelDTO(
        int subCategoryId,
        string? subCategoryName,
        int categoryId,
        string categoryName,
        string? description,
        bool isActive);
}