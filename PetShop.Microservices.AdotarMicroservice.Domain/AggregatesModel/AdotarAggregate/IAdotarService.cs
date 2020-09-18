using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate
{
    public interface IAdotarService
    {
        Adotar CreateAdotar(Guid clientId, Guid AnimalId, DateTime dataAdocao);
        Task<bool> ProcessAdotarAsync(Adotar post);
    }
}
