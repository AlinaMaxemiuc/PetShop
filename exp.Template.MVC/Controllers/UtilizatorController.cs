using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Animals;
using exp.Template.Infrastructure.Repositories.Users;

using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UtilizatorController : Controller
    {
        private readonly AnimalsFoodContext _context;
        private readonly IUtilizatorRepository _userRepository;
        public UtilizatorController(AnimalsFoodContext context, IUtilizatorRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = _context.Utilizators.OrderBy(a => a.Id).ToList();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            var users = _context.Utilizators.FirstOrDefault(a => a.Id == id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        public IActionResult Create()
        {
            return View(new Utilizator());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Utilizator model)
        {
            if (ModelState.IsValid)
            {
                var user = new Utilizator()
                {
                    Nume = model.Nume,
                    Prenume = model.Prenume,
                    Email = model.Email,
                    Parola = model.Parola,
                };
                await _userRepository.Add(user);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        /*
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Utilizator model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetById(model.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Nume = model.Nume;
                user.Prenume = model.Prenume;
                user.Email = model.Email;
                user.Parola = model.Parola;

                await _userRepository.Update(user);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        */
    }
}
