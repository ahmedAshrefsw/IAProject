using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IAProject.Models
{
    public class DataB : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet <Category> Category { get; set; }
    }
}