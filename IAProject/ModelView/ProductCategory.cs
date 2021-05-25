using IAProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAProject.ModelView
{
    public class ProductCategory
    {
        public List<Product> Product { get; set; }
        public List<Category> Category { get; set; }
        public Product MyProduct { get; set; }
        public  Category MyCategory { get; set; }

    }
}