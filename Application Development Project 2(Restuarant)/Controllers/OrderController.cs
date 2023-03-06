using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        Project2Entities db = new Project2Entities();
        // GET: Order
        public ActionResult Index()
        {
            var OrderList = db.Orders.OrderByDescending(x => x.OdId).ToList();
            return View(OrderList);
        }

        public ActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Where(x => x.OdId == id).FirstOrDefault<Order>();
            db.Orders.Remove(order);
            db.SaveChanges();

            return RedirectToAction("Index", "Order");
        }
    }
}