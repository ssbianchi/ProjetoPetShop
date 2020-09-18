using PetShop.Common.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate
{
    public interface IAdotarRepository : IRepository<Guid, Adotar>
    {

    }
}
