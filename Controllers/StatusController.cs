using Microsoft.AspNetCore.Mvc;
using TheWorkFlow.Models;

namespace TheWorkFlow.Controllers
{
    public class StatusController : Controller
    {
        WorkflowDbContext _context;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(string statatusId)
        {
            try
            {
                var Isexits = _context.StatusMaster.Where(x => x.Id==statatusId);
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();

        }
        public IActionResult Delete()
        {
            return View();

        }
        public IActionResult Update()
        {
            return View();

        }
    }
}
