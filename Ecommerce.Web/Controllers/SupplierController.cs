using Ecommerce.Application.DTOs;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllSuppliers();
            return View(suppliers);
        }

        [HttpGet]
        public async Task<ActionResult> AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(AddSupplierDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _supplierService.AddSupplier(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierById(id);
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierDTO dto)
        {
            if (ModelState.IsValid)
            {
                var res = await _supplierService.UpdateSupplier(dto);
                if (res == "Successful")
                    return RedirectToAction("Index");
            }
            return View(dto);
        }

        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var res = await _supplierService.DeleteSupplier(id);
            return RedirectToAction("Index");
        }

    }
}
