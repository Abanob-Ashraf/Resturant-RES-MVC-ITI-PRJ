using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Stripe;

using Stripe.Checkout;
using Resturant_RES_MVC_ITI_PRJ.Models;
using System.Diagnostics;
using Resturant_RES_MVC_ITI_PRJ.Services;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class PaymentController : Controller
    {

        private readonly StripeSettings _stripeSettings;

        public IEmailSender EmailSender { get; }
        public IOrderRepository OrderRepository { get; }

        public PaymentController(IOptions<StripeSettings> stripeSettings, IEmailSender emailSender, IOrderRepository orderRepository)
        {
            _stripeSettings = stripeSettings.Value;
            EmailSender = emailSender;
            OrderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateCheckoutSession(string amount, string desc, string orderName)
        {

            int id = 0;
            Order o = new Order()
            {
                OrderDate = DateTime.Now,
                OrderState = "OUT",
                PaymentMethod = Order.PaymentMethods.Cash,
                IsPaid = false,
                OrderTypeId = 1,
                CustomerId = 1,
                FranchiseId = 1,

            };

            OrderRepository.InsertOrder(o, ref id);

            var currency = "usd"; // Currency code
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
                            UnitAmount = Convert.ToInt32(amount) * 100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = orderName,
                                Description = desc,
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl
            };

            var service = new SessionService();
            var session = service.Create(options);

            return Redirect(session.Url);
        }

        public async Task<IActionResult> success()
        {
            return View("PaymentSuccess");
        }

        public IActionResult cancel()
        {
            return View("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("PaymentFailed");
        }
    }
}
