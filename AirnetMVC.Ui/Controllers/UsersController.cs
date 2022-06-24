﻿using AirnetMVC.DataService;
using AirnetMVC.Ui.Models;
using AirnetMVC.Ui.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Security;

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
            string status = "3";
            if (x == null) { }/*return new HttpStatusCodeResult(HttpStatusCode.NotFound);*/
            else
            {
                bool val = x.Username.Equals(_user.Username) && x.Password.Equals(_user.Password);
                if (val)
                {
                    Session["username"] = _user.Username;
                    if (x.UserRole == "Admin")
                    {
                        status = "1";
                        /*return RedirectToAction("ViewPrepaidPlans", "Plan");*/
                    }
                    else if (x.UserRole == "Member")
                    {
                        status = "2";
                        /*return RedirectToAction("ViewPrepaidPlans", "Client");*/
                    }
                }

            }
            return  new JsonResult{Data = new { status = status }};
            /*return RedirectToAction("Login");*/
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Users");
        }

        [HttpGet]
        public ActionResult ViewAllUsers()
        {
            var x = userRepository.GetAllUser();
            return View(x);
        }

        public ActionResult EditUser(string id)
        {
            var x = userRepository.GetUserById(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            userRepository.EditUser(user);
            return RedirectToAction("ViewAllUsers");
        }

        public ActionResult DeleteUser(string id)
        {
            userRepository.DeleteUser(id);
            return RedirectToAction("ViewAllUsers");
        }

        public ActionResult ViewUserDetail(string id)
        {
            var x = userRepository.GetUserById(id);
            return View(x);
        }

        
    }
}