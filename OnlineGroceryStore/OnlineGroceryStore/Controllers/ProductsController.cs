using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.CategoryProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public ActionResult Index()
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            return View(ogsd.Products.ToList());
        }

        // GET: ProductsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product obj, IFormFile imgFiles)
        {
            try
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                Product Prod = ogsd.Products.FirstOrDefault(i => i.Productid==obj.Productid);
                using (MemoryStream ms = new MemoryStream())
                {
                    imgFiles.CopyTo(ms);
                    byte[] bt = ms.ToArray();
                    obj.ProductImage = bt;
                    //Prod.ProductName = obj.ProductName;
                    //Prod.BrandName = obj.BrandName;
                    //Prod.ProductPrice = obj.ProductPrice;
                    //Prod.NoOfItemsInStock = obj.NoOfItemsInStock;
                    //Prod.CategoryId = obj.CategoryId;
                    //Prod.ProductImage = obj.ProductImage;
                    //Prod.ProductDiscription = obj.ProductDiscription;
                    //Prod.Discount = obj.Discount;
                    ogsd.Products.Add(obj);
                    ogsd.SaveChanges();
                }
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Product Proc = ogsd.Products.FirstOrDefault(i => i.Productid == id);
            return View(Proc);

            
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product obj, IFormFile imgFiles)
        {
            try
            {

                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                Product Proc = ogsd.Products.FirstOrDefault(i => i.Productid == obj.Productid);
                using (MemoryStream ms = new MemoryStream())
                {
                    imgFiles.CopyTo(ms);
                    byte[] bt = ms.ToArray();
                    obj.ProductImage = bt;
                    Proc.ProductName = obj.ProductName;
                    Proc.BrandName = obj.BrandName;
                    Proc.ProductPrice = obj.ProductPrice;
                    Proc.NoOfItemsInStock = obj.NoOfItemsInStock;
                    Proc.ProductImage = obj.ProductImage;
                    Proc.ProductDiscription = obj.ProductDiscription;
                    Proc.Discount = obj.Discount;
                    Proc.CategoryId = obj.CategoryId;
                    ogsd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
