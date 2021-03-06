﻿using PetShop.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AnimalMicroservice.Domain.AggregatesModel.AnimalAggregate
{
    public class Animal : EntityBase<Guid>
    {
        //public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }

    }
}
