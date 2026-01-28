using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourismMVC.Models;

namespace TourismMVC.Controllers
{
    public class AgencyProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AgencyProfiles
        public ActionResult Index()
        {
            var agencyProfiles = db.AgencyProfiles.Include(a => a.User);
            return View(agencyProfiles.ToList());
        }

        // GET: AgencyProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencyProfile agencyProfile = db.AgencyProfiles.Find(id);
            if (agencyProfile == null)
            {
                return HttpNotFound();
            }
            return View(agencyProfile);
        }

        // GET: AgencyProfiles/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");

            return View();
        }

        // POST: AgencyProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgencyId,AgencyName,ServicesOffered,Description,UserId")] AgencyProfile agencyProfile)
        {
            if (ModelState.IsValid)
            {
                db.AgencyProfiles.Add(agencyProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");

            return View(agencyProfile);
        }

        // GET: AgencyProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencyProfile agencyProfile = db.AgencyProfiles.Find(id);
            if (agencyProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");

            return View(agencyProfile);
        }

        // POST: AgencyProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgencyId,AgencyName,ServicesOffered,Description,UserId")] AgencyProfile agencyProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencyProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email");

            return View(agencyProfile);
        }

        // GET: AgencyProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgencyProfile agencyProfile = db.AgencyProfiles.Find(id);
            if (agencyProfile == null)
            {
                return HttpNotFound();
            }
            return View(agencyProfile);
        }

        // POST: AgencyProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgencyProfile agencyProfile = db.AgencyProfiles.Find(id);
            db.AgencyProfiles.Remove(agencyProfile);
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
