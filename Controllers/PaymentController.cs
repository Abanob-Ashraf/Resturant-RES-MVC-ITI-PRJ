using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Stripe;

using Stripe.Checkout;
using Resturant_RES_MVC_ITI_PRJ.Models;
using System.Diagnostics;
using Resturant_RES_MVC_ITI_PRJ.Services;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class PaymentController : Controller
    {

        private readonly StripeSettings _stripeSettings;

        public IEmailSender EmailSender { get; }

        public PaymentController(IOptions<StripeSettings> stripeSettings, IEmailSender emailSender)
        {
            _stripeSettings = stripeSettings.Value;
            EmailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CreateCheckoutSession(string amount)
        {

            var currency = "usd"; // Currency code
            var successUrl = "https://localhost:7014/Payment/success";
            var cancelUrl = "https://localhost:7014/Payment/cancel";
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
                            UnitAmount = Convert.ToInt32(amount) * 100,  // Amount in smallest currency unit (e.g., cents)
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Order 2",
                                Description = "1 'fish' Dish  2 'hawawshy' dishes"
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
