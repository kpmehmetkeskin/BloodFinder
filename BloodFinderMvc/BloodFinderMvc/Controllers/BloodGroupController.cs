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
    public class BloodGroupController : Controller
    {
        private DB_A3588B_BloodFinderDBEntities db = new DB_A3588B_BloodFinderDBEntities();

        // GET: BloodGroup
        public JsonResult Index()
        {
            List<BloodGroup> bloodGroupList = db.BloodGroup.ToList();
            return Json(bloodGroupList, JsonRequestBehavior.AllowGet);
        }

        // GET: BloodGroup/GetBloodGroupByID/5
        public JsonResult GetBloodGroupByID(int? id)
        {
            BloodGroup bloodGroup = db.BloodGroup.Where(x => x.BloodGroupID == id).FirstOrDefault();
            return Json(bloodGroup, JsonRequestBehavior.AllowGet);
        }
    }
}
