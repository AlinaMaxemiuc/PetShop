using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Animals;
using exp.Template.Infrastructure.Repositories.Foods;
using exp.Template.Models.ViewModels;

using Google.Apis.Upload;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace exp.Template.Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HranaController :ControllerBase
    {
        private readonly IHranaRepository _hranaRepository;
        public HranaController(IHranaRepository hranaRepository)
        {
            _hranaRepository = hranaRepository;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var hrana = await _hranaRepository.GetAllQuerable().Select(x => new HranaViewModel()
            {
                Id = x.Id,
                Nume = x.Nume,
                Descriere = x.Descriere,
                Pret = x.Pret,
                Stoc = x.Stoc,


            }).ToListAsync();
            return Ok(hrana);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var hrana = await _hranaRepository.Get(id);
            if (hrana == null)
            {
                return NotFound();
            }
            var hranaViewModel = new HranaViewModel()
            {
                Id = hrana.Id,
                Nume = hrana.Nume,
                Descriere = hrana.Descriere,
                Pret = hrana.Pret,
                Stoc = hrana.Stoc,
            };
            return Ok(hranaViewModel);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] HranaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hrana = new Hrana
            {
                Nume = model.Nume,
                Descriere = model.Descriere,
                Pret = model.Pret,
                Stoc = model.Stoc
            };

            var createdHrana = await _hranaRepository.Add(hrana);

            return CreatedAtAction(nameof(Details), new { id = createdHrana.Id }, createdHrana);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HranaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingHrana = await _hranaRepository.Get(id);
            if (existingHrana == null)
            {
                return NotFound();
            }

            existingHrana.Nume = model.Nume;
            existingHrana.Descriere = model.Descriere;
            existingHrana.Pret = model.Pret;
            existingHrana.Stoc = model.Stoc;

            await _hranaRepository.Update(existingHrana);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hrana = await _hranaRepository.Get(id);
            if (hrana == null)
            {
                return NotFound();
            }

            await _hranaRepository.Delete(id);

            return NoContent();
        }

    }
}
