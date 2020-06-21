using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class ShoppingArrayList
    {
        public List<ShoppingProduct> Products { get; set; }

        public string Name { get; set; }

        public string Description{ get; set; }

        public ShoppingArrayList(List<ShoppingProduct> products, string name, string description)
        {
            Products = products;
            Name = name;
            Description = description;
        }
    }
}