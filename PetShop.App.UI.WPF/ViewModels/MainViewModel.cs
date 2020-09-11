using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.App.UI.WPF.ViewModels
{
    public class MainViewModel
    {
        public AnimalViewModel AnimalViewModel { get; set; }

        public MainViewModel()
        {
            AnimalViewModel = AnimalViewModel.LoadViewModel();
        }
    }
}
