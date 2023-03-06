using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_.Models
{
    public class Customer
    {
        [Key]
        public int CusId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string CusName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string CusSurname { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string CusEmail { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [Range(1,10)]
        public int CusPhone { get; set; }

        [Required]
        [Display(Name = "Create Password")]
        [DataType(DataType.Password)]
        public string CusPassword { get; set; }

        
        
    }
}