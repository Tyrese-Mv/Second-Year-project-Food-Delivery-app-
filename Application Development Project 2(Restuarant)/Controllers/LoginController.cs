using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        readonly Project2Entities db = new Project2Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Admin admin)
        {
            if (db.Admins.Any(x => x.Name == admin.Name))
            {
                ViewBag.Notification = "This account is already registered";
                return View();
            }
            else
            {
                db.Admins.Add(admin);
                db.SaveChanges();

                Session["AdminIdSS"] = admin.AdminId.ToString();
                Session["NameSS"] = admin.Name.ToString();
                return RedirectToAction("Login", "Login");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {
            var checkLogin = db.Admins.Where(x => x.Name.Equals(admin.Name) && x.Password.Equals(admin.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["AdminIdSS"] = admin.AdminId.ToString();
                Session["NameSS"] = admin.Name.ToString();
                return RedirectToAction("Index", "Meal");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password!";
            }

            return View();
        }
    }
}