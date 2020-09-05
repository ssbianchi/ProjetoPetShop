using System.ComponentModel.DataAnnotations;

namespace PetShop.IamMicroserver.STS.Identity.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}






