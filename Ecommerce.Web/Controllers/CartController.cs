using Ecommerce.Application.DTOs;
using Ecommerce.Application.Services;
using Ecommerce.Core.Entities;
using Ecommerce.Web.Extensions;
using Ecommerce.Web.Filters;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace Ecommerce.Web.Controllers
{
    [RoleAuthorization("Customer")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string cartSessionKey = "UserCart";

        public CartController(ICartService cartService, IPaymentTypeService paymentTypeService, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _paymentTypeService = paymentTypeService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var userCart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

            if (userCart != null)
            {
                ViewBag.userCart = userCart;

                ViewBag.total = session.GetString("total");
                ViewBag.CartCounter = session.GetInt32("CartCounter");

                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItemDTO dto)
        {           
            var res = await _cartService.AddToCart(dto);

            ViewBag.CartCounter = res.Count();

            return RedirectToAction("Index", "Cart");
        }

        public async Task<IActionResult> DecreaseQty(int cartId, int productId, int quantity)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var userCart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

            if (userCart == null)
                return BadRequest("Cart not found");

            var res = await _cartService.DecreaseQty(cartId, productId, quantity);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IncreaseQty(int cartId, int productId, int quantity)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var userCart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

            if (userCart == null)
                return BadRequest("Cart not found");

            var res = await _cartService.IncreaseQty(cartId, productId, quantity);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int cartId) 
        {
            var res = await _cartService.RemoveItem(cartId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Checkout()
        {
            var session = _httpContextAccessor.HttpContext.Session;

            var userCart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

            if (userCart != null)
            {
                var res = await _paymentTypeService.GetPaymentTypes();

                ViewBag.PayMethod = new SelectList(res, "paymentTypeId", "paymentGateway");
                ViewBag.CartCounter = session.GetInt32("CartCounter");

                return View();
            }

            return View("Index", "Cart");
        }

        public async Task<IActionResult> PlaceOrder(CheckoutViewModelDTO checkoutViewModel, double discount, double deliveryCharges, double totalAmount)
        {
            var res = _cartService.PlaceOrder(checkoutViewModel, discount, deliveryCharges, totalAmount);

            ViewBag.OrderMessage = res;

            return View();
        }
    }
}
