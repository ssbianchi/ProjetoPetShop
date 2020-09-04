using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.ClienteMicroservice.Domain.AggregatesModel.ClienteAggregate
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
