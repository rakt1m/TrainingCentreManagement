using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.Models;


namespace TIMSApp.Controllers
{
    public class HomeController : Controller
    {
        private ICourseManager _iCourseManager;
        public HomeController(ICourseManager iCourseManager)
        {
            _iCourseManager = iCourseManager;
        }
        public IActionResult Index()
        {
            return View(_iCourseManager.GetAll().ToList());
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
