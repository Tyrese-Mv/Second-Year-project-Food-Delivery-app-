using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_.Models
{
    public class Driver
    {

        [Key]
        public int DivId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string DrivName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string DrivSurname { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [Range(1, 10)]
        public int DrivPhone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string DrivEmail { get; set; }

        [Required]
        [Display(Name = "Create Password")]
        [DataType(DataType.Password)]
        public string DrivPassword { get; set; }

      
    }
}