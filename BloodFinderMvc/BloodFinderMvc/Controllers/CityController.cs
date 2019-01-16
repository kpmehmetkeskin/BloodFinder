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
    public class CityController : Controller
    {
        private DB_A3588B_BloodFinderDBEntities db = new DB_A3588B_BloodFinderDBEntities();

        // GET: City
        public JsonResult Index()
        {
            List<City> cityList = db.City.ToList();
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }

        // GET: City/Details/5
        public JsonResult GetCityByID(int? id)
        {
            City city = db.City.Where(x => x.CityID == id).FirstOrDefault();
            return Json(city, JsonRequestBehavior.AllowGet);
        }
    }
}
