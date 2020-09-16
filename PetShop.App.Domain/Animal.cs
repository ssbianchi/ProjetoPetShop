using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.App.Domain
{
    public class Animal
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
    }
}
