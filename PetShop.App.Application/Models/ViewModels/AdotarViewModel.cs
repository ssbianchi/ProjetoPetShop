using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.App.Application.Models.ViewModels
{
    public class AdotarViewModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid AnimalId { get; set; }
        public DateTime DataAdocao { get; set; }
    }
}
