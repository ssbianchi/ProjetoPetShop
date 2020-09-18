using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.Domain.Adotar
{
    public class AdotarService : IAdotarService
    {
        private IAdotarRepository adotarRepository;

        public AdotarService(IAdotarRepository adotarRepository)
        {
            this.adotarRepository = adotarRepository;
        }

        public async Task AddAdotarAsync(Adotar adotar)
        {
            await adotarRepository.CreateAsync(adotar);
        }

        public async Task<IEnumerable<Adotar>> GetAllAdotarsAsync()
        {
            return await adotarRepository.ReadAllAsync();
        }
    }
}
