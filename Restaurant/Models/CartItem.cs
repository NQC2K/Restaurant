using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    [Serializable]
    public class CartItem
    {
        public Food Food { get; set; }
        public int Quantity { get; set; }
    }
}