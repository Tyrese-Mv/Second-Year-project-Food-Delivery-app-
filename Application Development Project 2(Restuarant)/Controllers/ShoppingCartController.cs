using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        Project2Entities db = new Project2Entities();
        // GET: ShoppingCart

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult AddtoCart(int id)
        {
            var itm = db.Items.SingleOrDefault(s => s.ItmId == id);
            if (itm != null)
            {
                GetCart().Add(itm);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }

        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_itm = int.Parse(form["Item_Id"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity(id_itm, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)

                total_item = cart.Total_Quantity_in_Cart();
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");
        }

        public ActionResult ShoppingSuccess()
        {
            return View();
        }

        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order order = new Order();
                order.OdDate = DateTime.Now;
                order.Description = form["Description"];
                order.Address = form["CustomerCode"];
                db.Orders.Add(order);

                foreach (var item in cart.Items)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OdId = order.OdId;
                    orderDetail.ItmId = item.Shopping_Product.ItmId;
                    orderDetail.Date = DateTime.Now;
                    orderDetail.UnitPriceSale = item.Shopping_Product.Price;
                    orderDetail.QuantitySale = item.Shopping_Quantity;
                    db.OrderDetails.Add(orderDetail);

                }
                db.SaveChanges();
                cart.ClearCart();

                return RedirectToAction("ShoppingSuccess", "ShoppingCart");
            }
            catch
            {

                return Content("Unsuccessful Checkout please make sure your details are correct");
            }
        }
    }
}