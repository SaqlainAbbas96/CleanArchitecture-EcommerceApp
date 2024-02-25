using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Mappers;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Repositories;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModelDTO>> GetAllCategories()
        {
            var res = await _categoryRepository.GetCategories();
            var categories = _mapper.Map<IEnumerable<CategoryViewModelDTO>>(res);
            return categories;
        }

        public async Task<string> AddCategory(AddCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            var res = await _categoryRepository.AddCategory(category);
            return res;
        }

        public async Task<UpdateCategoryDTO> GetCategoryById(int id) 
        {
            var res = await _categoryRepository.GetCategoryById(id);
            var category = _mapper.Map<UpdateCategoryDTO>(res);
            return category;
        }

        public async Task<string> UpdateCategory(UpdateCategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            var res = await _categoryRepository.UpdateCategory(category);
            return res;
        }

        public async Task<string> DeleteCategory(int id)
        {
            var res = await _categoryRepository.DeleteCategory(id);
            return res;
        }
    }
}
