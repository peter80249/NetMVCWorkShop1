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

    }
}