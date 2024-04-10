using Ecommerce.Application.DTOs;
using Ecommerce.Application.Services;
using Ecommerce.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace Ecommerce.Web.Controllers
{
    [RoleAuthorization("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ISupplierService _supplierService;

        public ProductController(IProductService productService, ISubCategoryService subCategoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _subCategoryService = subCategoryService;
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<ActionResult> AddProduct()
        {
            var subCategories = await _subCategoryService.GetAllSubCategories();
            var suppliers = await _supplierService.GetAllSuppliers();

            var subCategorySelectListItems = subCategories.Select(c => new SelectListItem
            {
                Value = c.subCategoryId.ToString(),
                Text = c.subCategoryName
            }).ToList();

            var supplierSelectListItems = suppliers.Select(c => new SelectListItem
            {
                Value = c.supplierId.ToString(),
                Text = c.supplierName
            }).ToList();

            ViewBag.SubCategoryDropdown = new SelectList(subCategorySelectListItems, "Value", "Text");
            ViewBag.SupplierDropdown = new SelectList(supplierSelectListItems, "Value", "Text");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _productService.AddProduct(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var subCategories = await _subCategoryService.GetAllSubCategories();
            var suppliers = await _supplierService.GetAllSuppliers();

            var subCategorySelectListItems = subCategories.Select(c => new SelectListItem
            {
                Value = c.subCategoryId.ToString(),
                Text = c.subCategoryName
            }).ToList();

            var supplierSelectListItems = suppliers.Select(c => new SelectListItem
            {
                Value = c.supplierId.ToString(),
                Text = c.supplierName
            }).ToList();

            ViewBag.SubCategoryDropdown = new SelectList(subCategorySelectListItems, "Value", "Text");
            ViewBag.SupplierDropdown = new SelectList(supplierSelectListItems, "Value", "Text");

            var product = await _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _productService.UpdateProduct(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var res = await _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ProductDetails(int productId)
        {
            //ViewBag.ProductDetail

            var productDetails = _productService.GetProductDetails(productId);

            if (productDetails != null)
            {
                var res = await _productService.GetCategoryWiseProduct(productId);
                if (res != null)
                {
                    ViewBag.categoryWiseProduct = res;
                }
                return View(productDetails);
            }

            //Temp
            return View("Index", "Home");
        }
    }
}
