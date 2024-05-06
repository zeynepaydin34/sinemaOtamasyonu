using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sinemaOtamasyonu.Data;
using sinemaOtamasyonu.Data.Services;
using sinemaOtamasyonu.Models;

namespace sinemaOtamasyonu.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();
            return View(allActors);
        }

        //Oyuncu/Ekle
        //veri eklemehttps://www.youtube.com/watch?v=iJGGFZDMU4U&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=68
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Oyuncu/Detay
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Oyuncu/Edit
        //verigüncellemehttps://www.youtube.com/watch?v=U4YylIXfRe8&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=69
        public async Task <IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        //Oyuncu/Sil
        //veri silme işlemihttps://www.youtube.com/watch?v=kvGh3-e4dEY&list=PLKnjBHu2xXNOld1njNVQ5fk0e12oqiWc8&index=70
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
           
            return RedirectToAction(nameof(Index));
        }
    }
}
