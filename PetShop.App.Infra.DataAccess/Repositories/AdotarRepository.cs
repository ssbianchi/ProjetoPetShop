using PetShop.App.Domain.Adotar;
using PetShop.Common.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.Infra.DataAccess.Repositories
{
    public class AdotarRepository : IAdotarRepository
    {
        private ISerializerService serializerService;
        private string token;

        public AdotarRepository(ISerializerService serializerService, string token)
        {
            this.serializerService = serializerService;
            this.token = token;
        }

        public async Task CreateAsync(Adotar entity)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            var serializedAdotar = serializerService.Serialize(entity);
            var httpContent = new StringContent(serializedAdotar, Encoding.UTF8, "application/json");

            await httpClient.PostAsync("https://petshop-adotarmicroservice-api-sergio.azurewebsites.net/api/Adotars", httpContent);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Adotar> ReadAll()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = httpClient.GetAsync("https://petshop-adotarmicroservice-api-sergio.azurewebsites.net/api/Adotars").Result;

            if (!result.IsSuccessStatusCode)
                return new List<Adotar>();

            var serializedAdotars = result.Content.ReadAsStringAsync().Result;
            var Adotars = serializerService.Deserialize<IEnumerable<Adotar>>(serializedAdotars);

            return Adotars;
        }

        public async Task<IEnumerable<Adotar>> ReadAllAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = await httpClient.GetAsync("https://petshop-adotarmicroservice-api-sergio.azurewebsites.net/api/Adotars");

            if (!result.IsSuccessStatusCode)
                return new List<Adotar>();

            var serializedAdotars = await result.Content.ReadAsStringAsync();
            var Adotars = serializerService.Deserialize<IEnumerable<Adotar>>(serializedAdotars);

            return Adotars;
        }

        public Task<Adotar> ReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async void Update(Adotar entity)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);

            var serializedAdotar = serializerService.Serialize(entity);
            var httpContent = new StringContent(serializedAdotar, Encoding.UTF8, "application/json");

            await httpClient.PutAsync("https://petshop-adotarmicroservice-api-sergio.azurewebsites.net/api/Adotars", httpContent);
        }
    }
}
