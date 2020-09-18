using PetShop.App.Application.Models.Dtos;
using PetShop.App.Application.Models.ViewModels;
using PetShop.App.Domain;
using PetShop.App.Domain.Adotar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.App.Application
{
    public interface IAppService
    {
        string SignIn(string userName, string password);
        bool SignUp(SignUpViewModel userPasswordDto);

        #region Animal
        Task AddAnimalAsync(string token, Animal animalViewModel);

        Task<IEnumerable<Animal>> GetAllAnimalsAsync(string token);
        #endregion

        #region Adotar
        Task AddAdotarAsync(string token, Adotar adotarViewModel);

        Task<IEnumerable<Adotar>> GetAllAdotarsAsync(string token);
        #endregion
    }
}
