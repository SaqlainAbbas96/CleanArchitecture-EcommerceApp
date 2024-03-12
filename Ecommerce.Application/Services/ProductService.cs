using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModelDTO>> GetProducts()
        {
            var res = await _productRepository.GetProducts();
            var products = _mapper.Map<IEnumerable<ProductViewModelDTO>>(res);
            return products;
        }
        public async Task<string> AddProduct(AddProductDTO dto)
        {
            var res = "";

            if (dto.imageUrl != null && dto.imageUrl.Length > 0)
            {
                string _folderPath = "wwwroot/images/";
                // Generate a unique filename for the uploaded image
                string fileName = Path.GetFileName(dto.imageUrl.FileName);
                string _fileName = DateTime.Now.ToString("yymmssfff") + fileName;
                string extension = Path.GetExtension(dto.imageUrl.FileName);

                // Combine the folder path with the generated filename
                string filePath = Path.Combine(_folderPath, fileName);

                string imageUrl = "wwwroot/images/" + _fileName;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {
                    //Mapping Dto to Model
                    Product product = new Product
                    {

                        productName = dto.productName,
                        subCategoryId = dto.subCategoryId,
                        supplierId = dto.supplierId,
                        quantity = dto.quantity,
                        listingPrice = dto.listingPrice,
                        retailPrice = dto.retailPrice,
                        size = dto.size,
                        discount = dto.discount,
                        imageUrl = imageUrl,
                        altText = dto.altText,
                        description = dto.description,
                        isActive = dto.isActive
                    };
                    res = await _productRepository.AddProduct(product);

                    if (res == "Successful")
                    {
                        // Save the uploaded file to the specified path
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await dto.imageUrl.CopyToAsync(fileStream);
                        }
                    }
                }
                return res;
            }
            else
            {

                string imageUrl = "wwwroot/images/notfound.png";

                //Mapping Dto to Model
                Product product = new Product
                {

                    productName = dto.productName,
                    subCategoryId = dto.subCategoryId,
                    supplierId = dto.supplierId,
                    quantity = dto.quantity,
                    listingPrice = dto.listingPrice,
                    retailPrice = dto.retailPrice,
                    size = dto.size,
                    discount = dto.discount,
                    imageUrl = imageUrl,
                    altText = dto.altText,
                    description = dto.description,
                    isActive = dto.isActive
                };

                res = await _productRepository.AddProduct(product);
                return res;
            }
        }

        public async Task<UpdateProductDTO> GetProductById(int id)
        {
            var res = await _productRepository.GetProductById(id);

            //UpdateProductDTO updateProductDTO = new UpdateProductDTO
            //{
            //    productName = res.productName,
            //    subCategoryId = res.subCategoryId,
            //    supplierId = res.supplierId,
            //    quantity = res.quantity,
            //    listingPrice = res.listingPrice,
            //    retailPrice = res.retailPrice,
            //    size = res.size,
            //    discount = res.discount,
            //    imageUrl = res.imageUrl,
            //    altText = res.altText,
            //    description = res.description,
            //    isActive = res.isActive
            //};

            var product = _mapper.Map<UpdateProductDTO>(res);
            return product;
        }

 
        public async Task<string> DeleteProduct(int id)
        {
            var res = await _productRepository.DeleteProduct(id);
            return res;
        }

        public async Task<string> UpdateProduct(UpdateProductDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
