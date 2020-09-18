using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.App.Domain.Adotar
{
    public class Adotar
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid AnimalId { get; set; }
        public DateTime DataAdocao { get; set; }
    }
}
