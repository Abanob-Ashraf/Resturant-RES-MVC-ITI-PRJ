using Resturant_RES_MVC_ITI_PRJ.Models;
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

namespace WebAppday8.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IEmailSender emailSender;
        //public ITraineerepo Traineerepo { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            //this.Traineerepo = traineerepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM registerUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.UserName = registerUserVM.UserName;
                user.Email = registerUserVM.Email;
                user.PhoneNumber = registerUserVM.Phone;
                user.PasswordHash = registerUserVM.Password;
                IdentityResult result = await userManager.CreateAsync(user, registerUserVM.Password);

                //Trainee trainee = new Trainee() {
                //    Name=registerUserVM.UserName,
                //    Email=registerUserVM.Email,
                //    Gender=Gender.Male,
                //    MobileNo= registerUserVM.Phone
                //    ,Birthdate =DateTime.Now,
                //    TrackID=2
                //};

                var routeValues = new RouteValueDictionary(new { area = "Client" });

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "cust");
                    await signInManager.SignInAsync(user, false);

                    //Traineerepo.Insert(trainee);
                    return RedirectToAction("Index", "Order", routeValues);
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM userVM)
        {

            var routeValues = new RouteValueDictionary(new { area = "Client" });

            AppUser userFromDB = await userManager.FindByNameAsync(userVM.UserName);

            if (userFromDB != null)
            {
                bool exist = await userManager.CheckPasswordAsync(userFromDB, userVM.Password);

                if (exist == true)
                {
                    await signInManager.SignInAsync(userFromDB, userVM.RemeberMe);
                    return RedirectToAction("Index", "Order", routeValues);
                }
            }


            ModelState.AddModelError("error", "Not Correct UserName Or Password Try again");
            return View(userVM);

        }


        [HttpGet]
        public IActionResult Logout() 
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

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
                    UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                    FirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                    LastName = info.Principal.FindFirstValue(ClaimTypes.Surname)
                
                };
                var createResult = await userManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "cust");
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }

                return View("ExternalLogin", new ExternalLoginModel { Email = user.UserName });
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            var routeValues = new RouteValueDictionary(new { area = "Client" });

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Order" ,routeValues);
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
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
