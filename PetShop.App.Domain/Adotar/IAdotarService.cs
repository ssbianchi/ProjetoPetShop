using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.Domain.Adotar
{
    public interface IAdotarService
    {
        Task AddAdotarAsync(Adotar adotar);

        Task<IEnumerable<Adotar>> GetAllAdotarsAsync();
    }
}
