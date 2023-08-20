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
    public class Tab_TemplateController : Controller
    {
        private PaperLessOffice_irEntities db = new PaperLessOffice_irEntities();

        // GET: Tab_Template
        public ActionResult Index()
        {
            var tab_Template = db.Tab_Template.Include(t => t.Tab_Process);
            return View(tab_Template.ToList());
        }

        // GET: Tab_Template/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_Template tab_Template = db.Tab_Template.Find(id);
            if (tab_Template == null)
            {
                return HttpNotFound();
            }
            return View(tab_Template);
        }

        // GET: Tab_Template/Create
        public ActionResult Create()
        {
            ViewBag.Procid = new SelectList(db.Tab_Process, "procid", "procname");
            return View();
        }

        // POST: Tab_Template/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "template_id,Procid,tempname,tempURL,temppath,tempactive,version")] Tab_Template tab_Template)
        {
            if (ModelState.IsValid)
            {
                db.Tab_Template.Add(tab_Template);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Procid = new SelectList(db.Tab_Process, "procid", "procname", tab_Template.Procid);
            return View(tab_Template);
        }

        // GET: Tab_Template/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_Template tab_Template = db.Tab_Template.Find(id);
            if (tab_Template == null)
            {
                return HttpNotFound();
            }
            ViewBag.Procid = new SelectList(db.Tab_Process, "procid", "procname", tab_Template.Procid);
            return View(tab_Template);
        }

        // POST: Tab_Template/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "template_id,Procid,tempname,tempURL,temppath,tempactive,version")] Tab_Template tab_Template)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tab_Template).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Procid = new SelectList(db.Tab_Process, "procid", "procname", tab_Template.Procid);
            return View(tab_Template);
        }

        // GET: Tab_Template/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tab_Template tab_Template = db.Tab_Template.Find(id);
            if (tab_Template == null)
            {
                return HttpNotFound();
            }
            return View(tab_Template);
        }

        // POST: Tab_Template/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tab_Template tab_Template = db.Tab_Template.Find(id);
            db.Tab_Template.Remove(tab_Template);
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
