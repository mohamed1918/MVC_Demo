using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace MVC_Demo.ViewModels.Account
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }
    }
}
