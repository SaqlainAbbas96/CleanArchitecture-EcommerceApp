using Ecommerce.Application.DTOs;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subCategories = await _subCategoryService.GetAllSubCategories();
            return View(subCategories);
        }

        [HttpGet]
        public async Task<ActionResult> AddSubCategory()
        {
            var categories = await _categoryService.GetAllCategories();

            // Constructing SelectListItems from CategoryDTOs
            var categorySelectListItems = categories.Select(c => new SelectListItem
            {
                Value = c.categoryId.ToString(),
                Text = c.categoryName
            }).ToList();

            ViewBag.CategoryDropdown = new SelectList(categorySelectListItems, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubCategory(AddSubCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _subCategoryService.AddSubCategory(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubCategory(int id)
        {
            var categories = await _categoryService.GetAllCategories();

            // Constructing SelectListItems from CategoryDTOs
            var categorySelectListItems = categories.Select(c => new SelectListItem
            {
                Value = c.categoryId.ToString(),
                Text = c.categoryName
            }).ToList();

            ViewBag.CategoryDropdown = new SelectList(categorySelectListItems, "Value", "Text");

            var subCategory = await _subCategoryService.GetSubCategoryById(id);
            return View(subCategory);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubCategory(UpdateSubCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _subCategoryService.UpdateSubCategory(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var res = await _subCategoryService.DeleteSubCategory(id);
            return RedirectToAction("Index");
        }
    }
}
