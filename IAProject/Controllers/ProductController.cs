using IAProject.Models;
using IAProject.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IAProject.Controllers
{

    public class ProductController : Controller
    {
        DataB db = new DataB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProduct()
        {
           
            ProductCategory prca = new ProductCategory
            {
                Product = db.Product.ToList(),
                Category = db.Category.ToList()
            };
            return View(prca);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {

            ProductCategory prca = new ProductCategory
            {
                Category = db.Category.ToList()
            };

            return View(prca);
        }
        [HttpPost]
        public ActionResult AddProduct(ProductCategory prca)
        {
            db.Product.Add(prca.MyProduct);

            db.SaveChanges();
            return RedirectToAction("ViewProduct");
        }



        [HttpGet]
        public ActionResult Details(int ID)
        {
            var product = db.Product.ToList().Single(c => c.Id == ID);

            ProductCategory prca = new ProductCategory
            {
                MyProduct = product,
                MyCategory = db.Category.ToList().Single(c => c.Id == product.CategoryID),
            };


            return View(prca);
        }



        [HttpGet]
        public ActionResult Update(int ID)
        {

            var product = db.Product.ToList().Single(c => c.Id == ID);

            ProductCategory prca = new ProductCategory
            {
                MyProduct = product,
                MyCategory = db.Category.ToList().Single(c => c.Id == product.CategoryID),
                Category = db.Category.ToList()
            };


            return View(prca);
        }
        [HttpPost]
        public ActionResult Update(ProductCategory prca)
        {
            if (!ModelState.IsValid) {
                var mcat = db.Category.ToList();
                prca.Category = mcat;
                return View("Update", prca);
            }

            var productDb = db.Product.ToList().Single(c => c.Id == prca.MyProduct.Id);
            productDb.Name = prca.MyProduct.Name;
            productDb.Price = prca.MyProduct.Price;
            productDb.CategoryID = prca.MyProduct.CategoryID;
            productDb.Description = prca.MyProduct.Description;
            productDb.Image = prca.MyProduct.Image;
            db.SaveChanges();



            return RedirectToAction("ViewProduct");


        }
        [HttpGet]
        public ActionResult Delete(int ID){

            var product = db.Product.Single(c => c.Id == ID);
            db.Product.Remove(product);
            db.SaveChanges();                              

         return RedirectToAction("ViewProduct");

        }



    }
}