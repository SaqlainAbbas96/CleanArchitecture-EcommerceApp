using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Core.DataModels;
using Ecommerce.Core.Entities;

namespace Ecommerce.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModelDTO>();
            CreateMap<AddCategoryDTO, Category>();
            CreateMap<Category, UpdateCategoryDTO>();
            CreateMap<UpdateCategoryDTO, Category>();

            CreateMap<SubCategoryDataModel, SubCategoryViewModelDTO>();
            CreateMap<AddSubCategoryDTO, SubCategory>();
            CreateMap<SubCategory, UpdateSubCategoryDTO>();
            CreateMap<UpdateSubCategoryDTO, SubCategory>();

            CreateMap<Supplier, SupplierViewModelDTO>();
            CreateMap<AddSupplierDTO, Supplier>();
            CreateMap<Supplier, UpdateSupplierDTO>();
            CreateMap<UpdateSupplierDTO, Supplier>();

            CreateMap<ProductDataModel, ProductViewModelDTO>();
            CreateMap<AddProductDTO, Product>();
            CreateMap<Product, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}
