using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetails
        Project2Entities db = new Project2Entities();
        // GET: Order
        public ActionResult Index()
        {
            var OrderList = db.OrderDetails.OrderByDescending(x => x.OdetId).ToList();
            return View(OrderList);
        }
    }
}