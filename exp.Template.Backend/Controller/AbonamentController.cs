using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Abonaments;
using exp.Template.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exp.Template.Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonamentController : ControllerBase
    {
        private readonly IAbonamentRepository _abonamentRepository;
        public AbonamentController(IAbonamentRepository abonamentRepository)
        {
            _abonamentRepository = abonamentRepository;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var abonamente = await _abonamentRepository.GetAllQuerable().Select(x => new AbonamentViewModel
            {
                Id = x.Id,
                IdUtilizator = x.IdUtilizator,
                IdHrana = x.IdHrana,
                Frecventa = x.Frecventa,
                DataIncepere = x.DataIncepere,
                DataSfarsit = x.DataSfarsit,
                //comanda
                //hrana si utilizator
            }).ToListAsync();
            return Ok(abonamente);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var abonament = await _abonamentRepository.Get(id);
            if (abonament == null)
            {
                return NotFound();
            }
            var abonamentViewModel = new AbonamentViewModel()
            {
                Id = abonament.Id,
                IdUtilizator = abonament.IdUtilizator,
                IdHrana = abonament.IdHrana,
                Frecventa = abonament.Frecventa,
                DataIncepere = abonament.DataIncepere,
                DataSfarsit = abonament.DataSfarsit,
            };
            return Ok(abonamentViewModel);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AbonamentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var abonament = new Abonament
            {
                IdUtilizator = model.IdUtilizator,
                IdHrana = model.IdHrana,
                Frecventa = model.Frecventa,
                DataIncepere = model.DataIncepere,
                DataSfarsit = model.DataSfarsit
            };

            var createdAbonament = await _abonamentRepository.Add(abonament);

            return CreatedAtAction(nameof(Details), new { id = createdAbonament.Id }, createdAbonament);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AbonamentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAbonament = await _abonamentRepository.Get(id);
            if (existingAbonament == null)
            {
                return NotFound();
            }

            existingAbonament.IdUtilizator = model.IdUtilizator;
            existingAbonament.IdHrana = model.IdHrana;
            existingAbonament.Frecventa = model.Frecventa;
            existingAbonament.DataIncepere = model.DataIncepere;
            existingAbonament.DataSfarsit = model.DataSfarsit;

            await _abonamentRepository.Update(existingAbonament);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var abonament = await _abonamentRepository.Get(id);
            if (abonament == null)
            {
                return NotFound();
            }

            await _abonamentRepository.Delete(id);

            return NoContent();
        }

    }
}
