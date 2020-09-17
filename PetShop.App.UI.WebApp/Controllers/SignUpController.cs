using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.App.Application;
using PetShop.App.Application.Models.ViewModels;

namespace PetShop.App.UI.WebApp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IAppService appService;

        public SignUpController(IAppService appService)
        {
            this.appService = appService;
        }

        // GET: SignInController
        public ActionResult Index()
        {
            return View();
        }

        // POST: SignInController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignUpViewModel signUpViewModel)
        {
            appService.SignUp(signUpViewModel);
            return RedirectToAction("Index", "SignIn");

        }
    }
}
