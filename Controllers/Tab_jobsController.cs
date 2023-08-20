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
    public class Tab_jobsController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: Tab_jobs
        public ActionResult Index()
        {
            var tab_jobs = db.Tab_jobs.Include(t => t.Ref_JobType);
            return View(tab_jobs.ToList());
        }

        // GET: Tab_jobs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_jobs tab_jobs = db.Tab_jobs.Find(id);
            if (tab_jobs == null)
            {
                return HttpNotFound();
            }
            return View(tab_jobs);
        }

        // GET: Tab_jobs/Create
        public ActionResult Create()
        {
            ViewBag.jobType = new SelectList(db.Ref_JobType, "JobType_id", "JobTypeDesc");
            return View();
        }

        // POST: Tab_jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "jobid,jobname,wuid,active,maxhours,jobType,RefrenceId")] Tab_jobs tab_jobs)
        {
            if (ModelState.IsValid)
            {
                db.Tab_jobs.Add(tab_jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jobType = new SelectList(db.Ref_JobType, "JobType_id", "JobTypeDesc", tab_jobs.jobType);
            return View(tab_jobs);
        }

        // GET: Tab_jobs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_jobs tab_jobs = db.Tab_jobs.Find(id);
            if (tab_jobs == null)
            {
                return HttpNotFound();
            }
            ViewBag.jobType = new SelectList(db.Ref_JobType, "JobType_id", "JobTypeDesc", tab_jobs.jobType);
            return View(tab_jobs);
        }

        // POST: Tab_jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "jobid,jobname,wuid,active,maxhours,jobType,RefrenceId")] Tab_jobs tab_jobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobType = new SelectList(db.Ref_JobType, "JobType_id", "JobTypeDesc", tab_jobs.jobType);
            return View(tab_jobs);
        }

        // GET: Tab_jobs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_jobs tab_jobs = db.Tab_jobs.Find(id);
            if (tab_jobs == null)
            {
                return HttpNotFound();
            }
            return View(tab_jobs);
        }

        // POST: Tab_jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tab_jobs tab_jobs = db.Tab_jobs.Find(id);
            db.Tab_jobs.Remove(tab_jobs);
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
