using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.Domain
{
    public interface IAnimalService
    {
        Task AddAnimalAsync(Animal animal);

        Task<IEnumerable<Animal>> GetAllAnimalsAsync();
    }
}
