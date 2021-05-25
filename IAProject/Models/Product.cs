using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAProject.Models
{
    public class Product
    {
        public String Name { get; set; }
        public int Price { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public int Id { get; set; }

        public Category Category { get; set; }
        public int? CategoryID { get; set; }

        public static implicit operator List<object>(Product v)
        {
            throw new NotImplementedException();
        }
    }
}