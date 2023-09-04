using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Stripe;
using System.Security.Claims;
using Stripe.Checkout;
using Resturant_RES_MVC_ITI_PRJ.Services;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models.ViewModels;
using Newtonsoft.Json;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StripeSettings _stripeSettings;

        public IEmailSender EmailSender { get; }
        public IOrderRepository OrderRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IDishRepository DishRepository { get; }
        public IOrdersDishesRelRepository OrdersDishesRelRepository { get; }

        public PaymentController(IOptions<StripeSettings> stripeSettings,
            IEmailSender emailSender,
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IDishRepository dishRepository,
            IOrdersDishesRelRepository ordersDishesRelRepository)
        {
            _stripeSettings = stripeSettings.Value;
            EmailSender = emailSender;
            OrderRepository = orderRepository;
            CustomerRepository = customerRepository;
            DishRepository = dishRepository;
            OrdersDishesRelRepository = ordersDishesRelRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCheckoutSession(string OrderDishes)
        {
            var decodedDishes = Uri.UnescapeDataString(OrderDishes);
            var cartVM = JsonConvert.DeserializeObject<CartVM>(decodedDishes);
            var orderNumber = DateTime.Now.ToShortDateString() + " - 1000" + OrderRepository.GetAllOrders().Count + 1;
            var OrderTotalPrice = cartVM.cartDishes.Sum(e => DishRepository.GetDishById(e.DishId).DishPrice * e.Quantity);
            var OrderDescrition = String.Join(" - ", cartVM.cartDishes.Select(d => DishRepository.GetDishById(d.DishId).DishName));
            int id = 0;

            Order o = new Order()
            {
                OrderDate = DateTime.Today,
                OrderState = "Preparing",

                PaymentMethod = (Order.PaymentMethods)cartVM.PaymentMethodID,
                IsPaid = false,
                OrderTypeId = 1,
                CustomerId = CustomerRepository.GetAllCustomers().SingleOrDefault(c => c.CustEmail == User.FindFirst(ClaimTypes.Name)?.Value).CustID,
                FranchiseId = 1,
            };

            OrderRepository.InsertOrder(o, ref id);

            foreach (var dish in cartVM.cartDishes)
            {
                OrdersDishesRelRepository.InsertOrderDishesRel(new OrderDishesRel() { DishId = dish.DishId, OrderId = id, Quantity = dish.Quantity });
            }
            var currency = "usd";
            var successUrl = $"https://localhost:7014/Payment/success?OrderID={id}";
            var cancelUrl = $"https://localhost:7014/Payment/cancel?OrderID={id}";
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = currency,
                            UnitAmount = Convert.ToInt32(OrderTotalPrice) * 100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = orderNumber,
                                Description =OrderDescrition ,
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl
            };
            var routeValues = new RouteValueDictionary(new { OrderID = id });

            var service = new SessionService();
            var session = service.Create(options);
            if ((cartVM.PaymentMethodID == 1))
            {
                return RedirectToAction("success", "Payment", routeValues);
            }
            return Redirect(session.Url);
        }

        public async Task<IActionResult> success(int OrderID)
        {
            var o = OrderRepository.GetOrderById(OrderID);
            if (o.PaymentMethod == Order.PaymentMethods.Visa)
            {
                o.IsPaid = true;
                OrderRepository.UpdateOrder(OrderID, o);
            }
            return View("PaymentSuccess");
        }

        public IActionResult cancel(int OrderID)
        {
            OrderRepository.DeleteOrder(OrderID);

            var routeValues = new RouteValueDictionary(new { area = "Client" });
            return RedirectToAction("Cart", "Order", routeValues);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("PaymentFailed");
        }
    }
}
