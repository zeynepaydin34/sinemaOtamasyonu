using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sinemaOtamasyonu.Data;
using sinemaOtamasyonu.Data.Services;
using sinemaOtamasyonu.Models;

namespace sinemaOtamasyonu.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service=service;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        //Sinema/Ekle
        //veri eklemehttps://www.youtube.com/watch?v=iJGGFZDMU4U&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=68
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        //Sinema/Detay
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Sinema/Edit
        //veri güncellemehttps://www.youtube.com/watch?v=U4YylIXfRe8&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=69
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Sinema/sil
        //veri silme işlemihttps://www.youtube.com/watch?v=kvGh3-e4dEY&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=70
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

