using KostRentApp.Data;
using KostRentApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;


namespace KostRentApp.Controllers
{
    public class DataBookingController : Controller
    {
        private readonly ILogger<DataBookingController> _logger;
        private readonly MySqlContext _context;
        private readonly IWebHostEnvironment _env;

        public DataBookingController(ILogger<DataBookingController> logger, MySqlContext c, IWebHostEnvironment x)
        {
            _logger = logger;
            _context = c;
            _env = x;
        }

        [Authorize]
        public IActionResult Index()
        {
            var booking = _context.DataBookings.ToList();
            return View(booking);
        }


        public IActionResult Edit(int Id)
        {
            var booking = _context.DataBookings.FirstOrDefault(x => x.Id == Id);

            return View(booking);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] DataBooking booking)
        {

            _context.DataBookings.Update(booking);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var booking = _context.DataBookings.FirstOrDefault(x => x.Id == id);

            _context.DataBookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] DataBooking dataBooking)
        {

            _context.DataBookings.Add(dataBooking);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }





    }
}
