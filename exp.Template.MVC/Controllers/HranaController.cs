using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Foods;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace MVC.Controllers
{
    public class HranaController : Controller
    {
        private readonly AnimalsFoodContext _context;
        private readonly IHranaRepository _hranaRepository;

        public HranaController(AnimalsFoodContext context, IHranaRepository hranaRepository)
        {
            _context = context;
            _hranaRepository = hranaRepository;
        }

        public IActionResult Index()
        {
            var hrane = _context.Hranas.OrderBy(h => h.Id).ToList();
            return View(hrane);
        }

        public IActionResult Details(int id)
        {
            var hrana = _context.Hranas.FirstOrDefault(h => h.Id == id);
            if (hrana == null)
            {
                return NotFound();
            }
            return View(hrana);
        }

        public IActionResult Create()
        {
            return View(new Hrana());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Hrana model)
        {
            if (ModelState.IsValid)
            {
                var hrana = new Hrana()
                {
                    Nume = model.Nume,
                    Descriere = model.Descriere,
                    Pret = model.Pret,
                    Stoc = model.Stoc
                };

                await _hranaRepository.Add(hrana);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        /*
        public async Task<IActionResult> Edit(int id)
        {
            var hrana = await _hranaRepository.GetById(id);
            if (hrana == null)
            {
                return NotFound();
            }

            return View(hrana);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Hrana model)
        {
            if (ModelState.IsValid)
            {
                var hrana = await _hranaRepository.GetById(model.Id);
                if (hrana == null)
                {
                    return NotFound();
                }

                hrana.Nume = model.Nume;
                hrana.Descriere = model.Descriere;
                hrana.Pret = model.Pret;
                hrana.Stoc = model.Stoc;

                await _hranaRepository.Update(hrana);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        */
    }
}
