using AutoMapper;
using Ecommerce.Application.DTOs;
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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubCategoryViewModelDTO>> GetAllSubCategories()
        {
            var res = await _subCategoryRepository.GetSubCategories();
            var subCategories = _mapper.Map<IEnumerable<SubCategoryViewModelDTO>>(res);
            return subCategories;
        }

        public async Task<string> AddSubCategory(AddSubCategoryDTO dto)
        {
            var subCategory = _mapper.Map<SubCategory>(dto);
            var res = await _subCategoryRepository.AddSubCategory(subCategory);
            return res;
        }

        public async Task<UpdateSubCategoryDTO> GetSubCategoryById(int id)
        {
            var res = await _subCategoryRepository.GetSubCategoryById(id);
            var subCategory = _mapper.Map<UpdateSubCategoryDTO>(res);
            return subCategory;
        }

        public async Task<string> UpdateSubCategory(UpdateSubCategoryDTO dto)
        {
            var subCategory = _mapper.Map<SubCategory>(dto);
            var res = await _subCategoryRepository.UpdateSubCategory(subCategory);
            return res;
        }

        public async Task<string> DeleteSubCategory(int id)
        {
            var res = await _subCategoryRepository.DeleteSubCategory(id);
            return res;
        }
    }
}
