using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Animals;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace MVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalsFoodContext _context;
        private readonly IAnimalRepository _animalRepository;
        public AnimalController(AnimalsFoodContext context, IAnimalRepository animalRepository)
        {
            _context = context;
            _animalRepository = animalRepository;
        }

        public IActionResult Index()
        {
            var animals = _context.Animales.OrderBy(a => a.Id).ToList();
            return View(animals);
        }

        public IActionResult Details(int id)
        {
            var animal = _context.Animales.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        public IActionResult Create()
        {
            return View(new Animale());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Animale model)
        {
            if (ModelState.IsValid)
            {
                var animal = new Animale()
                {
                    Gen = model.Gen,
                    Greutate = model.Greutate,
                    Specie = model.Specie,
                    Varsta = model.Varsta,
                };
                await _animalRepository.Add(animal); 

                return RedirectToAction("Index");
            }
            return View(model);
        }
        /*
        public async Task<IActionResult> Edit(int id)
        {
            var animal = await _animalRepository.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Animale model)
        {
            if (ModelState.IsValid)
            {
                var animal = await _animalRepository.GetById(model.Id);
                if (animal == null)
                {
                    return NotFound();
                }

                animal.Gen = model.Gen;
                animal.Specie = model.Specie;
                animal.Varsta = model.Varsta;
                animal.Greutate = model.Greutate;

                await _animalRepository.Update(animal);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        */
    }
}
