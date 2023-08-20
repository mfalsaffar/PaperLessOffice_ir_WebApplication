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
    public class Tab_ProcessController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: Tab_Process
        public ActionResult Index()
        {
            return View(db.Tab_Process.ToList());
        }

        // GET: Tab_Process/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_Process tab_Process = db.Tab_Process.Find(id);
            if (tab_Process == null)
            {
                return HttpNotFound();
            }
            return View(tab_Process);
        }

        // GET: Tab_Process/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tab_Process/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "procid,procname,procactive,startjob,ProcType,startjobtime,procwu,ToBeArchived,helplink")] Tab_Process tab_Process)
        {
            if (ModelState.IsValid)
            {
                db.Tab_Process.Add(tab_Process);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tab_Process);
        }

        // GET: Tab_Process/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_Process tab_Process = db.Tab_Process.Find(id);
            if (tab_Process == null)
            {
                return HttpNotFound();
            }
            return View(tab_Process);
        }

        // POST: Tab_Process/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "procid,procname,procactive,startjob,ProcType,startjobtime,procwu,ToBeArchived,helplink")] Tab_Process tab_Process)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_Process).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tab_Process);
        }

        // GET: Tab_Process/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_Process tab_Process = db.Tab_Process.Find(id);
            if (tab_Process == null)
            {
                return HttpNotFound();
            }
            return View(tab_Process);
        }

        // POST: Tab_Process/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tab_Process tab_Process = db.Tab_Process.Find(id);
            db.Tab_Process.Remove(tab_Process);
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
