using DapperImplementation.Data;
using DapperImplementation.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DapperImplementation.Controllers
{
    [Controller]
    public class PersonController : Controller
    {
        private IConfiguration _configuration;
        public PersonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [Route("all")]
        [HttpGet]
        public IActionResult Index()
        {
            DataAccess da = new DataAccess();
            var list = da.GetPeople();
            return View("Index", list);
        }
        
        
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            DataAccess da = new DataAccess(_configuration);
            da.InsertPerson(person);
            return RedirectToAction("Index");
        }
    }
}