using Resturant_RES_MVC_ITI_PRJ.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Resturant_RES_MVC_ITI_PRJ.Models.ViewModels;
using Resturant_RES_MVC_ITI_PRJ.Services;
using Message = Resturant_RES_MVC_ITI_PRJ.Services.Message;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly ICustomerRepository customerRepository;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender,
            ICustomerRepository customerRepository
          )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.customerRepository = customerRepository;
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
            var phones = userManager.Users.Select(u => u.PhoneNumber).ToList();
            if (phones.Contains(registerUserVM.Phone))
            {
                ModelState.AddModelError("Phone", "Already Exist Phone Number");
            }
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
                    CustAddressStreet = registerUserVM.CustAddressStreet,
                    CustAddressCity = registerUserVM.CustAddressCity,
                    CustAddressCounty = registerUserVM.CustAddressCounty,
                };

                // Create a new claim to add to the user
                var claim = new Claim(ClaimTypes.Name, user.Email); // Replace with your own claim type and value

                // Use UserManager to add the claim to the user
                var result2 = await userManager.AddClaimAsync(user, claim);

                if (result.Succeeded && result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email, username = user.UserName }, Request.Scheme);
                    var message = new Message(new string[] { user.Email }, "Confirmation email link", $"<a style='background-color:  #FFBC32;\r\n  border-color: #FFBC32;\r\nborder-radius: 3px;\r\nborder-style: solid;\r\ntext-decoration: none; \r\ntext-decoration-line: none;\r\n display: inline-block;\r\n  font-weight: 400;\r\n  line-height: 1.5;\r\n  color: #212529;\r\n  text-align: center;\r\n  text-decoration: none;\r\n  vertical-align: middle;\r\n  cursor: pointer;\r\n  user-select: none;\r\n  padding: 10px;\r\n  font-size: 16px;\r\n  border-radius: 0.25rem;'  href='{confirmationLink}'>Click Here</a> ", null);
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
            return RedirectToAction("Login");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]

        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var act = provider == "google" ? nameof(ExternalLoginCallback) : nameof(FacebookCallback);
            var redirectUrl = Url.Action(act, "Account", new { returnUrl });
            var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        //GoogleExternal

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

                // Create a new claim to add to the user
                var claim = new Claim(ClaimTypes.Name, user.Email); // Replace with your own claim type and value

                // Use UserManager to add the claim to the user
                var result2 = await userManager.AddClaimAsync(user, claim);

                if (createResult.Succeeded && result2.Succeeded)
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


        //FacebookExternal

        [HttpGet]

        public async Task<IActionResult> FacebookCallback(string returnUrl = null)
        {

            Microsoft.AspNetCore.Identity.SignInResult signInResult;
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }
            if (info.Principal.FindFirstValue(ClaimTypes.Email) == null)
            {
                return View("ExternalloginFacebook");
            }
            var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);

            if (userManager.Users.Select(u => u.Email).Contains(userEmail))
            {

                var Logins = await userManager.GetLoginsAsync(await userManager.FindByEmailAsync(userEmail));
                var UserExternalLoginData = Logins.Select(e => new { LoginProviderName = e.LoginProvider, LoginProviderKey = e.ProviderKey }).FirstOrDefault();
                info.LoginProvider = UserExternalLoginData.LoginProviderName;
                info.ProviderKey = UserExternalLoginData.LoginProviderKey;

            }

            signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            if (signInResult.IsLockedOut)
            {
                return RedirectToAction("login");
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

                // Create a new claim to add to the user
                var claim = new Claim(ClaimTypes.Name, user.Email); // Replace with your own claim type and value

                // Use UserManager to add the claim to the user
                var result2 = await userManager.AddClaimAsync(user, claim);

                if (createResult.Succeeded && result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customer");
                    await userManager.AddLoginAsync(user, info);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    var message = new Message(new string[] { user.Email }, "Welcome to ZMAN Resturant", null, null);
                    await emailSender.SendEmailAsync(message);
                    customerRepository.InsertCustomer(customer);

                    return RedirectToLocal(returnUrl);
                }

                return View("ExternalloginFacebook");
            }
        }


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
            var content = $"<a style='background-color:  #FFBC32;\r\n  border-color: #FFBC32;\r\nborder-radius: 3px;\r\nborder-style: solid;\r\ntext-decoration: none; \r\ntext-decoration-line: none;\r\n display: inline-block;\r\n  font-weight: 400;\r\n  line-height: 1.5;\r\n  color: #212529;\r\n  text-align: center;\r\n  text-decoration: none;\r\n  vertical-align: middle;\r\n  cursor: pointer;\r\n  user-select: none;\r\n  padding: 10px;\r\n  font-size: 16px;\r\n  border-radius: 0.25rem;'  href='{callback}'>Click Here</a> ";
            var message = new Message(new string[] { user.Email }, "Reset your password at ZMAN Restaurants", content, null);
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
            if (User.IsInRole("Customer"))
            {
                return View(UserData);
            }
            return View("EmployeeProfile", UserData);
        }
    }
}