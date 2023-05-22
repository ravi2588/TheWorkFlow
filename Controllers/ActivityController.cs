using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWorkFlow.Models;

namespace TheWorkFlow.Controllers
{
    public class ActivityController : Controller
    {
        WorkflowDbContext _context;
        public ActivityController(WorkflowDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            TempData["SuccessMessage"]="";
            TempData["ErrorMessage"]="";
            return View();

        
        }

        //Create New Activity
        [HttpPost]       
        public IActionResult Create(ActivityMaster activity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Isexits = _context.ActivityMaster.Where(x => x.NameofActivity==activity.NameofActivity).FirstOrDefault();
                    if (Isexits==null)
                    {
                        ActivityMaster activityMaster = new ActivityMaster()
                        {
                            NameofActivity = activity.NameofActivity,
                            ActivityType = activity.ActivityType,
                            Source=activity.Source,
                        };
                        _context.ActivityMaster.Add(activityMaster);
                        _context.SaveChanges();
                        TempData["SuccessMessage"]="Activity is added successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"]="Activity is alerdy added.";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"]=ex.Message;

            }
            return View(activity);

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
