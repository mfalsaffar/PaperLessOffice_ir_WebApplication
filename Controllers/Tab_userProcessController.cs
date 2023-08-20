using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaperLessOffice_ir_WebApplication.Models;

namespace PaperLessOffice_ir_WebApplication.Controllers
{
    public class Tab_userProcessController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: Tab_userProcess
        //public ActionResult Index()
        //{
        //    var tab_userProcess = db.Tab_userProcess.Include(t => t.Tab_Process).Include(t => t.Tab_users);
        //    return View(tab_userProcess.ToList());
        //}

        public ActionResult Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var tab_userProcess = db.Tab_userProcess.Include(t => t.Tab_Process).Include(t => t.Tab_users);

            if (!string.IsNullOrEmpty(searchString))
            {
                tab_userProcess = tab_userProcess.Where(up => up.Tab_users.fullname.Contains(searchString));
            }

            return View(tab_userProcess.ToList());
        }


        // GET: Tab_userProcess/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_userProcess tab_userProcess = db.Tab_userProcess.Find(id);
            if (tab_userProcess == null)
            {
                return HttpNotFound();
            }
            return View(tab_userProcess);
        }

        // GET: Tab_userProcess/Create
        public ActionResult Create()
        {
            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname");
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username");
            return View();
        }

        // POST: Tab_userProcess/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "upid,userid,procid,upactive")] Tab_userProcess tab_userProcess)
        {
            if (ModelState.IsValid)
            {
                db.Tab_userProcess.Add(tab_userProcess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname", tab_userProcess.procid);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_userProcess.userid);
            return View(tab_userProcess);
        }

        // GET: Tab_userProcess/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_userProcess tab_userProcess = db.Tab_userProcess.Find(id);
            if (tab_userProcess == null)
            {
                return HttpNotFound();
            }
            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname", tab_userProcess.procid);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_userProcess.userid);
            return View(tab_userProcess);
        }

        // POST: Tab_userProcess/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "upid,userid,procid,upactive")] Tab_userProcess tab_userProcess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_userProcess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname", tab_userProcess.procid);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_userProcess.userid);
            return View(tab_userProcess);
        }

        // GET: Tab_userProcess/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_userProcess tab_userProcess = db.Tab_userProcess.Find(id);
            if (tab_userProcess == null)
            {
                return HttpNotFound();
            }
            return View(tab_userProcess);
        }

        // POST: Tab_userProcess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tab_userProcess tab_userProcess = db.Tab_userProcess.Find(id);
            db.Tab_userProcess.Remove(tab_userProcess);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
