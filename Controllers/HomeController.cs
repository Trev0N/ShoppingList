using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
           
            
            var products = new List<ShoppingProduct>
            {
                new ShoppingProduct("Bułka", 3),
                new ShoppingProduct("Piwo", 10)
            };
            db.ShoppingList.Add(new ShoppingArrayList(products, "Zakupy cotygodniowe", "Grube zakupy w galerii auchan bonarka"));
            db.SaveChanges();
            var shoppingsFromDatabase = db.ShoppingList.ToList();
            var shoppingList = new List<ShoppingArrayList>
            {
                new ShoppingArrayList(products, "Zakupy cotygodniowe", "Grube zakupy w galerii auchan bonarka")
            };

            shoppingList.AddRange(shoppingsFromDatabase);

            ViewBag.ShoppingLists = shoppingList;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}