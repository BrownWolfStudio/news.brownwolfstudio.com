using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BrownNews.Services;
using BrownNews.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrownNews.Controllers
{
    public class TestController : Controller
    {
        private readonly IPayPalService _payPalService;
        public TestController(IPayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        [Route("/payment/test")]
        public IActionResult Index()
        {
            var model = new PayPalTestViewModel();
            return View(model);
        }

        [Route("/paypal/test")]
        public async Task<IActionResult> PayPalTest(PayPalTestViewModel model)
        {
            try
            {
                var redirectUrl = await _payPalService.ProcessPayment(model);
                
                if (redirectUrl == null)
                {
                    // Didn't find an approval_url in response.Links
                    return new JsonResult(new { Message = "Failed to find an approval_url in the response!" });
                }
                else
                {
                    return Redirect(redirectUrl);
                }
            }
            catch (BraintreeHttp.HttpException ex)
            {
                HttpStatusCode statusCode = ex.StatusCode;
                var debugId = ex.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                return new JsonResult(new { Message = "Request failed!  HTTP response code was " + statusCode + ", debug ID was " + debugId });
            }
        }

        [HttpGet("/payment/done/{amt}")]
        public IActionResult Done(string amt)
        {
            return View(model: amt);
        }

        [HttpGet("/payment/cancel/{amt}")]
        public IActionResult Cancel(string amt)
        {
            return View(model: amt);
        }
    }
}