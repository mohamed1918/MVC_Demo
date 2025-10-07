using Demo_DataAccess.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Utilities;
using MVC_Demo.ViewModels.Account;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MVC_Demo.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region     Rigster
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(viewModel.UserName).Result;
                if (user is null)
                {
                    user = new ApplicationUser()
                    {
                        FirstName = viewModel.UserName,
                        LastName = viewModel.LastName,
                        UserName = viewModel.UserName,
                        Email = viewModel.Email
                    };
                    var result = _userManager.CreateAsync(user, viewModel.Password).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("LogIn");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This User Name Already Exit, try another one");
                }
            }
            return View(viewModel);






        }
        #endregion

        #region LogIn   
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if (user is not null)
                {
                    var flag = _userManager.CheckPasswordAsync(user, viewModel.Password).Result;
                    if (flag)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false);
                        if (result.IsNotAllowed)
                        {
                            ModelState.AddModelError(string.Empty, "Your Account Is not Allowed");
                        }
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError(string.Empty, "Your Account Is Locked Out");
                        }
                        if (result.Succeeded)
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");
                        }

                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid Password or Email");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Email");
                    }
                }

            }
            return View(viewModel);

        }
        #endregion

        #region LogOut

        [HttpGet]
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToAction(nameof(LogIn));
        }
        #endregion

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if (user is not null)
                {
                    var Token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                    var ResetPasswordLink = Url.Action("ResetPassword", "Account", new { email = viewModel.Email ,Token }, Request.Scheme);
                    var email = new Email()
                    {
                        To = viewModel.Email,
                        Subject = "Reset Password",
                        Body = ResetPasswordLink
                    };

                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));

                }
                
                
            }
            ModelState.AddModelError(string.Empty, "Invalid Opertion");
            return View(nameof(ForgetPassword), viewModel);

        }

        public IActionResult CheckYourInbox()
        {
            return View();
        }

        [HttpGet]

        public IActionResult ResetPassword(string email , string Token)
        {
            TempData["email"] = email;
            TempData["Token"] = Token;
            return View();
        }

        [HttpPost]

        public IActionResult ResetPassword(ResetPasswordViewModel viewModel) 
        {
            if(!ModelState.IsValid) return View(viewModel);

            string email = TempData["email"] as string ?? string.Empty;
            string Token = TempData["Token"] as string ?? string.Empty;

            var user = _userManager.FindByEmailAsync(email).Result;
            if(user is not null)
            {
                var result = _userManager.ResetPasswordAsync(user, Token, viewModel.Password).Result;
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(LogIn));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    
                }
            }
            return View(viewModel);
        }
       
    }
}