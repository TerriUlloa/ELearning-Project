using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eLearning.Models;
using eLearning.DAL;
using eLearning.ViewModels;
using SessionControllerData;
using eLearning.BusinessLogic;
using eLearning.Exceptions;
using Microsoft.AspNetCore.Http;

namespace eLearning.Controllers
{
    public class StudentController : AuthController
    {

        protected ICourseDAL _coursedb = null;

        #region Member Variables
        protected ICourseCurriculaDAL _currDAL = null;
        public const string UserKey = "user";
        #endregion

        #region Constructor
        public StudentController(ICourseDAL coursedb, IUserDAL db, ICourseCurriculaDAL currDAL, IHttpContextAccessor httpContext) : base(db, httpContext)

        {
            _coursedb = coursedb;
            _currDAL = currDAL;
        }
        #endregion

        #region Public Methods / Actions
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard(int studentId)
        {
            ActionResult result = null;
            int _role = 0;
            if (IsAuthenticated)
            {
                _role = CurrentUser.RoleId;
                if (_role == 2)
                {
                    List<Course> courses = (List<Course>)_coursedb.GetStudentCourses(studentId);
                    StudentDashboardViewModel courseList = new StudentDashboardViewModel()
                    {
                        DashStudentId = CurrentUser.Id,
                        DashStudentName = CurrentUser.FirstName
                    };

                    foreach (Course entry in courses)
                    {
                        StudentDashboardModel viewCourse = new StudentDashboardModel(_coursedb)
                        {
                            CourseTitle = entry.Name,
                            CourseId = entry.Id,
                            Image = entry.Image,
                            StudentId = CurrentUser.Id

                        };
                        courseList.DashCourseList.Add(viewCourse);
                    }
                    result = View(courseList);
                }
                else
                {
                    result = RedirectToAction("Dashboard","Teacher");
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }

            return result;
        }
    
        public IActionResult Browse()
        {
            ActionResult result = null;
            int _role = 0;
            if (IsAuthenticated)
            {
                _role = CurrentUser.RoleId;
                if (_role == 2)
                {
                    List<Course> courses = (List<Course>)_coursedb.GetCourses();
                    BrowseViewModel courseList = new BrowseViewModel()
                    {
                        BrowseStudentId = CurrentUser.Id,
                        BrowseStudentName = CurrentUser.FirstName
                    };
                    foreach (Course entry in courses)
                    {
                        BrowseModel viewCourse = new BrowseModel()
                        {
                            Id = entry.Id,
                            Name = entry.Name,
                            TeacherName = entry.TeacherFirstName + " " + entry.TeacherLastName,
                            EstimatedDuration = entry.EstimatedDuration,
                            Image = entry.Image,
                            CourseRating = _coursedb.CourseRating(entry.Id)
                        };
                        courseList.BrowseCourseList.Add(viewCourse);
                    }
                    result = View(courseList);
                }
                else
                {
                    result = RedirectToAction("Dashboard", "Teacher");
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }
            return result;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Enroll(string courseId)
        {
            ActionResult result = null;
            int _studentId = CurrentUser.Id;

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                try
                {
                    List<Course> courses = (List<Course>)_coursedb.GetStudentCourses(_studentId);
                    StudentCourse studentCourse = new StudentCourse()
                    {
                        courseId = Convert.ToInt32(courseId),
                        userId = _studentId
                    };
                    foreach (Course course in courses)
                    {
                        if (course.Id == studentCourse.courseId)
                        {
                            throw new Exception("Course has already been enrolled.");
                        }
                    }

                    _coursedb.EnrollStudent(studentCourse);
                }
                catch (EnrollmentFailedException)
                {
                    ModelState.AddModelError("enrollment-failed", "Enrollment in this course failed.");
                    throw;
                }

                result = RedirectToAction("Dashboard", "Student", new { studentId = CurrentUser.Id });
            }
            catch (Exception ex)
            {
                result = RedirectToAction("Browse", "Student");
                TempData["error"] = ex.Message;
            }

            return result;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Detail(string courseId)
        {
            int _courseId = Convert.ToInt32(courseId);
            ActionResult result = null;
            int _role = 0;
            if (IsAuthenticated)
            {
                _role = CurrentUser.RoleId;
                if (_role == 2)
                {
                    Course crs = _coursedb.GetCourse(_courseId);
                    List<Curricula> currs = (List<Curricula>)_currDAL.GetCurriculas(_courseId);
                    List<List<CurriculaLineItem>> allLines = new List<List<CurriculaLineItem>>();

                    CourseFullDataViewModel ccvm = new CourseFullDataViewModel()
                    {
                        FullDataUserId = CurrentUser.Id,
                        DisplayUser = CurrentUser.FirstName,
                        Id = crs.Id,
                        EstimatedDuration = crs.EstimatedDuration,
                        Description = crs.Description,
                        Category = crs.CategoryName,
                        MyCurricula = currs,
                        TeacherFirstName = crs.TeacherFirstName,
                        TeacherLastName = crs.TeacherLastName,
                        TeacherId = crs.TeacherId,
                        Name = crs.Name
                    };

                    for (int i = 0; i<currs.Count; i++)
                    {
                        List<CurriculaLineItem> curlines = new List<CurriculaLineItem>();
                        curlines = (List<CurriculaLineItem>) _currDAL.GetCurriculaLineItems(ccvm.MyCurricula[i].Id);
                        allLines.Add(curlines);
                    }
                    ccvm.MyCurriculaLineItems = allLines;
                    result = View(ccvm);
                }
                else if (_role == 1)
                {
                   result = RedirectToAction("Dashboard", "Teacher");
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }
            return result;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CourseDetail(string courseId)
        //{
        //    ActionResult result = null;

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new Exception();
        //        }
        //        int cId = Convert.ToInt32(courseId);
        //        Course course = new Course();
        //        CourseFullDataViewModel _courseDetail = new CourseFullDataViewModel();
        //        course = _coursedb.GetCourse(cId);
        //        _courseDetail.MyCurricula =

        //    }

        #endregion

    }
}
