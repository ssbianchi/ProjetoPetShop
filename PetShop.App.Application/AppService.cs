﻿using PetShop.Common.Domain.Services;
using IdentityModel.Client;
using System.Net.Http;
using System.Threading.Tasks;
using PetShop.App.Domain;
using System.Collections.Generic;
using System;
using PetShop.App.Infra.DataAccess.Repositories;
using PetShop.App.Application.Models.Dtos;
using System.Text;
using PetShop.App.Application.Models.ViewModels;
using PetShop.App.Domain.Adotar;

namespace PetShop.App.Application
{
    public class AppService : IAppService
    {
        //private string token;
        private ISerializerService serializerService;

        public AppService(ISerializerService serializerService)
        {
            this.serializerService = serializerService;
        }

        #region Animal
        public async Task AddAnimalAsync(string token, Animal animalViewModel)
        {
            var animalRepository = new AnimalRepository(serializerService, token);
            var animalService = new AnimalService(animalRepository);
            await animalService.AddAnimalAsync(animalViewModel);
        }

        public async Task<IEnumerable<Animal>> GetAllAnimalsAsync(string token)
        {
            var animalRepository = new AnimalRepository(serializerService, token);
            var animalService = new AnimalService(animalRepository);
            return await animalService.GetAllAnimalsAsync();
        }
        #endregion

        #region Adotar
        public async Task AddAdotarAsync(string token, Adotar adotarViewModel)
        {
            var adotarRepository = new AdotarRepository(serializerService, token);
            var adotarService = new AdotarService(adotarRepository);
            await adotarService.AddAdotarAsync(adotarViewModel);
        }

        public async Task<IEnumerable<Adotar>> GetAllAdotarsAsync(string token)
        {
            var adotarRepository = new AdotarRepository(serializerService, token);
            var adotarService = new AdotarService(adotarRepository);
            return await adotarService.GetAllAdotarsAsync();
        }
        #endregion

        public string SignIn(string username, string password)
        {
            return GetToken(username, password);

            //if (string.IsNullOrWhiteSpace(token))
            //    return false;

            //return true;
        }

        public bool SignUp()
        {
            throw new NotImplementedException();
        }

        public bool SignUp(SignUpViewModel signUpViewModel)
        {
            var userPasswordDto = new UserPasswordDto
            {
                user = new UserPasswordDto.User
                {
                    userName = signUpViewModel.Username,
                    email = signUpViewModel.Email,
                    emailConfirmed = true,
                    phoneNumber = signUpViewModel.Phone,
                    phoneNumberConfirmed = true
                },
                password = new UserPasswordDto.Password
                {
                    password = signUpViewModel.Password,
                    confirmPassword = signUpViewModel.Password
                }
            };

            var token = GetAdminToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var serializedUserPassword = serializerService.Serialize(userPasswordDto);
            var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://petshop-sergio-iammicroservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;

            if (!result.IsSuccessStatusCode)
                return false;
            return true;
        }

        private string GetToken(string username, string password)
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://petshop-sergio-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "PetShopWpf_ClientId",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }

        private string GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://petshop-sergio-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "PetShopWpf_ClientId",

                UserName = "Admin",
                Password = "123Mudar!"
            }).Result;

            return response.AccessToken;
        }
    }
}
