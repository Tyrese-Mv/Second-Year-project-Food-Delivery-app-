using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        // GET: Driver
        readonly Project2Entities db = new Project2Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View(db.Drivers.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Driver driver)
        {
            if (db.Drivers.Any(x => x.DrivName == driver.DrivName))
            {
                ViewBag.Notification = "This account is already registered";
                return View();
            }
            else
            {
                db.Drivers.Add(driver);
                db.SaveChanges();

                Session["DivIdSS"] = driver.DivId.ToString();
                Session["DrivNameSS"] = driver.DrivName.ToString();
                return RedirectToAction("Login", "Driver");
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Driver");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Driver driver)
        {
            var checkLogin = db.Drivers.Where(x => x.DrivName.Equals(driver.DrivName) && x.DrivPassword.Equals(driver.DrivPassword)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["DivIdSS"] = driver.DivId.ToString();
                Session["DrivNameSS"] = driver.DrivName.ToString();
                return RedirectToAction("Index", "Order");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password!";
            }

            return View();
        }
    }
}