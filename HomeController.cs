using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
