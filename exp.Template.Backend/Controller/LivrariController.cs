using exp.Template.Backend.Entities;
using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Discounts;
using exp.Template.Infrastructure.Repositories.Livrarii;
using exp.Template.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Livrari = exp.Template.Infrastructure.Entities.Livrari;
namespace exp.Template.Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariController : ControllerBase
    {
        private readonly ILivrariRepository _livrariRepository;
        public LivrariController(ILivrariRepository livrariRepository)
        {
            _livrariRepository = livrariRepository;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var livrari = await _livrariRepository.GetAllQuerable().Select(x => new LivrareViewModel()
            {
                Id = x.Id,
                IdComanda = x.IdComanda,
                DataLivrare = x.DataLivrare,
                AdresaLivrare = x.AdresaLivrare,
            }).ToListAsync();

            return Ok(livrari);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var livrare = await _livrariRepository.Get(id);

            if (livrare == null)
            {
                return NotFound();
            }

            var livrareViewModel = new LivrareViewModel()
            {
                Id = livrare.Id,
                IdComanda = livrare.IdComanda,
                DataLivrare = livrare.DataLivrare,
                AdresaLivrare = livrare.AdresaLivrare,

            };

            return Ok(livrareViewModel);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] LivrareViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livrare = new Livrari
            {
                IdComanda = model.IdComanda,
                DataLivrare = model.DataLivrare,
                AdresaLivrare = model.AdresaLivrare
            };

            var createdLivrare = await _livrariRepository.Add(livrare);

            return CreatedAtAction(nameof(Details), new { id = createdLivrare.Id }, createdLivrare);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LivrareViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingLivrare = await _livrariRepository.Get(id);
            if (existingLivrare == null)
            {
                return NotFound();
            }

            existingLivrare.IdComanda = model.IdComanda;
            existingLivrare.DataLivrare = model.DataLivrare;
            existingLivrare.AdresaLivrare = model.AdresaLivrare;

            await _livrariRepository.Update(existingLivrare);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livrare = await _livrariRepository.Get(id);
            if (livrare == null)
            {
                return NotFound();
            }

            await _livrariRepository.Delete(id);

            return NoContent();
        }
    
    }
}
