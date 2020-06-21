using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class Shopping
    {
        public List<ShoppingArrayList> ShoppingLists { get; set; }

        public Shopping(List<ShoppingArrayList> shoppingLists)
        {
            ShoppingLists = shoppingLists;
        }
    }
}