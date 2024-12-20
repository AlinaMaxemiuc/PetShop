using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Comenzi;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace MVC.Controllers
{
    public class ComandaController : Controller
    {
        private readonly AnimalsFoodContext _context;
        private readonly IComandaRepository _comandaRepository;

        public ComandaController(AnimalsFoodContext context, IComandaRepository comandaRepository)
        {
            _context = context;
            _comandaRepository = comandaRepository;
        }

        public IActionResult Index()
        {
            var comenzi = _context.Comandas.OrderBy(c => c.Id).ToList();
            return View(comenzi);
        }

        public IActionResult Details(int id)
        {
            var comanda = _context.Comandas.FirstOrDefault(c => c.Id == id);
            if (comanda == null)
            {
                return NotFound();
            }
            return View(comanda);
        }

        public IActionResult Create()
        {
            return View(new Comanda());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comanda model)
        {
            if (ModelState.IsValid)
            {
                var comanda = new Comanda()
                {
                    IdUtilizator = model.IdUtilizator,
                    IdAbonament = model.IdAbonament,
                    DataComenzii = model.DataComenzii,
                    Total = model.Total,
                    Discount = model.Discount
                };

                await _comandaRepository.Add(comanda);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        /*
        public async Task<IActionResult> Edit(int id)
        {
            var comanda = await _comandaRepository.GetById(id);
            if (comanda == null)
            {
                return NotFound();
            }

            return View(comanda);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Comanda model)
        {
            if (ModelState.IsValid)
            {
                var comanda = await _comandaRepository.GetById(model.Id);
                if (comanda == null)
                {
                    return NotFound();
                }

                comanda.IdUtilizator = model.IdUtilizator;
                comanda.IdAbonament = model.IdAbonament;
                comanda.DataComenzii = model.DataComenzii;
                comanda.Total = model.Total;
                comanda.Discount = model.Discount;

                await _comandaRepository.Update(comanda);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        */
    }
}
