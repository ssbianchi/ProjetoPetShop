using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.Domain
{
    public class AnimalService : IAnimalService
    {
        private IAnimalRepository animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public async Task AddAnimalAsync(Animal animal)
        {
            await animalRepository.CreateAsync(animal);
        }

        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync()
        {
            return await animalRepository.ReadAllAsync();
        }
    }
}
