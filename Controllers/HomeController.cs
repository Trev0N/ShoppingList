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
    public class HomeController : Controller
    {
        private ShoppingArrayList shoppings;
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
           
            //var products = new List<ShoppingProduct>
            //{
            //    new ShoppingProduct("Bułka", 3),
            //    new ShoppingProduct("Piwo", 10)
            //};
            //db.ShoppingList.Add(new ShoppingArrayList(products, "Zakupy cotygodniowe", "Grube zakupy w galerii auchan bonarka"));
            //db.SaveChanges();
            var shoppingsFromDatabase = db.ShoppingList
                .Include("Products")
                .ToList();
            //var shoppingList = new List<ShoppingArrayList>
            //{
            //    new ShoppingArrayList(products, "Zakupy cotygodniowe", "Grube zakupy w galerii auchan bonarka")
            //};

            var shoppingList = shoppingsFromDatabase;

            ViewBag.ShoppingLists = shoppingList;

            return View();
        }

        public ActionResult Edit(int id)
        {
            shoppings = db.ShoppingList.Find(id);

            AddListViewModel addListViewModel = new AddListViewModel();
            addListViewModel.Id = id;
            addListViewModel.ListDescription = shoppings.Description;
            addListViewModel.ListName = shoppings.Name;

            return View(addListViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AddListViewModel model)
        {
            if (ModelState.IsValid)
            {
                shoppings = db.ShoppingList.Find(model.Id);
                shoppings.Name = model.ListName;
                shoppings.Description = model.ListDescription;
                db.SaveChanges();
            }

            // Jeśli dotarliśmy tak daleko, oznacza to, że wystąpił błąd. Wyświetl ponownie formularz
            return View(model);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}