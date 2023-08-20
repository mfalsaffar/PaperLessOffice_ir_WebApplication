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
    public class tab_OptionsController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: tab_Options
        public ActionResult Index()
        {
            var tab_Options = db.tab_Options.Include(t => t.Ref_wfStatus).Include(t => t.Tab_jobs).Include(t => t.Tab_jobs1).Include(t => t.Tab_Process);
            return View(tab_Options.ToList());
        }

        // GET: tab_Options/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tab_Options tab_Options = db.tab_Options.Find(id);
            if (tab_Options == null)
            {
                return HttpNotFound();
            }
            return View(tab_Options);
        }

        // GET: tab_Options/Create
        public ActionResult Create()
        {
            ViewBag.nxtstatus = new SelectList(db.Ref_wfStatus, "code", "wfstatus");
            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname");
            ViewBag.nextjob = new SelectList(db.Tab_jobs, "jobid", "jobname");
            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname");
            return View();
        }

        // POST: tab_Options/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "optionid,OptName,Option_Type,Query_id,Procedure_name,Procedure_Param,pjid,procid,jobid,nextjob,optactive,nxtstatus,nxtmaxtime,WCF_id,WCF_method,WCF_Param,CallFunction,FunctionParamList,AutomaticOpt")] tab_Options tab_Options)
        {
            if (ModelState.IsValid)
            {
                db.tab_Options.Add(tab_Options);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nxtstatus = new SelectList(db.Ref_wfStatus, "code", "wfstatus", tab_Options.nxtstatus);
            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_Options.jobid);
            ViewBag.nextjob = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_Options.nextjob);
            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname", tab_Options.procid);
            return View(tab_Options);
        }

        // GET: tab_Options/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tab_Options tab_Options = db.tab_Options.Find(id);
            if (tab_Options == null)
            {
                return HttpNotFound();
            }
            ViewBag.nxtstatus = new SelectList(db.Ref_wfStatus, "code", "wfstatus", tab_Options.nxtstatus);
            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_Options.jobid);
            ViewBag.nextjob = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_Options.nextjob);
            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname", tab_Options.procid);
            return View(tab_Options);
        }

        // POST: tab_Options/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "optionid,OptName,Option_Type,Query_id,Procedure_name,Procedure_Param,pjid,procid,jobid,nextjob,optactive,nxtstatus,nxtmaxtime,WCF_id,WCF_method,WCF_Param,CallFunction,FunctionParamList,AutomaticOpt")] tab_Options tab_Options)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_Options).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nxtstatus = new SelectList(db.Ref_wfStatus, "code", "wfstatus", tab_Options.nxtstatus);
            ViewBag.jobid = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_Options.jobid);
            ViewBag.nextjob = new SelectList(db.Tab_jobs, "jobid", "jobname", tab_Options.nextjob);
            ViewBag.procid = new SelectList(db.Tab_Process, "procid", "procname", tab_Options.procid);
            return View(tab_Options);
        }

        // GET: tab_Options/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tab_Options tab_Options = db.tab_Options.Find(id);
            if (tab_Options == null)
            {
                return HttpNotFound();
            }
            return View(tab_Options);
        }

        // POST: tab_Options/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tab_Options tab_Options = db.tab_Options.Find(id);
            db.tab_Options.Remove(tab_Options);
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
