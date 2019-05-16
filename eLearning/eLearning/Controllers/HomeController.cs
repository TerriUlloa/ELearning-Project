using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eLearning.Models;
using eLearning.DAL;
using eLearning.BusinessLogic;

namespace eLearning.Controllers
{
    public class HomeController : AuthController
    {
        #region Member Variables
        protected ICourseDAL _coursedb = null;
        #endregion

        #region Constructor
        public HomeController (ICourseDAL coursedb, IUserDAL userdb, IHttpContextAccessor httpContext) : base(userdb, httpContext)
        {
            _coursedb = coursedb;
        }
        #endregion

        #region public Methods / Actions
        public IActionResult Index()
        {
            List<Course> courses = (List<Course>)_coursedb.GetFiveCourses();
            List<LandingViewModel> courseList = new List<LandingViewModel>();
            foreach ( Course entry in courses )
            {
                LandingViewModel viewCourse = new LandingViewModel()
                {
                    Name = entry.Name,
                    TeacherName = entry.TeacherFirstName + " " + entry.TeacherLastName,
                    EstimatedDuration = entry.EstimatedDuration,
                    Image = entry.Image
                };
                courseList.Add(viewCourse);
            }
            return View(courseList);
        }

        public IActionResult Logout()
        {
            SetSessionData(UserKey, (RoleManager)null);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
