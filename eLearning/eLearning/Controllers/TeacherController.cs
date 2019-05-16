using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using eLearning.Models;
using eLearning.DAL;

namespace eLearning.Controllers
{
    public class TeacherController : AuthController
    {
        #region Member Variables
        protected ICourseDAL _courseDAL = null;
        protected ICourseCurriculaDAL _currDAL = null;
        protected IUserDAL _userDAL = null;
        #endregion

        #region Constructor
        public TeacherController(IUserDAL db, ICourseDAL courseDAL, ICourseCurriculaDAL currDAL, IHttpContextAccessor httpContext) : base(db, httpContext)
        {
            _courseDAL = courseDAL;
            _currDAL = currDAL;
            _userDAL = db;
        }
        #endregion

        #region public Methods/ Actions

        public IActionResult Dashboard()
        {
            ActionResult result = null;
            int _role = 0;
            if (IsAuthenticated)
            {
                _role = CurrentUser.RoleId;
                if (_role == 1)
                {
                    List<Course> courses = (List<Course>)_courseDAL.GetTeacherCourses(CurrentUser.Id);
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
                            StudentCount = _courseDAL.CourseRegistrations(entry.Id),
                            CourseRating = _courseDAL.CourseRating(entry.Id)
                        };
                        courseList.BrowseCourseList.Add(viewCourse);
                    }
                    result = View(courseList);
                }
                else if (_role == 2)
                {
                    result = RedirectToAction("Dashboard", "Student", new { studentId = CurrentUser.Id });
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }
            return result;
        }

        public IActionResult Details(int id)
        {
            ActionResult result = null;
            int _role = 0;
            if (IsAuthenticated)
            {
                _role = CurrentUser.RoleId;
                if (_role == 1)
                {
                    Course crs = _courseDAL.GetCourse(id);
                    List<Curricula> currs = (List<Curricula>)_currDAL.GetCurriculas(id);
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

                    for (int i = 0; i < currs.Count; i++)
                    {
                        List<CurriculaLineItem> curlines = new List<CurriculaLineItem>();
                        curlines = (List<CurriculaLineItem>)_currDAL.GetCurriculaLineItems(ccvm.MyCurricula[i].Id);
                        allLines.Add(curlines);
                    }
                    ccvm.MyCurriculaLineItems = allLines;
                    result = View(ccvm);
                }
                else if (_role == 2)
                {
                   result = RedirectToAction("Dashboard", "Student", new { studentId = CurrentUser.Id });
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }
            return result;
        }

        public IActionResult Progress(int id)
        {
            ActionResult result = null;
            int _role = 0;
            if (IsAuthenticated)
            {
                _role = CurrentUser.RoleId;
                if (_role == 1)
                {
                    Course crs = _courseDAL.GetCourse(id);
                    IList<StudentProgress> courseStudents = _courseDAL.GetAllStudentProgress(crs.Id);
                    List<StudentProgressViewModel> sProgressVM = new List<StudentProgressViewModel>();

                    foreach (StudentProgress student in courseStudents)
                    {
                        StudentProgressViewModel spVM = new StudentProgressViewModel();
                        UserItem userData = _userDAL.GetUserItem(student.StudentId);
                        spVM.FirstName = userData.FirstName;
                        spVM.LastName = userData.LastName;
                        spVM.StudentId = student.StudentId;
                        spVM.CoursesComplete = student.CoursesComplete;
                        spVM.TotalLineItems = _courseDAL.CourseLineItems(crs.Id);
                        spVM.Progress = (spVM.CoursesComplete * 100) / spVM.TotalLineItems ;
                        sProgressVM.Add(spVM);
                    }
                    result = View(sProgressVM);
                }
                else if (_role == 2)
                {
                    result = RedirectToAction("Dashboard", "Student", new { studentId = CurrentUser.Id });
                }

            }
            else
            {
                result = RedirectToAction("Login", "User");
            }
            return result;
        }

    }
    #endregion
}