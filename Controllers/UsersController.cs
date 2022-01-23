using asp.net_login_form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.net_login_form.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public ActionResult Authorize(Users userModel)
        {
            using (UsersEntities db = new UsersEntities())
            {
                var userDetails = db.Users.Where(user => user.username == userModel.username && user.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Login", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.Id;
                    Session["username"] = userDetails.username;
                    Session["role"] = userDetails.role;
                    return RedirectToAction("Index", "Dashboard");
                }
            }
        }

        [HttpPost]
        public ActionResult SignUp(Users userModel)
        {
            using (UsersEntities db = new UsersEntities())
            {
                userModel.role = "User";
                db.Users.Add(userModel);
                db.SaveChanges();
                return RedirectToAction("Login", "Users");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}