//using Microsoft.AspNetCore.Mvc;

//namespace Restoran.API.Controllers
//{
//    public class PlacanjeController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;

[Route("api/placanje")]
[ApiController]
public class PlacanjeController : ControllerBase
{
    [HttpPost("create-checkout-session")]
    public IActionResult CreateCheckoutSession([FromBody] PlacanjeDto request)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string> { "card" },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.ItemName
                        },
                        UnitAmount = request.Amount * 100
                    },
                    Quantity = 1
                }
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:4200/success",
            CancelUrl = "http://localhost:4200/cancel"
        };

        var service = new SessionService();
        Session session = service.Create(options);

        return Ok(new { sessionId = session.Id });
    }
}

public class PlacanjeDto
{
    public string ItemName { get; set; }
    public int Amount { get; set; }
}
