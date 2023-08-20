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
    public class Tab_wfTransactionsController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: Tab_wfTransactions
        public ActionResult Index()
        {
            var tab_wfTransactions = db.Tab_wfTransactions.Include(t => t.tab_Options).Include(t => t.Tab_users).Include(t => t.Tab_workflow);
            return View(tab_wfTransactions.ToList());
        }

        // GET: Tab_wfTransactions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_wfTransactions tab_wfTransactions = db.Tab_wfTransactions.Find(id);
            if (tab_wfTransactions == null)
            {
                return HttpNotFound();
            }
            return View(tab_wfTransactions);
        }

        // GET: Tab_wfTransactions/Create
        public ActionResult Create()
        {
            ViewBag.optionselected = new SelectList(db.tab_Options, "optionid", "OptName");
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username");
            ViewBag.wfid = new SelectList(db.Tab_workflow, "wfid", "doc");
            return View();
        }

        // POST: Tab_wfTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wftid,wfid,transdate,optionselected,note,userid,VerDoc")] Tab_wfTransactions tab_wfTransactions)
        {
            if (ModelState.IsValid)
            {
                db.Tab_wfTransactions.Add(tab_wfTransactions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.optionselected = new SelectList(db.tab_Options, "optionid", "OptName", tab_wfTransactions.optionselected);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_wfTransactions.userid);
            ViewBag.wfid = new SelectList(db.Tab_workflow, "wfid", "doc", tab_wfTransactions.wfid);
            return View(tab_wfTransactions);
        }

        // GET: Tab_wfTransactions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_wfTransactions tab_wfTransactions = db.Tab_wfTransactions.Find(id);
            if (tab_wfTransactions == null)
            {
                return HttpNotFound();
            }
            ViewBag.optionselected = new SelectList(db.tab_Options, "optionid", "OptName", tab_wfTransactions.optionselected);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_wfTransactions.userid);
            ViewBag.wfid = new SelectList(db.Tab_workflow, "wfid", "doc", tab_wfTransactions.wfid);
            return View(tab_wfTransactions);
        }

        // POST: Tab_wfTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "wftid,wfid,transdate,optionselected,note,userid,VerDoc")] Tab_wfTransactions tab_wfTransactions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_wfTransactions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.optionselected = new SelectList(db.tab_Options, "optionid", "OptName", tab_wfTransactions.optionselected);
            ViewBag.userid = new SelectList(db.Tab_users, "userid", "username", tab_wfTransactions.userid);
            ViewBag.wfid = new SelectList(db.Tab_workflow, "wfid", "doc", tab_wfTransactions.wfid);
            return View(tab_wfTransactions);
        }

        // GET: Tab_wfTransactions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_wfTransactions tab_wfTransactions = db.Tab_wfTransactions.Find(id);
            if (tab_wfTransactions == null)
            {
                return HttpNotFound();
            }
            return View(tab_wfTransactions);
        }

        // POST: Tab_wfTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tab_wfTransactions tab_wfTransactions = db.Tab_wfTransactions.Find(id);
            db.Tab_wfTransactions.Remove(tab_wfTransactions);
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
