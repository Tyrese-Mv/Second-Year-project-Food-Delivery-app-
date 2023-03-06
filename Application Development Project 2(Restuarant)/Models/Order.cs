using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_.Models
{
    public class Order
    {
   
        [Key]
        public int OdId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime OdDate { get; set; }

        [Display(Name = "Customer FullNames")]
        public string Description { get; set; }

        public string Address { get; set; }
       
    }
}