using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        // GET: Customer
        Project2Entities db = new Project2Entities();
        // GET: Customer
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            db.Customers.Add(cus);
            db.SaveChanges();
            return View();
        }

        public ActionResult ViewCustomers()
        {
            var CustomerList = db.Customers.OrderByDescending(x => x.CusId).ToList();
            return View(CustomerList);
        }

    }
}
