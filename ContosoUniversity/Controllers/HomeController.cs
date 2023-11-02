using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models.SchoolViewModels;

using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext _schoolContext;

        public HomeController(ILogger<HomeController> logger, SchoolContext schoolContext)
        {
            _logger = logger;
            _schoolContext = schoolContext;
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
        public async Task<IActionResult> About() 
        {
            IQueryable<EnrollmentDateGroup> enrollmentDates = from Student in _schoolContext.Students group Student by Student.EnrollmentDate into dateGroup
                                                              select new EnrollmentDateGroup
                                                              {
                                                                  EnrollmentDate=dateGroup.Key,
                                                                  StudentCount=dateGroup.Count()
                                                              };
            return View(await enrollmentDates.AsNoTracking().ToListAsync());
        }
    }
}
