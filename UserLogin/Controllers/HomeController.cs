using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserLogin.Models;
using UserLogin.ViewModels;

namespace UserLogin.Controllers
{
    public class HomeController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        private readonly LoginDbContext _context;

        public HomeController(ILogger<HomeController> logger, LoginDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
		{
			return View();
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
	}
}
	

