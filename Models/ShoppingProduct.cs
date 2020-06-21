using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class ShoppingProduct {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }

        public ShoppingProduct(string name, double quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public ShoppingProduct()
        {
        }
    }
}