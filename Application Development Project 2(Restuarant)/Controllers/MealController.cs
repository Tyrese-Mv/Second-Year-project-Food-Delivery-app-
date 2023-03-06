using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
        // GET: Meal
        //[Authorize]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
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

        //public ActionResult Home()
        //{
        //    using (RestaurantEntities db = new RestaurantEntities())
        //    {
        //        return db.Items.ToList<Item>();
        //    }
        //}


        public ActionResult AddOrEdit(int id = 0)
        {
            Item item = new Item();
            if (id != 0)
            {
                using (Project2Entities db = new Project2Entities())
                {
                    item = db.Items.Where(x => x.ItmId == id).FirstOrDefault<Item>();
                }
            }
            return View(item);
        }


        [HttpPost]
        public ActionResult AddOrEdit(Item item)
        {
            try
            {
                //if (item.ImageUpload != null)
                //{
                //    string filename = Path.GetFileNameWithoutExtension(item.ImagePath);
                //    string extension = Path.GetExtension(item.ImagePath);
                //    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                //    item.ImagePath = "~/AppFiles/Images/" + filename;
                //    item.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), filename));
                //}
                using (Project2Entities db = new Project2Entities())
                {
                    if (item.ItmId == 0)
                    {
                        db.Items.Add(item);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllItems()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (Project2Entities db = new Project2Entities())
                {
                    Item item = db.Items.Where(x => x.ItmId == id).FirstOrDefault<Item>();
                    db.Items.Remove(item);
                    db.SaveChanges();
                }
                return Json(new { success = false, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}