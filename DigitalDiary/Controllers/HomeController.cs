using DigitalDiary.Interface;
using DigitalDiary.Models;
using DigitalDiary.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class HomeController : Controller
    {
        //DigitalDiaryDataContext db = new DigitalDiaryDataContext();
        
        IMemoryRepository MemRepo = new MemoryRepository();
        IRepository<Memory> repo = new MemoryRepository();


        void SavePhoto(Memory m)
        {
            string FileName = Path.GetFileNameWithoutExtension(m.ImageFile.FileName);
            string extension = Path.GetExtension(m.ImageFile.FileName);
            FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
            m.imagepath = "~/Images/" + FileName;
            FileName = Path.Combine(Server.MapPath("~/Images/"), FileName);
            m.ImageFile.SaveAs(FileName);
            ModelState.Clear();
        }

        void ModifyDate(Memory m)
        {
            m.userid = (int)Session["UserId"];
            DateTime date = DateTime.Now;
            string mdate = date.ToLongDateString() + Environment.NewLine + date.ToLongTimeString();
            m.modifydate = mdate;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(MemRepo.GetUserMemoriesList((int)Session["UserId"]));
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Memory m)
        {
            SavePhoto(m);
            ModifyDate(m);
            //m.userid = (int)Session["UserId"];
            repo.Insert(m);
            return RedirectToAction("Details", new { id = m.memoryid });
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repo.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(Memory m)
        {
            ModifyDate(m);
            SavePhoto(m);
            repo.Update(m);
            return RedirectToAction("Details", new { id = m.memoryid });
        }


        //Details
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(repo.Get(id));
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}