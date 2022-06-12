using AirnetMVC.DataService;
using AirnetMVC.Ui.Models;
using AirnetMVC.Ui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace AirnetMVC.Ui.Controllers
{
    public class UsersController : Controller
    {
        public UserRepository userRepository;
        public UsersController()
        {
            userRepository = new UserRepository();
        }

        public ActionResult Signup()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Signup(User _user)
        {
            _user.UserRole = "Member";
            userRepository.AddUser(_user);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDTO _user)
        {
            var x = userRepository.GetUserById(_user.Username);
            if (x == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            else
            {
                bool val = x.Username.Equals(_user.Username) && x.Password.Equals(_user.Password);
                if (val)
                {
                    if (x.UserRole == "Admin") return RedirectToAction("ViewPrepaidPlans", "Plan");
                    else if (x.UserRole == "Member") return RedirectToAction("ViewAddonPlans" , "Plan");
                }
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult ViewAllUsers()
        {
            var x = userRepository.GetAllUser();
            return View(x);
        }

        public ActionResult EditUser(string userId)
        {
            var x = userRepository.GetUserById(userId);
            return View(x);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            userRepository.EditUser(user);
            return RedirectToAction("ViewAllUsers");
        }

        public ActionResult DeleteUser(string userId)
        {
            userRepository.DeleteUser(userId);
            return RedirectToAction("ViewAllUsers");
        }

        public ActionResult ViewUserDetail(string userId)
        {
            var x = userRepository.GetUserById(userId);
            return View(x);
        }
    }
}