using KostRentApp.Data;
using KostRentApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace KostRentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly MySqlContext _context; 
        public HomeController(ILogger<HomeController> logger, MySqlContext c)
        {
            _logger = logger;
            _context = c;
        }

        public IActionResult Index(string search)
        {
            var datakost = _context.DataKosts.Include(d => d.Stat).Where(dk => dk.Stat.Stat == "Published").ToList();

            if (!String.IsNullOrEmpty(search))
            {
                datakost = _context.DataKosts.Where(x => x.Address.Contains(search)).ToList();
            }
            return View(datakost);
        }

        public IActionResult Detail(int id)
        {
            DataKost datakost = _context.DataKosts.Where(x => x.Id == id).FirstOrDefault();
            return View(datakost);
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