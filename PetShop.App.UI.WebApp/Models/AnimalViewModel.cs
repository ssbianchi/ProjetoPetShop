using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.App.UI.WebApp.Models
{
    public class AnimalViewModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
    }
}
