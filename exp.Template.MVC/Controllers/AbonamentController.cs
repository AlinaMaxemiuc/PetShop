using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Abonaments;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace MVC.Controllers
{
    public class AbonamentController : Controller
    {
        private readonly AnimalsFoodContext _context;
        private readonly IAbonamentRepository _abonamentRepository;

        public AbonamentController(AnimalsFoodContext context, IAbonamentRepository abonamentRepository)
        {
            _context = context;
            _abonamentRepository = abonamentRepository;
        }

        public IActionResult Index()
        {
            var abonamente = _context.Abonaments.OrderBy(a => a.Id).ToList();
            return View(abonamente);
        }

        public IActionResult Details(int id)
        {
            var abonament = _context.Abonaments.FirstOrDefault(a => a.Id == id);
            if (abonament == null)
            {
                return NotFound();
            }
            return View(abonament);
        }

        public IActionResult Create()
        {
            return View(new Abonament());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Abonament model)
        {
            if (ModelState.IsValid)
            {
                var abonament = new Abonament()
                {
                    IdUtilizator = model.IdUtilizator,
                    IdHrana = model.IdHrana,
                    Frecventa = model.Frecventa,
                    DataIncepere = model.DataIncepere,
                    DataSfarsit = model.DataSfarsit
                };

                await _abonamentRepository.Add(abonament);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        /*
        public async Task<IActionResult> Edit(int id)
        {
            var abonament = await _abonamentRepository.GetById(id);
            if (abonament == null)
            {
                return NotFound();
            }

            return View(abonament);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Abonament model)
        {
            if (ModelState.IsValid)
            {
                var abonament = await _abonamentRepository.GetById(model.Id);
                if (abonament == null)
                {
                    return NotFound();
                }

                abonament.IdUtilizator = model.IdUtilizator;
                abonament.IdHrana = model.IdHrana;
                abonament.Frecventa = model.Frecventa;
                abonament.DataIncepere = model.DataIncepere;
                abonament.DataSfarsit = model.DataSfarsit;

                await _abonamentRepository.Update(abonament);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        */
    }
}
