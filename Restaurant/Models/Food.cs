using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Food
    {
        [Key]
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public int CateId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        //public virtual ICollection<Category> Categories { get; set; }
    }
}