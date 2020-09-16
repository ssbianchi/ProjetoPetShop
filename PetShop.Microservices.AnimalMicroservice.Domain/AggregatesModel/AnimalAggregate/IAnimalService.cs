using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Microservices.AnimalMicroservice.Domain.AggregatesModel.AnimalAggregate
{
    public interface IAnimalService
    {
        Animal CreateAnimal(Guid clientId, string nome, string raca, DateTime dataNascimento, double peso);
        Task<bool> ProcessAnimalAsync(Animal post);
    }
}
