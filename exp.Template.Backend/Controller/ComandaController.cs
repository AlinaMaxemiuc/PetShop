using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Comenzi;
using exp.Template.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace exp.Template.Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaRepository _comandaRepository;
        public ComandaController(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var comenzi = await _comandaRepository.GetAllQuerable().Select(x => new ComandaViewModel()
            {
                Id = x.Id,
                IdUtilizator = x.IdUtilizator,
                IdAbonament = x.IdAbonament,
                DataComenzii = x.DataComenzii,
                Total = x.Total,
                Discount = x.Discount,
            }).ToListAsync();
            return Ok(comenzi);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var comanda = await _comandaRepository.Get(id);

            if (comanda == null) { return NotFound(); }
            var comandaViewModel = new ComandaViewModel()
            {
                Id = comanda.Id,
                IdUtilizator = comanda.IdUtilizator,
                IdAbonament = comanda.IdAbonament,
                DataComenzii = comanda.DataComenzii,
                Total = comanda.Total,
                Discount = comanda.Discount,
            };
            return Ok(comandaViewModel);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ComandaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comanda = new Comanda
            {
                IdUtilizator = model.IdUtilizator,
                IdAbonament = model.IdAbonament,
                DataComenzii = model.DataComenzii,
                Total = model.Total,
                Discount = model.Discount
            };

            var createdComanda = await _comandaRepository.Add(comanda);

            return CreatedAtAction(nameof(Details), new { id = createdComanda.Id }, createdComanda);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ComandaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingComanda = await _comandaRepository.Get(id);
            if (existingComanda == null)
            {
                return NotFound();
            }

            existingComanda.IdUtilizator = model.IdUtilizator;
            existingComanda.IdAbonament = model.IdAbonament;
            existingComanda.DataComenzii = model.DataComenzii;
            existingComanda.Total = model.Total;
            existingComanda.Discount = model.Discount;

            await _comandaRepository.Update(existingComanda);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comanda = await _comandaRepository.Get(id);
            if (comanda == null)
            {
                return NotFound();
            }

            await _comandaRepository.Delete(id);

            return NoContent();
        }

    }

}