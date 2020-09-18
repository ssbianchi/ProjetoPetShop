using PetShop.Common.Infra.DataAccess;
using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AdotarMicroservice.Infra.DataAccess.Repositories
{
    public class AdotarRepository : EntityFrameworkRepositoryBase<Guid, Adotar>, IAdotarRepository
    {
    }
}
