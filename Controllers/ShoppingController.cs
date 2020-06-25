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
            AddListViewModel model = new AddListViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddListViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShoppingArrayList shoppingArrayList = new ShoppingArrayList();
                shoppingArrayList.Name = model.ListName;
                shoppingArrayList.Description = model.ListDescription;
                db.ShoppingList.Add(shoppingArrayList);
                db.SaveChanges();
            }
            var shoppingsFromDatabase = db.ShoppingList
    .Include("Products")
    .ToList();

            ViewBag.ShoppingLists = shoppingsFromDatabase;
            return View("~/Views/Home/Index.cshtml");
        }

    }
}