using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Animals;
using exp.Template.Infrastructure.Repositories.Comenzi;
using exp.Template.Infrastructure.Repositories.Discounts;
using exp.Template.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace exp.Template.Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController :ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;
        public DiscountController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var animals = await _discountRepository.GetAllQuerable().Select(x => new DiscountViewModel()
            {
                Id = x.Id,
                NumarComenzi = x.NumarComenzi,
                ProcentDiscount = x.ProcentDiscount,
            }).ToListAsync();

            return Ok(animals);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var discount = await _discountRepository.Get(id);

            if (discount == null)
            {
                return NotFound();
            }

            var discountViewModel = new DiscountViewModel()
            {
                Id = discount.Id,
                NumarComenzi=discount.NumarComenzi,
                ProcentDiscount=discount.ProcentDiscount,
               
            };

            return Ok(discountViewModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] DiscountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discount = new Discount
            {
                NumarComenzi = model.NumarComenzi,
                ProcentDiscount = model.ProcentDiscount
            };

            var createdDiscount = await _discountRepository.Add(discount);

            return CreatedAtAction(nameof(Details), new { id = createdDiscount.Id }, createdDiscount);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DiscountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDiscount = await _discountRepository.Get(id);
            if (existingDiscount == null)
            {
                return NotFound();
            }

            existingDiscount.NumarComenzi = model.NumarComenzi;
            existingDiscount.ProcentDiscount = model.ProcentDiscount;

            await _discountRepository.Update(existingDiscount);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var discount = await _discountRepository.Get(id);
            if (discount == null)
            {
                return NotFound();
            }

            await _discountRepository.Delete(id);

            return NoContent();
        }

    }
}
