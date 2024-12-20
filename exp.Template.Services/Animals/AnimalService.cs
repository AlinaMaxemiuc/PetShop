using exp.Template.Infrastructure.Repositories.Animals;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp.Template.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task DeleteVirtual(int id)
        {
            var animal = await _animalRepository.Get(id);

            if (animal == null)
            {
                throw new KeyNotFoundException("This animal does not exist");
            }

            //animal.IsDeleted = true;

            await _animalRepository.Delete(id);
        }
    }
}
