using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using testMangoDb.AppCode;
using testMangoDb.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMangoDb.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            
            

            return View();
        }
    }
}
