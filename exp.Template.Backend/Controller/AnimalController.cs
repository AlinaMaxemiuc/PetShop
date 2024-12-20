using exp.Template.Infrastructure.Context;
using exp.Template.Infrastructure.Entities;
using exp.Template.Infrastructure.Repositories.Animals;
using exp.Template.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace exp.Template.Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var animals = await _animalRepository.GetAllQuerable().Select(x => new AnimalViewModel()
            {
                Id = x.Id,
                Gen = x.Gen,
                Specie = x.Specie,
                Varsta = x.Varsta,
                Greutate = x.Greutate,
            }).ToListAsync();

            return Ok(animals);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var animal = await _animalRepository.Get(id);

            if (animal == null)
            {
                return NotFound();
            }

            var animalViewModel = new AnimalViewModel()
            {
                Id = animal.Id,
                Gen = animal.Gen,
                Specie = animal.Specie,
                Varsta = animal.Varsta,
                Greutate = animal.Greutate,
            };

            return Ok(animalViewModel);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AnimalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = new Animale
            {
                Gen = model.Gen,
                Specie = model.Specie,
                Varsta = model.Varsta,
                Greutate = model.Greutate
            };

            var createdAnimal = await _animalRepository.Add(animal);

            return CreatedAtAction(nameof(Details), new { id = createdAnimal.Id }, createdAnimal);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AnimalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAnimal = await _animalRepository.Get(id);
            if (existingAnimal == null)
            {
                return NotFound();
            }

            existingAnimal.Gen = model.Gen;
            existingAnimal.Specie = model.Specie;
            existingAnimal.Varsta = model.Varsta;
            existingAnimal.Greutate = model.Greutate;

            await _animalRepository.Update(existingAnimal);

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _animalRepository.Get(id);
            if (animal == null)
            {
                return NotFound();
            }

            await _animalRepository.Delete(id);

            return NoContent();
        }
    }
}
