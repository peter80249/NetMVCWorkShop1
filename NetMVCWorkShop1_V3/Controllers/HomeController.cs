using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NetMVCWorkShop1_V3.Models;

namespace NetMVCWorkShop1_V3.Controllers
{
    public class HomeController : Controller
    {
        db_BookEntities2 db = new db_BookEntities2();

        // GET: Home
        public ActionResult Index()
        {
            var book = db.ER.OrderBy(m => m.BOOK_ID).ToList();
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Creat(ER newdata)
        {
            db.ER.Add(newdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int BOOK_ID)
        {
            var dtbook = db.ER.Where(m => m.BOOK_ID == BOOK_ID).FirstOrDefault();
            db.ER.Remove(dtbook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int BOOK_ID)
        {
            var ed = db.ER.Where(m => m.BOOK_ID == BOOK_ID).FirstOrDefault();
            return View(ed);
        }
        [HttpPost]

        public ActionResult Edit(ER EER)
        {
            int id = EER.BOOK_ID;
            var ed = db.ER.Where(m => m.BOOK_ID == id).FirstOrDefault();
            ed.BOOK_CLASS = EER.BOOK_CLASS;
            ed.BOOK_NAME = EER.BOOK_NAME;
            ed.BOOK_BOUGHT_DATE = EER.BOOK_BOUGHT_DATE;
            ed.BOOK_STATUS = EER.BOOK_STATUS;
            ed.CREATE_USER = EER.CREATE_USER;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}