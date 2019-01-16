using System;
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
        private DB_A3588B_BloodFinderDBEntities db = new DB_A3588B_BloodFinderDBEntities();

        // GET: AppUser/ID
        public JsonResult GetAppUserByID(int id)
        {
            AppUser appUser = db.AppUser.Where(x => x.AppUserID == id).FirstOrDefault();
            return Json(appUser, JsonRequestBehavior.AllowGet);
        }

        // GET: AppUser/GetAppUserByEmail?email=cs.mehmetkeskin@gmail.com
        public JsonResult GetAppUserByEmail()
        {
            String email = Request.QueryString["email"].ToString();

            AppUser appUser = db.AppUser.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (appUser == null)
            {
                return Json(new Response("NO_RECORD"), JsonRequestBehavior.AllowGet);
            }

            return Json(appUser, JsonRequestBehavior.AllowGet);
        }

        // POST: AppUser/Create
        [HttpPost]
        public JsonResult Create([Bind(Include = "AppUserID,NameSurname,PhoneNumber,FK_City,FK_Town,FK_BloodGroup,CreateDate,UpdateDate,Email")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.AppUser.Add(appUser);
                    db.SaveChanges();
                    AppUser user = db.AppUser.Where(x => x.Email.Equals(appUser.Email)).FirstOrDefault();
                    
                    return Json(user);
                }
                catch (System.Exception)
                {
                    return Json(new Response("ERROR"));
                }
            }
            
            return Json(new Response("OK"));
        }
    }
}
