using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AviationEducation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AviationEducation.Data;

namespace AviationEducation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AviationEducationContext _context;

        public HomeController(ILogger<HomeController> logger, AviationEducationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var questions = new List<Question>(_context.Question.ToList());
            _logger.LogInformation("This is where we can add string to .log file");
            return View(questions);
        }
            
        [Authorize]
        public IActionResult CustomQuiz()
        {
        var questions = new List<Question>(_context.Question.ToList());
        return View(questions);
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
