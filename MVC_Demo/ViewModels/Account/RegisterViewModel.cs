using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace MVC_Demo.ViewModels.Account
{
    public class RegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = " First name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = " Last name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = " Username is required")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }

    }
}
