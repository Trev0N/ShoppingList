using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class ShoppingProduct { 
    
        public string Name { get; set; }
        public double Quantity { get; set; }

        public ShoppingProduct(string name, double quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}