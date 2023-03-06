using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_.Models
{
    public class Item
    {
        public Item()
        {
            ImagePath = "~/AppFiles/Images/curry.jpg";
        }

        [Key]
        public int ItmId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Category { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Discription")]
        public string Discription { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        
        public int Quantity { get; set; }
        public int OdetId { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}