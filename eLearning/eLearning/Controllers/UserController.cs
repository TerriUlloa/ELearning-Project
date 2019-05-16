using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using eLearning.DAL;
using eLearning.Exceptions;
using eLearning.Models;
using eLearning.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace eLearning.Controllers
{
    public class UserController : AuthController
    {
        #region Constructor
        public UserController(IUserDAL db, IHttpContextAccessor httpContext) : base(db, httpContext)
        {
           
        }
        #endregion

        #region public Methods / Actions
        [HttpGet]
        public ActionResult Login()
        {
            if (IsAuthenticated)
            {
                LogoutUser();
            }

            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            ActionResult result = null;
            int _role = 0;
            int _id = 0;

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                LoginUser(model.Username, model.Password);
                _role = CurrentUser.RoleId;
                _id = CurrentUser.Id;



                if (_role == 1)
                {
                    result = RedirectToAction("Dashboard", "Teacher");
                }
                else if (_role == 2)
                {
                   
                    result = RedirectToAction("Dashboard", "Student",new { studentId = _id });
                }
            }
            catch (Exception ex)
            {
                result = View("Login");
                TempData["error"] = ex.Message;
            }

            return result;
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (IsAuthenticated)
            {
                LogoutUser();
            }

            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            ActionResult result = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                try
                {
                    User userModel = new User()
                    {
                        ConfirmPassword = model.ConfirmPassword,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Username = model.Username,
                        Email = model.Email,
                        Role = model.Role
                    };
                    RegisterUser(userModel);
                }
                catch (UserExistsException)
                {
                   
                    TempData["error"] = "The username is already taken.";
                    throw;
                }
                if (model.Role.Equals("teacher"))
                {
                    result = RedirectToAction("Dashboard", "Teacher");
                }
                else if (model.Role.Equals("student"))
                {
                    result = RedirectToAction("Dashboard", "Student");
                }
            }
            catch (Exception ex)
            {
                result = View("Register");
            }

            return result;
        }
        #endregion
    }
}