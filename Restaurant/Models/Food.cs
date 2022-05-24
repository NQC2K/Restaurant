using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    [Table("Foods")]
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodID { get; set; }
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Required]
        public string FoodName { get; set; }
        public int CateId { get; set; }
        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
        public double PriceDiscount { get; set; }
        [Required]
        public string Image { get; set; }

    }
}