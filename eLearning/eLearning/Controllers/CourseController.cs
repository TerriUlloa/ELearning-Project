using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLearning.BusinessLogic;
using eLearning.DAL;
using eLearning.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eLearning.Controllers
{
    public class CourseController : AuthController
    {
        #region Member Variables
        private CourseDAL _courseDAL = null;
        private CategoryDAL _catDAL = null;
        private CourseCurriculaDAL _currDAL = null;
        #endregion

        #region Constructor
        public CourseController(ICourseDAL crsDal, ICategoryDAL catDAL, ICourseCurriculaDAL currDAL, IUserDAL db, IHttpContextAccessor httpContext) : base(db, httpContext)
        {
            _courseDAL = (CourseDAL)crsDal;
            _catDAL = (CategoryDAL)catDAL;
            _currDAL = (CourseCurriculaDAL)currDAL;
        }
        #endregion

        #region public Methods / Actions
        /// <summary>
        /// The Index page should load the show all courses page.
        /// For the purposes of Create, should be a teacher or no see.
        /// For the purposes of Edit, should be course teacher.
        /// For the purpose of Delete, should be course teacher.
        /// For the purpose of Display(Index) should display all courses either registered or all courses.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Course> courses = new List<Course>();
            List<CourseViewModel> cvms = new List<CourseViewModel>();
            CourseViewModel cvm = null;

            courses = (List<Course>)_courseDAL.GetCourses();
            foreach (Course item in courses)
            {
                cvm = new CourseViewModel()
                {
                    Description = item.Description,
                    EstimatedDuration = item.EstimatedDuration,
                    Id = item.Id,
                    Name = item.Name,
                    TeacherFirstName = item.TeacherFirstName,
                    TeacherId = item.TeacherId,
                    TeacherLastName = item.TeacherLastName,
                    Category = item.CategoryName
                };
                cvms.Add(cvm);
            }

            return View(cvms);
        }

        public IActionResult Participate(int courseId)
        {
            ActionResult result = null;
            int _role = 0;
            if (IsAuthenticated)
            {
                _role = CurrentUser.RoleId;
                if (_role == 2)
                {
                    Course crs = _courseDAL.GetCourse(courseId);
                    List<Curricula> currs = (List<Curricula>)_currDAL.GetCurriculas(courseId);
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
                else if (_role == 1)
                {
                    result = RedirectToAction("Dashboard", "Teacher", new { studentId = CurrentUser.Id });
                }
            }
            else
            {
                result = RedirectToAction("Login", "User");
            }
            return result;
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddCourseViewModel acvm = new AddCourseViewModel()
            {
                Categories = GetCategories()
            };
            return View(acvm);
        }

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Create(AddCourseViewModel acvm)
        {
            IActionResult result = null;

            // Are there errors
            if (!ModelState.IsValid)
            {
                result = View("Create");
            }
            else
            {
                try
                {

                    Course crs = new Course()
                    {
                        Description = acvm.Description,
                        EstimatedDuration = acvm.EstimatedDuration,
                        Name = acvm.Name,
                        CategoryId = acvm.CategoryId
                    };
                    RoleManager rm = GetSessionData<RoleManager>("user");

                    crs.TeacherId = rm.User.Id; //BRP NEEDS TO CHANGE once login ID is stored.  Fixed.

                    _courseDAL.SaveCourse(crs);

//                    result = RedirectToAction("Index", "Course", "");
                    result = RedirectToAction("Dashboard", "Teacher", "");
                }
                catch (Exception ex)
                {
                    result = View();
                }
            }

            return result;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course crs = _courseDAL.GetCourse(id);
            EditCourseViewModel ecvm = new EditCourseViewModel()
            {
                Id = crs.Id,
                Description = crs.Description,
                EstimatedDuration = crs.EstimatedDuration,
                Name = crs.Name,
                Categories = GetCategories(),
                CategoryId = crs.CategoryId
            };
            return View(ecvm);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(EditCourseViewModel ecvm)
        {
            IActionResult result = null;

            // Are there errors
            if (!ModelState.IsValid)
            {
                result = View("Edit");
            }
            else
            {
                try
                {
                    Course crs = new Course()
                    {
                        Description = ecvm.Description,
                        EstimatedDuration = ecvm.EstimatedDuration,
                        Name = ecvm.Name,
                        Id = ecvm.Id,
                        CategoryId = ecvm.CategoryId
                    };
                    _courseDAL.UpdateCourse(crs);

                    result = RedirectToAction("Index", "Course", "");
                }
                catch (Exception ex)
                {
                    result = View();
                }
            }

            return result;

        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            IActionResult result = null;

            // Are there errors
            if (!ModelState.IsValid)
            {
                result = View("Delete");
            }
            else
            {
                try
                {
                    _courseDAL.DeleteCourse(id);

                    result = RedirectToAction("Index", "Course", "");
                }
                catch (Exception ex)
                {
                    //BRP Fix, might want to redirect to an error or something.
                    result = View("Index");
                }
            }

            return result;

        }

        public IActionResult Details(int id)
        {
            CourseCurriculaViewModel ccvm = new CourseCurriculaViewModel();
            Course crs = _courseDAL.GetCourse(id);
            List<Curricula> currs = (List<Curricula>)_currDAL.GetCurriculas(crs.Id);

            ccvm.Id = crs.Id;
            ccvm.EstimatedDuration = crs.EstimatedDuration;
            ccvm.Description = crs.Description;
            ccvm.Category = crs.CategoryName;
            ccvm.myCurricula = currs;
            ccvm.TeacherFirstName = crs.TeacherFirstName;
            ccvm.TeacherLastName = crs.TeacherLastName;
            ccvm.TeacherId = crs.TeacherId;
            ccvm.Name = crs.Name;
            return View(ccvm);
        }

        public IActionResult CurriculaDetail(int id)
        {
            Curricula curr = new Curricula();
            CurriculaDetailViewModel cdvm = new CurriculaDetailViewModel();
            
            curr = _currDAL.GetCurricula(id);
            cdvm.CourseId = curr.CourseId;
            cdvm.CourseSession = curr.CourseSession;
            cdvm.Description = curr.Description;
            cdvm.Details = (List<CurriculaLineItem>)_currDAL.GetCurriculaLineItems(id);
            cdvm.Id = curr.Id;

            return View(cdvm);
        }

        [HttpGet]
        public IActionResult CurriculaDetailEdit(int lineItemId)
        {
            CurriculaLineItem cli = _currDAL.GetCurriculaLineItem(lineItemId);
            CurriculaLineItemViewModel clivm = new CurriculaLineItemViewModel();

            clivm.CurriculaId = cli.CurriculaId;
            clivm.CurriculaTypeId = cli.CurriculaTypeId;
            clivm.Description = cli.Description;
            clivm.FileName = cli.FileName;
            clivm.Id = cli.Id;

            return View(clivm);
        }

        [HttpPost]
        public IActionResult CurriculaDetailEdit(CurriculaLineItemViewModel clivm)
        {
            IActionResult result = null;

            // Are there errors
            if (!ModelState.IsValid)
            {
                result = View("CurriculaDetailEdit");
            }
            else
            {
                try
                {
                    CurriculaLineItem cli = new CurriculaLineItem()
                    {
                        CurriculaId = clivm.CurriculaId,
                        CurriculaTypeId = clivm.CurriculaTypeId,
                        Description = clivm.Description,
                        FileName = clivm.FileName,
                        Id = clivm.Id,
                    };
                    _currDAL.UpdateCurriculaLineItem(cli);

                    result = RedirectToAction("CurriculaDetail", "Course", "");
                }
                catch (Exception ex)
                {
                    result = View();
                }
            }

            return result;
        }

        public IActionResult CurriculaAdd(int courseId)
        {
            AddCurriculaViewModel acvm = new AddCurriculaViewModel()
            {
                CourseId = courseId
            };

            return View(acvm);

        }

        [HttpPost]
        public IActionResult CurriculaAdd(AddCurriculaViewModel acvm)
        {
            Curricula curr = new Curricula()
            {
                CourseId = acvm.CourseId,
                CourseSession = acvm.CourseSession,
                Description = acvm.Description
            };

            _currDAL.SaveCurricula(curr);

            return RedirectToAction("Details", new { id = curr.CourseId });

        }

        public IActionResult DetailEdit(int id)
        {
            Curricula cur = _currDAL.GetCurricula(id);
            EditCurriculaViewModel ecvm = new EditCurriculaViewModel()
            {
                CourseId = cur.CourseId,
                CourseSession = cur.CourseSession,
                Description = cur.Description,
                Id = cur.Id
            };
            return View(ecvm);

        }

        [HttpPost]
        public IActionResult DetailEdit(EditCurriculaViewModel ecvm)
        {
            IActionResult result = null;

            // Are there errors
            if (!ModelState.IsValid)
            {
                result = View("DetailEdit", new { id = ecvm.Id });
            }
            else
            {
                try
                {
                    Curricula cur = new Curricula()
                    {
                        CourseId = ecvm.CourseId,
                        CourseSession = ecvm.CourseSession,
                        Description = ecvm.Description,
                        Id = ecvm.Id
                    };
                    _currDAL.UpdateCurricula(cur);

                    result = RedirectToAction("Details", "Course", new { id = cur.CourseId } );
                }
                catch (Exception ex)
                {
                    result = View();
                }
            }

            return result;
        }

        public IActionResult LineItemAdd(int CurriculaId)
        {
            return View();
        }

        public IActionResult LineItemEdit(int LineItemId)
        {
            return View();
        }


        public IActionResult DeleteCurriculaDetails(int id)
        {
            return View();
        }

        private List<SelectListItem> GetCategories()
        {
            List<Category> cats = new List<Category>();
            List<SelectListItem> listItems = new List<SelectListItem>();
            SelectListItem sli = null;

            cats = (List<Category>)_catDAL.GetCategories();
            foreach (var item in cats)
            {
                sli = new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(sli);
            }

            return listItems;

        }
        #endregion

    }
}