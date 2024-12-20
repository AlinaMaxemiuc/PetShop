using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Discounts;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace MVC.Controllers
{
    public class DiscountController : Controller
    {
        private readonly AnimalsFoodContext _context;
        private readonly IDiscountRepository _discountRepository;

        public DiscountController(AnimalsFoodContext context, IDiscountRepository discountRepository)
        {
            _context = context;
            _discountRepository = discountRepository;
        }

        public IActionResult Index()
        {
            var discounts = _context.Discounts.OrderBy(d => d.Id).ToList();
            return View(discounts);
        }

        public IActionResult Details(int id)
        {
            var discount = _context.Discounts.FirstOrDefault(d => d.Id == id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        public IActionResult Create()
        {
            return View(new Discount());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Discount model)
        {
            if (ModelState.IsValid)
            {
                var discount = new Discount()
                {
                    NumarComenzi = model.NumarComenzi,
                    ProcentDiscount = model.ProcentDiscount
                };

                await _discountRepository.Add(discount);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        /*
        public async Task<IActionResult> Edit(int id)
        {
            var discount = await _discountRepository.GetById(id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }
        

        [HttpPost]
        public async Task<IActionResult> Edit(Discount model)
        {
            if (ModelState.IsValid)
            {
                var discount = await _discountRepository.GetById(model.Id);
                if (discount == null)
                {
                    return NotFound();
                }

                discount.NumarComenzi = model.NumarComenzi;
                discount.ProcentDiscount = model.ProcentDiscount;

                await _discountRepository.Update(discount);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        */
    }
}
