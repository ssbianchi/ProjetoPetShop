using PetShop.Common.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.App.Domain.Adotar
{
    public interface IAdotarRepository : IRepository<Guid, Adotar>
    {
    }
}
