using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWorkFlow.Models;

namespace TheWorkFlow.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly WorkflowDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger,SignInManager<IdentityUser> signInManager,WorkflowDbContext context,UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _SignInManager= signInManager;
            _context= context;
            _userManager= userManager;  
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult File()
        {

            return View();
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult GetData()
        {
            // Retrieve data from your data source
            var data = _context.FileMaster.ToList();

            // Return data as JSON
            return Json(data);
        }

        [HttpGet]
        public IActionResult InsertFile()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertFile(FileMaster filemodel)
        {


            return View(filemodel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}