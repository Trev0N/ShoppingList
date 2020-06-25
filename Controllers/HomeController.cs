using ShoppingList.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var shoppingsFromDatabase = db.ShoppingList
                .Include("Products")
                .ToList();

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
        public ActionResult Edit(AddListViewModel model)
        {
            if (ModelState.IsValid)
            {
                shoppings = db.ShoppingList.Find(model.Id);
                shoppings.Name = model.ListName;
                shoppings.Description = model.ListDescription;
                db.SaveChanges();
            }
            var shoppingsFromDatabase = db.ShoppingList
    .Include("Products")
    .ToList();

            ViewBag.ShoppingLists = shoppingsFromDatabase;
            // Jeśli dotarliśmy tak daleko, oznacza to, że wystąpił błąd. Wyświetl ponownie formularz
            return View("index");
        }

        public ActionResult EditProduct(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductModel model, int id)
        {
            if (ModelState.IsValid)
            {
                shoppings = db.ShoppingList.Find(id);
                if(shoppings.Products == null) {
                    shoppings.Products = new Collection<ShoppingProduct> { };
                }
                shoppings.Products.Add(new ShoppingProduct(model.ProductName, model.ProductQuantity));
                db.SaveChanges();
            }

            // Jeśli dotarliśmy tak daleko, oznacza to, że wystąpił błąd. Wyświetl ponownie formularz
            return View(model);
        }


        public ActionResult DeleteList(int id)
        {
            db.ShoppingList.Remove(
            db.ShoppingList.Include("Products")
                .SingleOrDefault(x => x.Id == id));
            db.SaveChanges();
            var shoppingsFromDatabase = db.ShoppingList
    .Include("Products")
    .ToList();

            ViewBag.ShoppingLists = shoppingsFromDatabase;
            return View("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            db.ShoppingProduct.Remove(db.ShoppingProduct.Find(id));
            db.SaveChanges();
            var shoppingsFromDatabase = db.ShoppingList
                .Include("Products")
                .ToList();
            
            ViewBag.ShoppingLists = shoppingsFromDatabase;
            return View("Index");
        }
    }
}