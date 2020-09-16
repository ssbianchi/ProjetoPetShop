using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Microservices.AnimalMicroservice.Domain.AggregatesModel.AnimalAggregate
{
    public class AnimalService :IAnimalService
    {
        private IAnimalRepository animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            this.animalRepository = animalRepository;
        }

        public Animal CreateAnimal(Guid clientId, string nome, string raca, DateTime dataNascimento, double peso)
        {
            var animal = new Animal
            {
                Id = Guid.NewGuid(),
                ClienteId = clientId,
                Nome =nome,
                Raca = raca,
                DataNascimento = dataNascimento,
                Peso = peso
            };

            return animal;
        }

        public async Task<bool> ProcessAnimalAsync(Animal animal)
        {
            //Verify if animal has not allowed content.
            //return false if it contains not allowed content.

            await animalRepository.CreateAsync(animal);
            return await animalRepository.SaveChangesAsync() > 0;
        }
    }
}
