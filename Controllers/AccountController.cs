using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using TheWorkFlow.Data;
using TheWorkFlow.Models;

using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace TheWorkFlow.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly WorkflowDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IConfiguration configuration, SignInManager<IdentityUser> signInManager, WorkflowDbContext context, UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _config = configuration;
            _signInManager = signInManager;
            _context=context;
            _userManager=userManager;    
            _roleManager=roleManager;
        }
        public IActionResult Index()
        {

            return RedirectToAction("Index", "Home");
        }
       
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            _signInManager.SignOutAsync();
            ViewData["ReturnUrl"] = "/Login";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl )
        {



            if (!string.IsNullOrEmpty(returnUrl) && !Url.IsLocalUrl(returnUrl))
            {
                // Handle invalid returnUrl here, such as redirecting to a default page
                returnUrl = null;
            }
            returnUrl="/Login";
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();



                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);

                // Hash the user's password
                var hashedPassword = passwordHasher.HashPassword(user, model.Password);

                // Set the hashed password to the user's PasswordHash property
                user.PasswordHash = hashedPassword;

                // Verify the entered password with the hashed password
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                // Check the result of password verification
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    // Password is correct
                    // Perform the login operation
                    //return RedirectToLocal(returnUrl);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    // Password is incorrect
                    // Add a model error or handle the invalid login attempt
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }



                //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                //if (result.Succeeded)
                //{
                //    return RedirectToLocal(returnUrl);
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return View(model);
                //}
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles=_context.Roles.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                var roles=await _userManager.GetRolesAsync(user);

                var userdata = await _userManager.FindByIdAsync(user.Id);

                var userdetail = await _userManager.FindByNameAsync(model.UserName);

      

                if (result.Succeeded)
                {
                    if (user != null)
                    {
                        var role = await _roleManager.FindByIdAsync(model.RoleId);
                        if (role != null)
                        {
                            var addrole = await _userManager.AddToRoleAsync(user, role.Name);
                            if (addrole.Succeeded)
                            {
                                return RedirectToAction("Index", "Home"); // Redirect to a success page or any other desired action
                            }
                            else
                            {
                                foreach (var error in result.Errors)
                                {
                                    ModelState.AddModelError("", error.Description);
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Role not found.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User not found.");
                    }



                    // If registration is successful, you can choose to sign in the user automatically
                    // or redirect to a confirmation page where the user can confirm their email, etc.

                    // Option 1: Automatically sign in the user
                    // await _signInManager.SignInAsync(user, isPersistent: false);
                    // return RedirectToAction("Index", "Home");
                    // Option 2: Redirect to a confirmation page
                    return RedirectToAction("Login", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay the registration form with error messages
            return View(model);
        }



        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await _userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            // Sign in the user
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            return RedirectToAction(nameof(HomeController.Index), "Home");
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}



     
    }
}
