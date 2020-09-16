using PetShop.App.Application.Models.ViewModels;
using PetShop.App.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.App.Application
{
    public interface IAppService
    {
        string SignIn(string userName, string password);
        bool SignUp();

        Task AddAnimalAsync(string token, Animal animalViewModel);

        Task<IEnumerable<Animal>> GetAllAnimalsAsync(string token);


    }
}
