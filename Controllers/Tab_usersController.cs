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
    public class Tab_usersController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: Tab_users
        public ActionResult Index()
        {
            return View(db.Tab_users.ToList());
        }

        // GET: Tab_users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_users tab_users = db.Tab_users.Find(id);
            if (tab_users == null)
            {
                return HttpNotFound();
            }
            return View(tab_users);
        }

        // GET: Tab_users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tab_users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,username,pwd,fullname,wu,position,active,inbox,reportTo,viewWU,email,mobile,cid,location,fpid")] Tab_users tab_users)
        {
            if (ModelState.IsValid)
            {
                db.Tab_users.Add(tab_users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tab_users);
        }

        // GET: Tab_users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_users tab_users = db.Tab_users.Find(id);
            if (tab_users == null)
            {
                return HttpNotFound();
            }
            return View(tab_users);
        }

        // POST: Tab_users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,username,pwd,fullname,wu,position,active,inbox,reportTo,viewWU,email,mobile,cid,location,fpid")] Tab_users tab_users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tab_users);
        }

        // GET: Tab_users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_users tab_users = db.Tab_users.Find(id);
            if (tab_users == null)
            {
                return HttpNotFound();
            }
            return View(tab_users);
        }

        // POST: Tab_users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tab_users tab_users = db.Tab_users.Find(id);
            db.Tab_users.Remove(tab_users);
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
