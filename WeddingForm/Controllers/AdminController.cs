using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingForm.Models;
using System.Security;
using System.Web.Security;

namespace WeddingForm.Controllers
{
    public class AdminController : Controller
    {
        dataweddingEntities db = new dataweddingEntities();
        // GET: Admin

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



        public ActionResult Index()
        {
            var member = db.form.ToList();
            return View(member);
        }



    }
}