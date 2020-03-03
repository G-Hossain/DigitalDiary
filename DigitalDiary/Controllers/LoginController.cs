using DigitalDiary.Interface;
using DigitalDiary.Models;
using DigitalDiary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class LoginController : Controller
    {
        IUserRepository UserRepo = new UserRepository();
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            var LogInDetails = UserRepo.GetLogInInfo(u.name, u.password);
            if (LogInDetails == null)
            {
                return View("Index");
            }
            else
            {
                Session["UserId"] = LogInDetails.userid;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LogIn");
        }
    }
}