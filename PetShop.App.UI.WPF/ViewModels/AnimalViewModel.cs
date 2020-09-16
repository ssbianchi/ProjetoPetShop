using Newtonsoft.Json;
using PetShop.App.UI.WPF.Commands;
using PetShop.App.UI.WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PetShop.App.UI.WPF.ViewModels
{
    public class AnimalViewModel : Prism.Mvvm.BindableBase
    {
        #region Variables/Properties
        public ObservableCollection<AnimalModel> AnimalInfos { get; set; }
        public ICommand LoadAnimalsAsyncCommand { get; set; }

        private string _statusMessage;
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                RaiseAllCanExecuteChanged();
            }
        }
        private string token;
        #endregion
        #region Construtctors
        public AnimalViewModel()
        {
            AnimalInfos = new ObservableCollection<AnimalModel>();
            LoadAnimalsAsyncCommand = new AsyncRelayCommand(LoadAnimalInfo, (ex) => StatusMessage = ex.Message);
        }
        #endregion
        #region Methods
        public static AnimalViewModel LoadViewModel(Action<Task> onLoaded = null)
        {
            AnimalViewModel viewModel = new AnimalViewModel();

            //viewModel.LoadAnimalInfo().ContinueWith(t => onLoaded?.Invoke(t));

            return viewModel;
        }

        private async Task LoadAnimalInfo()
        {
            StatusMessage = "Status: Loading...";

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorize", "bearer " + token);
            var result = await httpClient.GetAsync("https://petshop-animalmicroservice-api-sergio.azurewebsites.net/api/animals");

            if (!result.IsSuccessStatusCode)
                return;

            var serializedAnimals = await result.Content.ReadAsStringAsync();

            var animalsViewModel = JsonConvert.DeserializeObject<IEnumerable<AnimalModel>>(serializedAnimals);

            AnimalInfos.Clear();
            AnimalInfos.AddRange(animalsViewModel);
            RaiseAllCanExecuteChanged();
            StatusMessage = "Status: Success.";
        }
        #endregion
        #region Helpers
        private void RaiseAllCanExecuteChanged()
        {
            //RaisePropertyChanged(nameof(AnimalInfos));
            RaisePropertyChanged(nameof(StatusMessage));
        }
        #endregion
    }
}
