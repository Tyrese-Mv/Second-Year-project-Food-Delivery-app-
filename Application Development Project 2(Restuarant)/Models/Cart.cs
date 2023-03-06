using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_.Models
{
    public class CartItem
    {
        public Item Shopping_Product { get; set; }
        public int Shopping_Quantity { get; set; }
    }

    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Item itm, int quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.Shopping_Product.ItmId == itm.ItmId);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    Shopping_Product = itm,
                    Shopping_Quantity = quantity
                });

            }
            else
            {
                item.Shopping_Quantity += quantity;
            }

        }
        public void Update_Quantity(int id, int quantity)
        {
            var item = items.Find(s => s.Shopping_Product.ItmId == id);
            if (item != null)
            {
                item.Shopping_Quantity = quantity;
            }

        }
        public double Total()
        {
            var total = items.Sum(s => s.Shopping_Product.Price * s.Shopping_Quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s.Shopping_Product.ItmId == id);
        }

        public int Total_Quantity_in_Cart()
        {
            return items.Sum(s => s.Shopping_Quantity);
        }

        public void ClearCart()
        {
            items.Clear();
        }
    }
}