using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TheWorkFlow.Controllers
{
   
    public class AdminController : Controller
    {
        [Authorize]
        public IActionResult Dashboard()
        {

            return View();
        }
    }
}
