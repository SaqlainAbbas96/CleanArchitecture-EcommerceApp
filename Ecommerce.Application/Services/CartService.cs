using AutoMapper;
using Ecommerce.Application.DTOs;
using Ecommerce.Application.Extensions;
using Ecommerce.Core.Entities;
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
        private readonly IShippingRepository _shippingRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private const string cartSessionKey = "UserCart";

        public CartService(IHttpContextAccessor httpContextAccessor, ICartRepository cartRepository, IShippingRepository shippingRepository, IPaymentRepository paymentRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartRepository = cartRepository;
            _shippingRepository = shippingRepository;
            _paymentRepository = paymentRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<CartItemDTO>> AddToCart(CartItemDTO dto)
        {
            List<CartItemDTO> cart = new List<CartItemDTO>();
            CartItemDTO cartItem = new CartItemDTO();
            int cartId = 0;

            var session = _httpContextAccessor.HttpContext.Session;
            if (session.Get("Email") != null)
            {
                if (session.Get(cartSessionKey) == null)
                {
                    var product = await _cartRepository.GetProductById(dto.productId);

                    dto.quantity = 1;
                    cart.Add(new CartItemDTO
                    {
                        cartId = 1,
                        productId = dto.productId,
                        productName = product.productName!,
                        retailPrice = product.retailPrice,
                        quantity = dto.quantity,
                        discount = product.discount,
                        subTotal = product.retailPrice
                    });

                    cartItem.productId = dto.productId;
                    cartItem.productName = product.productName!;
                    cartItem.quantity = dto.quantity;
                    cartItem.retailPrice = product.retailPrice;
                    cartItem.discount = product.discount;

                    cartItem.total = Convert.ToInt32(product.retailPrice * cartItem.quantity);

                    double doubleValue = cartItem.total;
                    string stringValue = doubleValue.ToString();
                    session.SetString("total", stringValue);

                    cartItem.total = Convert.ToDouble(session.GetString("total"));

                    //string cartJson = JsonConvert.SerializeObject(cart);
                    //session.SetString(cartSessionKey, cartJson);

                    SessionCustomExtensions.SetObjectAsJson(session, cartSessionKey, cart);

                    session.SetInt32("CartCounter", cart.Count());
                }
                else
                {
                    //var cartJson = _httpContextAccessor.HttpContext.Session.GetString(cartSessionKey);
                    //cart = JsonConvert.DeserializeObject<List<CartItemDTO>>(cartJson);

                    cart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

                    cartId = cart.Count() + 1;

                    var count = cart.Count();
                    var product = await _cartRepository.GetProductById(dto.productId);

                    dto.quantity = 1;
                    dto.subTotal = dto.retailPrice;
                    cart.Add(new CartItemDTO
                    {
                        cartId = cartId,
                        productId = dto.productId,
                        productName = product.productName!,
                        retailPrice = product.retailPrice,
                        quantity = dto.quantity,
                        discount = product.discount,
                        subTotal = product.retailPrice
                    });

                    //session.SetString(cartSessionKey, JsonConvert.SerializeObject(cart));
                    SessionCustomExtensions.SetObjectAsJson(session, cartSessionKey, cart);

                    session.SetInt32("CartCounter", cart.Count());
                }
            }

            return cart;
        }

        public async Task<string> DecreaseQty(int cartId, int productId, int quantity)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            if (session.Get(cartSessionKey) != null)
            {
                var cart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

                var pproduct = await _cartRepository.GetProductById(productId);

                int cartCounter = Convert.ToInt32(session.GetInt32("CartCounter"));

                foreach (var item in cart)
                {
                    if (item.productId == productId)
                    {
                        int prevQty = item.quantity;
                        //string size = item._size;
                        if (prevQty > 0)
                        {
                            quantity = prevQty - 1;

                            cart.Remove(item);

                            CartItemDTO c = new CartItemDTO();
                            c.cartId = cartId;
                            c.productId = productId;
                            c.productName = pproduct.productName!;
                            c.retailPrice = pproduct.retailPrice;
                            c.quantity = quantity;
                            c.discount = pproduct.discount;
                            c.subTotal = Convert.ToInt32(pproduct.retailPrice * quantity);

                            c.total = Convert.ToInt32(pproduct.retailPrice * quantity);
                            //_size = size
                            cart.Add(c);
                        }
                        break;
                    }
                }

                SessionCustomExtensions.SetObjectAsJson(session, cartSessionKey, cart);

                //string cartJson = JsonConvert.SerializeObject(cart);
                //session.SetString(cartSessionKey, cartJson);
            }
            return "quantity updated";
        }

        public async Task<string> IncreaseQty(int cartId, int productId, int quantity)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            if (session.Get(cartSessionKey) != null)
            {
                var cart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);
                var count = cart.Count();

                int cartCounter = Convert.ToInt32(session.GetInt32("CartCounter"));

                var pproduct = await _cartRepository.GetProductById(productId);

                for (int i = 0; i < count; i++)
                {
                    if (cart[i].productId == productId)
                    {
                        int prevQty = cart[i].quantity;
                        //string size = cart[i]._size;
                        quantity = prevQty + 1;

                        cart.Remove(cart[i]);

                        CartItemDTO c = new CartItemDTO();
                        c.cartId = cartId;
                        c.productId = productId;
                        c.productName = pproduct.productName!;
                        c.retailPrice = pproduct.retailPrice;
                        c.discount = pproduct.discount;
                        c.quantity = quantity;
                        c.subTotal = Convert.ToInt32(pproduct.retailPrice * quantity);

                        c.total = Convert.ToInt32(pproduct.retailPrice * quantity);

                        cart.Add(c);
                        //_size = size
                        break;
                    }
                    else
                    {
                        var prd = cart.Where(x => x.productId == productId).SingleOrDefault();
                        if (prd == null)
                        {
                            //string size = cart[i]._size;
                            cart.Add(new CartItemDTO()
                            {
                                cartId = cartId,
                                productId = productId,
                                productName = pproduct.productName!,
                                //retailPrice = pproduct.retailPrice,
                                //subTotal = pproduct.retailPrice,
                                quantity = 1,
                                discount = pproduct.discount,
                                total = Convert.ToInt32(pproduct.retailPrice * quantity),

                                //_size = size
                            });
                        }
                    }
                }

                SessionCustomExtensions.SetObjectAsJson(session, cartSessionKey, cart);

                //string cartJson = JsonConvert.SerializeObject(cart);
                //session.SetString(cartSessionKey, cartJson);

            }
            return "quantity updated";
        }

        public async Task<string> RemoveItem(int cartId)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            
            if (session.Get(cartSessionKey) != null)
            {
                var cart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

                foreach (var item in cart)
                {
                    if (item.cartId == cartId)
                    {
                        cart.Remove(item);
                        break;
                    }
                }

                SessionCustomExtensions.SetObjectAsJson(session, cartSessionKey, cart);

                session.SetInt32("CartCounter", cart.Count());

                //if (cart.Count == 0)
                //{
                //    SessionCustomExtensions.SetObjectAsJson(session, cartSessionKey, null);
                //}
            }

            return "item removed";
        }

        public async Task<string> PlaceOrder(CheckoutViewModelDTO checkoutViewModel, double discount, double deliveryCharges, double totalAmount)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            //var userCart = session.GetString("UserCart");

            var userCart = SessionCustomExtensions.GetObjectFromJson<List<CartItemDTO>>(session, cartSessionKey);

            if (userCart != null)
            {
                var shippingDetail = MapShippingDetails(checkoutViewModel);
                string shippingDetailRes = await AddShippingDetail(shippingDetail);

                if (shippingDetailRes == "added sucessfully")
                {
                    string customerRes = AddCustomer(shippingDetail);

                    if (customerRes == "added successfully")
                    {
                        int userId = Global.userId;
                    }

                    //Add payment
                    string paymentType = await _paymentRepository.FindPaymentType(checkoutViewModel.paymentTypeId);
                    var paymentResponse = await AddPayment(checkoutViewModel.paymentTypeId, paymentType);

                    if (paymentResponse == "added sucessfully")
                    {
                        //Fetch paymentId
                        int paymentId = GetLastPaymentId();

                        //Fetch shippingId
                        int shippingId = GetLastShippingId();

                        string orderNote = checkoutViewModel.notes!;

                        Order order = new Order();
                        order.userId = Global.userId;
                        order.paymentId = paymentId;
                        order.shippingId = shippingId;

                        order.subTotal = totalAmount;
                        order.deliveryCharges = deliveryCharges;
                        order.discount = discount;
                        order.totalAmount = totalAmount;

                        order.isCompleted = true;
                        order.orderDate = DateTime.Now;
                        order.notes = orderNote;

                        //add order to db
                        string orderRes = await _orderRepository.Save(order);

                        //fetch last orderid
                        int orderId = _orderRepository.GetRecentOrderId();

                        if (orderRes == "added successfully")
                        {
                            foreach (var item in userCart)
                            {
                                OrderDetail orderDetail = new OrderDetail();
                                orderDetail.orderId = orderId;
                                orderDetail.productId = item.productId;
                                orderDetail.quantity = item.quantity;
                                orderDetail.price = item.retailPrice;
                                orderDetail.size = null;
                                orderDetail.discount = item.discount;

                                //add order detail to db
                                string orderDetailRes = await _orderDetailRepository.Save(orderDetail);
                            }
                        }
                    }
                }
            }
            return "Thank you for shopping with us!";
        }



        public ShippingDetail MapShippingDetails(CheckoutViewModelDTO checkoutViewModel)
        {
            ShippingDetail shippingDetail = new ShippingDetail();
            shippingDetail.firstName = checkoutViewModel.firstName;
            shippingDetail.lastName = checkoutViewModel.lastName;
            shippingDetail.email = checkoutViewModel.email;
            shippingDetail.mobileNo = checkoutViewModel.mobileNo;
            shippingDetail.address = checkoutViewModel.address;
            shippingDetail.city = checkoutViewModel.city;
            shippingDetail.province = checkoutViewModel.province;
            shippingDetail.country = checkoutViewModel.country;
            shippingDetail.postalCode = checkoutViewModel.postalCode;
            shippingDetail.isActive = checkoutViewModel.isActive;
            return shippingDetail;
        }

        public string AddCustomer(ShippingDetail shippingDetail)
        {
            Customer customer = new Customer();
            customer.firstName = shippingDetail.firstName;
            customer.lastName = shippingDetail.lastName;
            customer.username = shippingDetail.firstName + "." + shippingDetail.lastName;
            customer.email = shippingDetail.email;
            customer.address = shippingDetail.address;
            customer.mobileNo = shippingDetail.mobileNo;
            customer.city = shippingDetail.city;
            customer.state = shippingDetail.province;
            customer.country = shippingDetail.country;
            customer.postalCode = shippingDetail.postalCode;
            customer.isActive = shippingDetail.isActive;

            string res = _customerRepository.AddCustomer(customer);
            return res;
        }

        public async Task<string> AddShippingDetail(ShippingDetail shippingDetail)
        {
            var res = await _shippingRepository.AddShippingDetail(shippingDetail);
            return res;
        }

        public int GetLastShippingId()
        {
            var res = _shippingRepository.GetLastShippingId();
            return res;
        }

        public int GetLastPaymentId()
        {
            var res = _paymentRepository.GetLastPaymentId();
            return res;
        }

        public async Task<string> AddPayment(int paymentTypeId, string paymentType)
        {
            Payment payment = new Payment();
            payment.paymentTypeId = paymentTypeId;
            payment.description = paymentType;
            payment.isActive = false;

            var res = await _paymentRepository.AddPayment(payment);

            return "added sucessfully";
        }
    }
}