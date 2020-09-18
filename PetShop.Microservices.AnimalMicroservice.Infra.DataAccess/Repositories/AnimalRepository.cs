using PetShop.Common.Infra.DataAccess;
using PetShop.Microservices.AnimalMicroservice.Domain.AggregatesModel.AnimalAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AnimalMicroservice.Infra.DataAccess.Repositories
{
    public class AnimalRepository : EntityFrameworkRepositoryBase<Guid, Animal>, IAnimalRepository
    {
    }
}
