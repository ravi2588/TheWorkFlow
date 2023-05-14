using Microsoft.AspNetCore.Mvc;
using TheWorkFlow.Models;

namespace TheWorkFlow.Controllers
{
    public class CountryController : Controller
    {
        WorkflowDbContext _context;
        public CountryController(WorkflowDbContext context)
        {
            _context= context;
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
        public IActionResult Create(CountryMaster countryMaster)
        {
            try
            {
                var Isexits = _context.CountryMaster.Where(x=>x.CountryName==countryMaster.CountryName).FirstOrDefault();
                if(Isexits==null)
                {
                    CountryMaster country = new CountryMaster()
                    {
                        CountryName = countryMaster.CountryName, 
                        CountryCode="ITA"
                    }; 
                    _context.CountryMaster.Add(country);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                
            }
            return View(countryMaster);

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
