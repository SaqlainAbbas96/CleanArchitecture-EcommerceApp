using Ecommerce.Core.Entities;
using System.Drawing;

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

    public class ProductDetails
    {
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? imageUrl { get; set; }
        public List<string> colour { get; set; }
        public List<string> size { get; set; }
        public double price { get; set; }
    }
}
