﻿using PetShop.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate
{
    public class Adotar : EntityBase<Guid>
    {
        //public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid AnimalId { get; set; }
        public DateTime DataAdocao { get; set; }
    }
}
