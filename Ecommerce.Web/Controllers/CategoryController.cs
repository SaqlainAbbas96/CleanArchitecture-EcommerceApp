using Ecommerce.Application.DTOs;
using Ecommerce.Application.Services;
using Ecommerce.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    [RoleAuthorization("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryController(ICategoryService categoryService, IHttpContextAccessor httpContextAccessor)
        {
            _categoryService = categoryService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public async Task<ActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _categoryService.AddCategory(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _categoryService.UpdateCategory(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var res = await _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}
