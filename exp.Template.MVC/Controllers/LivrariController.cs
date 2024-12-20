using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Livrarii;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace MVC.Controllers
{
    public class LivrariController : Controller
    {
        private readonly AnimalsFoodContext _context;
        private readonly ILivrariRepository _livrariRepository;

        public LivrariController(AnimalsFoodContext context, ILivrariRepository livrariRepository)
        {
            _context = context;
            _livrariRepository = livrariRepository;
        }

        public IActionResult Index()
        {
            var livrari = _context.Livraris.OrderBy(l => l.Id).ToList();
            return View(livrari);
        }

        public IActionResult Details(int id)
        {
            var livrare = _context.Livraris.FirstOrDefault(l => l.Id == id);
            if (livrare == null)
            {
                return NotFound();
            }
            return View(livrare);
        }

        public IActionResult Create()
        {
            return View(new Livrari());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Livrari model)
        {
            if (ModelState.IsValid)
            {
                var livrare = new Livrari()
                {
                    IdComanda = model.IdComanda,
                    DataLivrare = model.DataLivrare,
                    AdresaLivrare = model.AdresaLivrare
                };

                await _livrariRepository.Add(livrare);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        /*
        public async Task<IActionResult> Edit(int id)
        {
            var livrare = await _livrariRepository.GetById(id);
            if (livrare == null)
            {
                return NotFound();
            }

            return View(livrare);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Livrari model)
        {
            if (ModelState.IsValid)
            {
                var livrare = await _livrariRepository.GetById(model.Id);
                if (livrare == null)
                {
                    return NotFound();
                }

                livrare.IdComanda = model.IdComanda;
                livrare.DataLivrare = model.DataLivrare;
                livrare.AdresaLivrare = model.AdresaLivrare;

                await _livrariRepository.Update(livrare);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        */
    }
}
