using Ecommerce.Application.DTOs;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.Application.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICartRepository _cartRepository;
        private const string cartSessionKey = "UserCart";

        public CartService(IHttpContextAccessor httpContextAccessor, ICartRepository cartRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartRepository = cartRepository;
        }

        public async Task<List<CartItem>> AddToCart(CartItem dto)
        {
            List<CartItem> cart = new List<CartItem>();
            CartItem cartItem = new CartItem();
            int cartCounter = 0;

            var session = _httpContextAccessor.HttpContext.Session;
            if (session.Get("Email") != null)
            {
                if (session.Get(cartSessionKey) == null)
                {
                    var product = await _cartRepository.GetProductById(dto.productId);

                    // If the product is not in the cart, add it as a new item
                    dto.quantity = 1;
                    cart.Add(new CartItem
                    {
                        cartId = 1,
                        productId = dto.productId,
                        productName = product.productName!,
                        retailPrice = product.retailPrice,
                        quantity = dto.quantity,
                        lineTotal = product.retailPrice
                    });

                    cartItem.productId = dto.productId;
                    cartItem.productName = product.productName!;
                    cartItem.quantity = dto.quantity;
                    cartItem.shipping = 50;                 //deliveryCharges;
                    cartItem.bill = Convert.ToInt32(product.retailPrice * cartItem.quantity);
                    cartItem.bill = cartItem.bill + cartItem.shipping;

                    // Storing a double value in session
                    double doubleValue = cartItem.bill;
                    string stringValue = doubleValue.ToString();
                    session.SetString("total", stringValue);

                    cartItem.bill = Convert.ToDouble(session.GetString("total"));

                    string cartJson = JsonConvert.SerializeObject(cart);
                    session.SetString(cartSessionKey, cartJson);

                    session.SetInt32("CartCounter", cart.Count());
                }
                else
                {
                    var cartJson = _httpContextAccessor.HttpContext.Session.GetString(cartSessionKey);
                    cart = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);

                    cartCounter = cart.LastOrDefault().cartId + 1;

                    var count = cart.Count();
                    var product = await _cartRepository.GetProductById(dto.productId);

                    dto.quantity = 1;
                    dto.lineTotal = dto.retailPrice;
                    cart.Add(new CartItem
                    {
                        cartId = cartCounter,
                        productId = dto.productId,
                        productName = product.productName!,
                        retailPrice = product.retailPrice,
                        quantity = dto.quantity,
                        lineTotal = product.retailPrice
                    });
                    session.SetString(cartSessionKey, JsonConvert.SerializeObject(cart));
                    session.SetInt32("CartCounter", cart.Count());
                }
            }

            return cart;
        }

    }
}