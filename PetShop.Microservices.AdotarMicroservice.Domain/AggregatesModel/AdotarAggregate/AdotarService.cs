using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate
{
    public class AdotarService : IAdotarService
    {
        private IAdotarRepository adotarRepository;

        public AdotarService(IAdotarRepository adotarRepository)
        {
            this.adotarRepository = adotarRepository;
        }

        public Adotar CreateAdotar(Guid clientId, Guid animalId, DateTime dataAdocao)
        {
            var adotar = new Adotar
            {
                Id = Guid.NewGuid(),
                ClienteId = clientId,
                AnimalId = animalId,
                DataAdocao = dataAdocao
            };

            return adotar;
        }

        public async Task<bool> ProcessAdotarAsync(Adotar adotar)
        {
            await adotarRepository.CreateAsync(adotar);
            return await adotarRepository.SaveChangesAsync() > 0;
        }
    
    }
}
