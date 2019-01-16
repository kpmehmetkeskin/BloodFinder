using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodFinderMvc.Models;

namespace BloodFinderMvc.Controllers
{
    public class TownController : Controller
    {
        private DB_A3588B_BloodFinderDBEntities db = new DB_A3588B_BloodFinderDBEntities();

        // GET: Town/GetTownsByCityID?cityID=123
        public JsonResult GetTownsByCityID()
        {
            int cityID = Convert.ToInt32(Request.QueryString["cityID"]);
            List<Town> townList = db.Town.Where(x => x.CityID == cityID).ToList();
            return Json(townList, JsonRequestBehavior.AllowGet);
        }

        // GET: Town/GetTownsByTownID?townID=123
        public JsonResult GetTownsByTownID()
        {
            int townID = Convert.ToInt32(Request.QueryString["townID"]);
            Town town = db.Town.Where(x => x.TownID == townID).FirstOrDefault();
            return Json(town, JsonRequestBehavior.AllowGet);
        }
    }
}
