using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.CategoryProduct;

using System.IO;
using System.Linq;

namespace OnlineGroceryStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        public ActionResult Index()
        {
            OnlineGroceryStoreDBContext ogsd =new OnlineGroceryStoreDBContext();

            return View(ogsd.Products.ToList());
        }

        //GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

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
                using (MemoryStream ms = new MemoryStream())
                {
                    imgFiles.CopyTo(ms);
                    byte[] bt = ms.ToArray();
                    obj.ProductImage= bt;
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
            Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == id);
                return View(prod);
            
            
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product obj, IFormFile imgFiles)
        {
            try
            {

                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == obj.Productid);
                using (MemoryStream ms = new MemoryStream())
                {
                    imgFiles.CopyTo(ms);
                    byte[] bt = ms.ToArray();
                    obj.ProductImage = bt;
                    prod.ProductName = obj.ProductName;
                    prod.BrandName = obj.BrandName;
                    prod.ProductPrice = obj.ProductPrice;
                    prod.NoOfItemsInStock = obj.NoOfItemsInStock;
                    prod.ProductImage = obj.ProductImage;
                    prod.ProductDiscription = obj.ProductDiscription;
                    prod.Discount = obj.Discount;
                    prod.CategoryId = obj.CategoryId;
                    ogsd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {

            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == id);
            return View(prod);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product obj)
        {
            try
            {


                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                string playername = Request.Form["ProductImage"].ToString();
                Product prod = ogsd.Products.FirstOrDefault(i => i.Productid == obj.Productid);
                ogsd.Products.Remove(prod);
                ogsd.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
