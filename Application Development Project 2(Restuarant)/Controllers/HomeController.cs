using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ViewHome()
        {
            return View(GetAllItems());
        }

        IEnumerable<Item> GetAllItems()
        {
            using (Project2Entities db = new Project2Entities())
            {
                return db.Items.ToList<Item>();
            }
        }

    }
}