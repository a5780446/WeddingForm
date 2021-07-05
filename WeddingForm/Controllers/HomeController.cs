using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WeddingForm.Models;

namespace WeddingForm.Controllers
{
    
    public class HomeController : Controller
    {
        dataweddingEntities db = new dataweddingEntities();
        //get:login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string ID, string PWSD)
        {
            var ans = db.user.Where(m => m.userid == ID && m.pswd == PWSD).FirstOrDefault();
            if (ans == null)
            {
                ViewBag.Message = "不是此APP使用者喔";
                return View();
            }
            else
            {
                Session["back"] = ans.userid + "歡迎回來本系統";
                Session["log"] = "1";
                FormsAuthentication.RedirectFromLoginPage(ID, true);
                return RedirectToAction("Index");

            }
        }

        /*public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }*/

        // GET: Home
        [Authorize(Users ="A0001")]
        public ActionResult Index()
        {
            var member = db.form.ToList();
            return View(member);
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(form member)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.form.Where(m => m.Id == member.Id).FirstOrDefault();
                if (temp != null)
                {
                    ViewBag.Error = true;
                    return View(member);
                }
                db.form.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }
        public ActionResult Del(int sid)
        {
            var member = db.form.Where(m => m.Id == sid).FirstOrDefault();
            db.form.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}