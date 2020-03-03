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
    public class RegistrationController : Controller
    {
        IRepository<User> repo = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            repo.Insert(u);
            return RedirectToAction("Index", "LogIn");
        }
    }
}