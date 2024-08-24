using Hotel_Reservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ModelContext _context;
        public HomeController(ILogger<HomeController> logger, ModelContext context)
        {
            _logger = logger;
            _context = context;
        }



        public async Task<IActionResult> IndexAsync()
        {
            // Retrieve the first record from the homepage_elements table
            var homepageElement = await _context.HomepageElements.FirstOrDefaultAsync();

            // Retrieve all records from the cities table
            var cities = await _context.Cities.ToListAsync();

            // Pass the h1 text and icon class to the layout using ViewBag
            if (homepageElement != null)
            {
                ViewBag.HeaderH1Text = homepageElement.HeaderH1Text;
                ViewBag.HeaderIconClass = homepageElement.HeaderIconClass;
            }

            // Create a tuple to pass both models to the view
            var model = (HomepageElement: homepageElement, Cities: cities);

            return View(model);
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
