using KostRentApp.Data;
using KostRentApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace KostRentApp.Controllers
{
    public class KostController : Controller
    {

        private readonly ILogger<KostController> _logger;
        private readonly MySqlContext _context;
        private readonly IWebHostEnvironment _env;
        public KostController(ILogger<KostController> logger, MySqlContext c, IWebHostEnvironment x)
        {
            _logger = logger;
            _context = c;
            _env = x;
        }

        [Authorize]
        public IActionResult Index()
        {
            var kost = _context.DataKosts.ToList();

            return View(kost);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] DataKost dataKost, IFormFile Photo)
        {
            var filename = "picture_" + dataKost.Name + Path.GetExtension(Photo.FileName);
            var filepath = Path.Combine(_env.WebRootPath, "Upload", filename);

            using (var stream = System.IO.File.Create(filepath))
            {
                Photo.CopyTo(stream);
            }

            dataKost.Photo = filename;

            _context.DataKosts.Add(dataKost);
            _context.SaveChanges();

            return RedirectToAction("Index"); 
        }

        public IActionResult Edit(int Id)
        {
            var kost = _context.DataKosts.FirstOrDefault(x => x.Id == Id);

            return View(kost);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] DataKost kost, IFormFile Photo)
        {
            var filename = "picture_" + kost.Name + Path.GetExtension(Photo.FileName);
            var filepath = Path.Combine(_env.WebRootPath, "Upload", filename);

            using (var stream = System.IO.File.Create(filepath))
            {
                Photo.CopyTo(stream);
            }

            kost.Photo = filename;



            _context.DataKosts.Update(kost);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var kost = _context.DataKosts.FirstOrDefault(x => x.Id == id);

            _context.DataKosts.Remove(kost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
