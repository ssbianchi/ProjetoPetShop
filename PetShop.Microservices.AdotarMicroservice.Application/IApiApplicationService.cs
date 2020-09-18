using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Microservices.AdotarMicroservice.Application
{
    public interface IApiApplicationService
    {
        Task CreateAdotarAsync(Guid clientId, Guid animalId, DateTime dataAdocao);
    }
}
