using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        [Required]
        public string ShipName { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Required]
        public string ShipAddress { get; set; }
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        [Required]
        public string ShipEmail { get; set; }
        public int Status { get; set; }
    }
}