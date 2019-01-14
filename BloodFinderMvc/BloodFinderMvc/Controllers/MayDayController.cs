using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodFinderMvc.Models;
using BloodFinderMvc.Utils;

namespace BloodFinderMvc.Controllers
{
    public class MayDayController : Controller
    {
        private BloodFinderDBEntities4 db = new BloodFinderDBEntities4();

        // GET: MayDay
        public JsonResult Index()
        {
            return Json(db.MayDay.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: MayDay/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayDay mayDay = db.MayDay.Find(id);
            if (mayDay == null)
            {
                return HttpNotFound();
            }
            return View(mayDay);
        }

        // GET: MayDay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MayDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "MayDayID,FK_AppUser,FK_City,FK_Town,FK_BloodGroup,Notes,CreateDate")] MayDay mayDay)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.MayDay.Add(mayDay);
                    db.SaveChanges();
                    return Json(new Response("OK"));
                }
                catch (Exception)
                {
                    return Json(new Response("ERROR"));
                }
            }

            return Json(new Response("OK"));
        }

        // GET: MayDay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayDay mayDay = db.MayDay.Find(id);
            if (mayDay == null)
            {
                return HttpNotFound();
            }
            return View(mayDay);
        }

        // POST: MayDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MayDayID,FK_AppUser,FK_City,FK_Town,FK_BloodGroup,Notes,CreateDate")] MayDay mayDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mayDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mayDay);
        }

        // GET: MayDay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayDay mayDay = db.MayDay.Find(id);
            if (mayDay == null)
            {
                return HttpNotFound();
            }
            return View(mayDay);
        }

        // POST: MayDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MayDay mayDay = db.MayDay.Find(id);
            db.MayDay.Remove(mayDay);
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
