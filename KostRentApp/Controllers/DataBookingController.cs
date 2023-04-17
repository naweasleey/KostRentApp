using KostRentApp.Data;
using KostRentApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace KostRentApp.Controllers
{
    [Authorize]
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

        public IActionResult Index()
        {
            var booking = _context.DataBookings.Include(d => d.DataKost).Include(d => d.Stat).ToList();
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

        public IActionResult Create(int Id)
        {
            var kamar = _context.DataKosts.Where(dk => dk.Id == Id).FirstOrDefault();
            return View(kamar);
        }

        [HttpPost]
        public IActionResult Create([FromForm] DataBooking dataBooking,int idKamar)
        {
            var newBooking = new DataBooking
            {
                Name = dataBooking.Name,
                PhoneNumber = dataBooking.PhoneNumber,
                IDCardNumber = dataBooking.IDCardNumber,
                Employment = dataBooking.Employment,
                DataKost = _context.DataKosts.Where(k => k.Id == idKamar).FirstOrDefault(),
                Stat = _context.Stat.Where(s => s.Id == 3).FirstOrDefault()
            };  
            _context.DataBookings.Add(newBooking);
            _context.SaveChanges();

            var getIdKamar = _context.DataKosts.Where(d => d.Id == idKamar).FirstOrDefault();
            getIdKamar.Stat = _context.Stat.Where(s => s.Id == 2).FirstOrDefault();

            _context.DataKosts.Update(getIdKamar);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
