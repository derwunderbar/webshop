using System.ComponentModel.DataAnnotations;

namespace WebShop.ViewModels.Account
{
    public class RegisterExternalLoginViewModel
    {
        [Required]
        [Display( Name = "User name" )]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }
}