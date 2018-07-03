using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoryTogether.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace MemoryTogether.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("home/index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("home/greet/{username}")]
        public IActionResult Greet(string username)
        {
            var name = new User { Name = username };
            return Ok(name);
        }
    }
}