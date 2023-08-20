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
    public class Tab_UserJobController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: Tab_UserJob
        public ActionResult Index()
        {
            var tab_UserJob = db.Tab_UserJob.Include(t => t.Tab_jobs).Include(t => t.Tab_users);
            return View(tab_UserJob.ToList());
        }

        // GET: Tab_UserJob/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_UserJob tab_UserJob = db.Tab_UserJob.Find(id);
            if (tab_UserJob == null)
            {
                return HttpNotFound();
            }
            return View(tab_UserJob);
        }

        // GET: Tab_UserJob/Create
        public ActionResult Create()
        {
            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname");
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username");
            return View();
        }

        // POST: Tab_UserJob/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ujid,userid,jobid,ujActive,onlyLate")] Tab_UserJob tab_UserJob)
        {
            if (ModelState.IsValid)
            {
                db.Tab_UserJob.Add(tab_UserJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_UserJob.jobid);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_UserJob.userid);
            return View(tab_UserJob);
        }

        // GET: Tab_UserJob/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_UserJob tab_UserJob = db.Tab_UserJob.Find(id);
            if (tab_UserJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_UserJob.jobid);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_UserJob.userid);
            return View(tab_UserJob);
        }

        // POST: Tab_UserJob/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ujid,userid,jobid,ujActive,onlyLate")] Tab_UserJob tab_UserJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_UserJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_UserJob.jobid);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_UserJob.userid);
            return View(tab_UserJob);
        }

        // GET: Tab_UserJob/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_UserJob tab_UserJob = db.Tab_UserJob.Find(id);
            if (tab_UserJob == null)
            {
                return HttpNotFound();
            }
            return View(tab_UserJob);
        }

        // POST: Tab_UserJob/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tab_UserJob tab_UserJob = db.Tab_UserJob.Find(id);
            db.Tab_UserJob.Remove(tab_UserJob);
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
