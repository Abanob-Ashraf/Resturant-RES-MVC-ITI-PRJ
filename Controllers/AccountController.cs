﻿using Resturant_RES_MVC_ITI_PRJ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Resturant_RES_MVC_ITI_PRJ.Models;
using System.Security.Claims;
using Resturant_RES_MVC_ITI_PRJ.Models.ViewModels;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Resturant_RES_MVC_ITI_PRJ.Services;
using Message = Resturant_RES_MVC_ITI_PRJ.Services.Message;
using Microsoft.AspNetCore.Http.HttpResults;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly ICustomerRepository customerRepository;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSender emailSender, ICustomerRepository customerRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.customerRepository = customerRepository;
            //this.Traineerepo = traineerepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM registerUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.FirstName = registerUserVM.FirstName;
                user.LastName = registerUserVM.LastName;
                user.UserName = registerUserVM.Email;
                user.Email = registerUserVM.Email;
                user.PhoneNumber = registerUserVM.Phone;
                user.PasswordHash = registerUserVM.Password;
                IdentityResult result = await userManager.CreateAsync(user, registerUserVM.Password);

                Customer customer = new Customer()
                {
                    FirstName = registerUserVM.FirstName,
                    LastName = registerUserVM.LastName,
                    CustEmail = registerUserVM.Email,
                    CustPassword = registerUserVM.Password,
                    CustPhone = registerUserVM.Phone,
                };

                var routeValues = new RouteValueDictionary(new { area = "Client" });

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email, username = user.UserName }, Request.Scheme);
                    var message = new Message(new string[] { user.Email }, "Confirmation email link", confirmationLink, null);
                    await emailSender.SendEmailAsync(message);
                    customerRepository.InsertCustomer(customer);
                    return RedirectToAction(nameof(SuccessRegistration));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("all", error.Description);
                    }
                }
            }
            return View(registerUserVM);
        }


        //ConfirmEmail
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return View("Error");
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }


        //Login
        [HttpGet]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM userVM)
        {
            AppUser userFromDB = await userManager.FindByEmailAsync(userVM.Email);

            if (userFromDB != null)
            {
                bool result = await userManager.IsEmailConfirmedAsync(userFromDB);

                if (result == true)
                {
                    bool exist = await userManager.CheckPasswordAsync(userFromDB, userVM.Password);

                    if (exist == true)
                    {
                        await signInManager.SignInAsync(userFromDB, userVM.RemeberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Attempt Please confirm your email");
                    return View();
                }
            }
            ModelState.AddModelError("error", "Not Correct UserName Or Password Try again");
            return View(userVM);
        }


        [HttpGet]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        //external login


        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }
            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            if (signInResult.IsLockedOut)
            {
                return RedirectToAction(nameof(signInManager));
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["Provider"] = info.LoginProvider;

                var user = new AppUser
                {
                    Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                    FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                    LastName = info.Principal.FindFirstValue(ClaimTypes.Surname),
                    EmailConfirmed = true
                };

                Customer customer = new Customer()
                {
                    FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                    LastName = info.Principal.FindFirstValue(ClaimTypes.Surname),
                    CustEmail = info.Principal.FindFirstValue(ClaimTypes.Email),
                };

                var createResult = await userManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    var message = new Message(new string[] { user.Email }, "Welcome to ZMAN Resturant", null, null);
                    await emailSender.SendEmailAsync(message);
                    customerRepository.InsertCustomer(customer);


                    return RedirectToLocal(returnUrl);
                }

                return View("ExternalLogin", new ExternalLoginModel { Email = user.UserName });
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        //---------------------------------------------forget password

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordModel);
            var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

            var message = new Message(new string[] { user.Email }, "Reset your password at ZMAN Restaurants", callback, null);
            await emailSender.SendEmailAsync(message);
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);
            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                return View();
            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var UserData = userManager.Users.FirstOrDefault(e => e.UserName == User.Identity.Name);
            return View(UserData);
        }
    }
}
