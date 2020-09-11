using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.UI.WPF.Models
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Peso { get; set; }
    }
}
