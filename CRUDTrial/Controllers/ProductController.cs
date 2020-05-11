using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDTrial.Models;

namespace CRUDTrial.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using (DBModel dbmodel = new DBModel())
                return View(dbmodel.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbModel = new DBModel())
            {
                return View(dbModel.Products.Where(x=>x.ID==id).FirstOrDefault());
            }
            
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product products)
        {
            try
            {
                using (DBModel dbModel = new DBModel()) {
                    dbModel.Products.Add(products);
                    dbModel.SaveChanges();
                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbModel = new DBModel())
            {
                return View(dbModel.Products.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                using (DBModel dbModel = new DBModel())
                {
                    dbModel.Entry(product).State = EntityState.Modified;
                    dbModel.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbModel = new DBModel())
            {
                return View(dbModel.Products.Where(x => x.ID == id).FirstOrDefault());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBModel dbModel = new DBModel())
                {
                    Product product = dbModel.Products.Where(x => x.ID == id).FirstOrDefault();
                    dbModel.Products.Remove(product);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
