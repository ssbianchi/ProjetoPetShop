using PetShop.Common.Application.Interfaces.CQRS.Messaging;
using PetShop.Common.Domain.Services;
using PetShop.Common.Infra.Helper.Serializers;
using PetShop.Microservices.AdotarMicroservice.Application.CQRS.Commands;
using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using System;
using System.Threading.Tasks;

namespace PetShop.Microservices.AdotarMicroservice.Application
{
    public class ApiApplicationService :IApiApplicationService
    {
        private IAdotarService adotarService;
        private IMediatorHandler bus;
        //private ISerializerService serializerService;

        public ApiApplicationService(IAdotarService adotarService, IMediatorHandler bus)
        {
            this.adotarService = adotarService;
            this.bus = bus;
            //this.serializerService = serializerService;
        }

        public async Task CreateAdotarAsync(Guid clientId, Guid animalId, DateTime dataAdocao)
        {
            var adotar = adotarService.CreateAdotar(clientId, animalId, dataAdocao);
            var command = new ProcessAdotarCommand(adotar);
            //var serializedCommand = serializerService.Serialize(command);

            await bus.EnqueueAsync(command, command.QueueName);
        }
    }
}
