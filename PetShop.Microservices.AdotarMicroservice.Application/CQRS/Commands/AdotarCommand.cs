using PetShop.Common.Application.Interfaces.CQRS.Commands;
using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AdotarMicroservice.Application.CQRS.Commands
{
    public abstract class AdotarCommand : Command
    {
        public Adotar Adotar { get; set; }

        public AdotarCommand(Adotar adotar) :base()
        {
            Adotar = adotar;
        }

        public AdotarCommand() : base()
        {
        }
    }
}
