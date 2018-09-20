using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Expression.POC.Models;
using DynamicExpresso;
using System.Globalization;

namespace Expression.POC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Testar(string expr)
        {
            if (string.IsNullOrEmpty(expr))
                throw new ArgumentNullException(nameof(expr));

            var target = new Interpreter();

            try
            {
                var info = target.Eval(expr, CultureInfo.GetCultureInfo("it-IT"));

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
