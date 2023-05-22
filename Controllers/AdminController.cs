using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using TheWorkFlow.Data;
using TheWorkFlow.Models;

namespace TheWorkFlow.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        WorkflowDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Dashboard()
        {

            return View();
        }
        public IActionResult CreateRole()
        {
            TempData["SuccessMessage"]="";
            TempData["ErrorMessage"]="";

            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> CreateRole(IdentityRole role)
        {
            try
            {
                var roleExists = await _roleManager.RoleExistsAsync(role.Name);
                if (!roleExists)
                {
                    var newRole = new IdentityRole(role.Name);
                    var result = await _roleManager.CreateAsync(newRole);
                    if (result.Succeeded)
                    {
                        //return RedirectToAction("Index", "Home"); // Redirect to a success page or any other desired action
                    }
                    TempData["SuccessMessage"]="Role is added successfully";
                }
                else
                {
                    TempData["ErrorMessage"]="Role is already exits";
                }

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"]=ex.Message;
            }


           
        
            return View();
        }

        //[HttpPost]
        //private async Task CreateRoles(IdentityRole role)
        //{
        //    RoleManager<IdentityRole> roleManager=new RoleManager<IdentityRole>();
        //    // Create roles if they don't exist
        //    if (!await roleManager.RoleExistsAsync("Admin"))
        //    {
        //        var adminRole = new IdentityRole("Admin");
        //        await roleManager.CreateAsync(adminRole);
        //    }

        //    if (!await roleManager.RoleExistsAsync("User"))
        //    {
        //        var userRole = new IdentityRole("User");
        //        await roleManager.CreateAsync(userRole);
        //    }

        //    // Add more roles as needed
        //}
    }
}
