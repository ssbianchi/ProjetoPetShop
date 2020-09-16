using PetShop.Common.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.App.Domain
{
    public interface IAnimalRepository : IRepository<Guid, Animal>
    {
    }
}
