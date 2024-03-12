using Ecommerce.Application.DTOs;
using Ecommerce.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(ICartService cartService, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var session = _httpContextAccessor.HttpContext.Session;

            if (session.GetString("Email") != null)
            {
                var userCart = session.GetString("UserCart");
                if (userCart != null)
                {
                    List<CartItem> cart = JsonConvert.DeserializeObject<List<CartItem>>(userCart);
                    ViewBag.userCart = cart;

                    var total = session.GetString("total");
                    ViewBag.total = total;
                    ViewBag.CartCounter = session.GetInt32("CartCounter");
                    return View();
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItem dto)
        {
            var session = _httpContextAccessor.HttpContext.Session;

            if (session.GetString("Email") != null)
            {
                var res = await _cartService.AddToCart(dto);
                ViewBag.CartCounter = res.Count();
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
