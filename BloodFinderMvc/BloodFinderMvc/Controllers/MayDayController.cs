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
        private DB_A3588B_BloodFinderDBEntities db = new DB_A3588B_BloodFinderDBEntities();

        // GET: MayDay?cityID=1&townID=1&bloodGroup=1
        public JsonResult Index()
        {
            int cityID = Convert.ToInt32(Request.QueryString["cityID"]);
            int townID = Convert.ToInt32(Request.QueryString["townID"]);
            int bloodGroup = Convert.ToInt32(Request.QueryString["bloodGroup"]);

            List<MayDay> maydayList = db.MayDay.Where(x => x.FK_City == cityID && x.FK_Town == townID && x.FK_BloodGroup == bloodGroup).ToList();

            return Json(maydayList, JsonRequestBehavior.AllowGet);
        }

        // POST: MayDay/Create
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

        // POST: MayDay/Delete/5
        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                MayDay mayDay = db.MayDay.Find(id);
                db.MayDay.Remove(mayDay);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new Response("ERROR"));
            }
            
            return Json(new Response("OK"));
        }


    }
}
