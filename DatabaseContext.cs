using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingList
{
    [DbConfigurationType(typeof(CodeConfig))]
    public class DatabaseContext : DbContext
    {
        public DbSet<ShoppingArrayList> ShoppingList { get; set; }
        public DbSet<ShoppingProduct> ShoppingProduct { get; set; }

        public DatabaseContext()
    : base("name=databaseConnection")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Configurations.Add(new ShoppingConfiguration());
        //}
    }

    public class CodeConfig : DbConfiguration
    {
        public CodeConfig()
        {
            SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}