using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Users;
using exp.Template.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace exp.Template.Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        private readonly IUtilizatorRepository _utilizatorRepository;
        public UtilizatorController(IUtilizatorRepository utilizatorRepository)
        {
            _utilizatorRepository = utilizatorRepository;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var utilizatori = await _utilizatorRepository.GetAllQuerable().Select(x => new UtilizatorViewModel()
            {
                Id = x.Id,
                Nume = x.Nume,
                Prenume = x.Prenume,
                Email = x.Email,
                Parola = x.Parola,
            }).ToListAsync();

            return Ok(utilizatori);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var utilizator = await _utilizatorRepository.Get(id);

            if (utilizator == null)
            {
                return NotFound();
            }

            var utilizatorViewModel = new UtilizatorViewModel()
            {
                Id = utilizator.Id,
                Nume = utilizator.Nume,
                Prenume = utilizator.Prenume,
                Email = utilizator.Email,
                Parola = utilizator.Parola,
            };

            return Ok(utilizatorViewModel);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UtilizatorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var utilizator = new Utilizator
            {
                Nume = model.Nume,
                Prenume = model.Prenume,
                Email = model.Email,
                Parola = model.Parola
            };

            var createdUtilizator = await _utilizatorRepository.Add(utilizator);

            return CreatedAtAction(nameof(Details), new { id = createdUtilizator.Id }, createdUtilizator);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UtilizatorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUtilizator = await _utilizatorRepository.Get(id);
            if (existingUtilizator == null)
            {
                return NotFound();
            }

            existingUtilizator.Nume = model.Nume;
            existingUtilizator.Prenume = model.Prenume;
            existingUtilizator.Email = model.Email;
            existingUtilizator.Parola = model.Parola;

            await _utilizatorRepository.Update(existingUtilizator);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var utilizator = await _utilizatorRepository.Get(id);
            if (utilizator == null)
            {
                return NotFound();
            }

            await _utilizatorRepository.Delete(id);

            return NoContent();
        }
    
    }
}
