using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWorkFlow.Models;

namespace TheWorkFlow.Controllers
{
    public class StatusController : Controller
    {
        WorkflowDbContext _context;
        public StatusController(WorkflowDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Create()
        {
            return View();    
        }
        [HttpPost]
        public IActionResult Create(StatusMaster status)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var Isexits = _context.StatusMaster.Where(x => x.StatusName==status.StatusName).FirstOrDefault();
                    if (Isexits==null)
                    {
                        StatusMaster statusMaster = new StatusMaster()
                        {
                            StatusName = status.StatusName,
                            StatusType=status.StatusType
                        };
                        _context.StatusMaster.Add(statusMaster);
                        _context.SaveChanges();
                        TempData["SuccessMessage"]="Status is added successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"]="Status is alerdy added.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"]=ex.Message;

            }
            return View(status);

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
