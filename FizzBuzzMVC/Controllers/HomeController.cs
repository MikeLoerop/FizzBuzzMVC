using FizzBuzzMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FizzBuzzMVC.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FBPage()
        {
            FizzBuzz model = new();

            model.FizzValue = 3;
            model.BuzzValue = 5;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FBPage(FizzBuzz fizzbuzz)
        {
            List<string> fbItems = new();

            bool fizzBool;
            bool buzzBool;

            for (int i = 1; i <= 100; i++)
            {
                fizzBool = (i % fizzbuzz.FizzValue == 0);
                buzzBool = (i % fizzbuzz.BuzzValue == 0);

                if (fizzBool == true && buzzBool == true)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (fizzBool == true)
                {
                    fbItems.Add("Fizz");
                }
                else if (buzzBool == true)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }


            }

            fizzbuzz.Result = fbItems;

            return View(fizzbuzz);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}