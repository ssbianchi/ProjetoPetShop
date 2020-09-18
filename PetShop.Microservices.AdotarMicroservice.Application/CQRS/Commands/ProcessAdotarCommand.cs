using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AdotarMicroservice.Application.CQRS.Commands
{
    //User Case: Process Order
    public class ProcessAdotarCommand : AdotarCommand
    {
        public const string CommandQueueName = "process-adotar-command-queue";
        public override string QueueName => CommandQueueName;

        public ProcessAdotarCommand()
        {
        }

        public ProcessAdotarCommand(Adotar adotar):base()
        {
        }

    }
}
