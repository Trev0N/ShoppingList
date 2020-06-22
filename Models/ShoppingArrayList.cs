using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingList.Models
{
    public class ShoppingArrayList
    {

        [Key]
        public int Id { get; set; }
        public ICollection<ShoppingProduct> Products { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ShoppingArrayList(List<ShoppingProduct> products, string name, string description)
        {
            Products = products;
            Name = name;
            Description = description;
        }

        public ShoppingArrayList()
        {
        }

    }
    public class AddListViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwa listy")]
        public string ListName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Opis listy")]
        public string ListDescription { get; set; }
    }
}