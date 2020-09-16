using PetShop.Common.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AnimalMicroservice.Domain.AggregatesModel.AnimalAggregate
{
    public interface IAnimalRepository : IRepository<Guid, Animal>
    {

    }
}
