using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_.Models
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OdetId { get; set; }

        [Key]
        [Display(Name = "Item")]
        [Column(Order = 2)]
        public int ItmId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Total Price")]
        public decimal UnitPriceSale { get; set; }

        [Display(Name = "Quantity")]
        public int QuantitySale { get; set; }

        [Key]
        [Column(Order = 6)]
        public int OdId { get; set; }
        public Item Item { get; set; }
        public Order Order { get; set; }

    }
}