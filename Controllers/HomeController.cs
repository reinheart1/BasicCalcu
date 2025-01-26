using BasicCalcu.Models;
using BasicCalcu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BasicCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double num1, double num2, string operation)
        {
            var calculator = new Calculator();

            try
            {
                double result = calculator.Compute(num1, num2, operation);
                ViewBag.Result = $"Result: {result}";
            }
            catch (DivideByZeroException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"An error occurred: {ex.Message}";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
