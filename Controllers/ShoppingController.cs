using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class ShoppingController : Controller
    {

        private DatabaseContext db = new DatabaseContext();
        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddListViewModel model)
        {
            var products = new List<ShoppingProduct>
            {
                new ShoppingProduct("Seks", 3),
                new ShoppingProduct("Piwo", 10)
            };
            if (ModelState.IsValid)
            {
                ShoppingArrayList shoppingArrayList = new ShoppingArrayList();
                shoppingArrayList.Name = model.ListName;
                shoppingArrayList.Description = model.ListDescription;
                shoppingArrayList.Products = products;
                db.ShoppingList.Add(shoppingArrayList);
                db.SaveChanges();
            }

            // Jeśli dotarliśmy tak daleko, oznacza to, że wystąpił błąd. Wyświetl ponownie formularz
            return View(model);
        }

    }
}