using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BloodFinderMvc.Models;
using BloodFinderMvc.Utils;

namespace BloodFinderMvc.Controllers
{
    public class AppUserController : Controller
    {
        private BloodFinderDBEntities4 db = new BloodFinderDBEntities4();

        // GET: AppUser
        public ActionResult Index()
        {
            return View(db.AppUser.ToList());
        }

        // GET: AppUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.AppUser.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // GET: AppUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create([Bind(Include = "AppUserID,NameSurname,PhoneNumber,FK_City,FK_Town,FK_BloodGroup,CreateDate,UpdateDate,Guid")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.AppUser.Add(appUser);
                    db.SaveChanges();
                    return Json(new Response("OK"));
                }
                catch (System.Exception)
                {
                    return Json(new Response("ERROR"));
                }
            }
            
            return Json(new Response("OK"));
        }

        // GET: AppUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.AppUser.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppUserID,NameSurname,PhoneNumber,FK_City,FK_Town,FK_BloodGroup,CreateDate,UpdateDate,Guid")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appUser);
        }

        // GET: AppUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser appUser = db.AppUser.Find(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        // POST: AppUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppUser appUser = db.AppUser.Find(id);
            db.AppUser.Remove(appUser);
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
