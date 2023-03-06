using Application_Development_Project_2_Restuarant_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_.ViewModel
{
    public class ViewModelForm
    {
        public IEnumerable<Order> order { get; set; }
        public IEnumerable<OrderDetail> orderDetail { get; set; }
    }
}