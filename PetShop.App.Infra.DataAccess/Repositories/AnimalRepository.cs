using PetShop.App.Domain;
using PetShop.Common.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.Infra.DataAccess.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private ISerializerService serializerService;
        private string token;

        public AnimalRepository(ISerializerService serializerService, string token)
        {
            this.serializerService = serializerService;
            this.token = token;
        }

        public Task CreateAsync(Animal entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Animal> ReadAll()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = httpClient.GetAsync("https://petshop-animalmicroservice-api-sergio.azurewebsites.net/api/animals").Result;

            if (!result.IsSuccessStatusCode)
                return new List<Animal>();

            var serializedAnimals = result.Content.ReadAsStringAsync().Result;
            var animals = serializerService.Deserialize<IEnumerable<Animal>>(serializedAnimals);

            return animals;
        }

        public async Task<IEnumerable<Animal>> ReadAllAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await httpClient.GetAsync("https://petshop-animalmicroservice-api-sergio.azurewebsites.net/api/animals");

            if (!result.IsSuccessStatusCode)
                return new List<Animal>();

            var serializedAnimals = await result.Content.ReadAsStringAsync();
            var animals = serializerService.Deserialize<IEnumerable<Animal>>(serializedAnimals);

            return animals;
        }

        public Task<Animal> ReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Animal entity)
        {
            throw new NotImplementedException();
        }
    }
}
