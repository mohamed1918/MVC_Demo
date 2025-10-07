﻿using System.ComponentModel.DataAnnotations;

namespace MVC_Demo.ViewModels.Account
{
    public class LogInViewModel
    {

        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [DataType(DataType.Password)]

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
