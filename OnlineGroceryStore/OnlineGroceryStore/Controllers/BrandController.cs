using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.AdminDetailsModel;
using OnlineGroceryStore.CategoryProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;




namespace OnlineGroceryStore.Models
{
    public class BrandController : Controller
    {

        public ActionResult Index()
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();




            return View(ogsd.Branddetails.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branddetail obj, IFormFile imgFiles)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                    imgFiles.CopyTo(ms);
                    byte[] bt = ms.ToArray();
                    obj.Brandlogo = bt;
                    ogsd.Branddetails.Add(obj);
                    ogsd.SaveChanges();
                }
                return RedirectToAction("Index");
            }


            catch
            {
                return View();
            }
        }





        public ActionResult Edit(string id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Branddetail Brd = ogsd.Branddetails.FirstOrDefault(i => i.Brandname == id);
            return View(Brd);
        }

        [HttpPost]

        public ActionResult Edit(Branddetail obj, IFormFile imgFiles)
        {

            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Branddetail Brd = ogsd.Branddetails.FirstOrDefault(i => i.Brandname == obj.Brandname);

            if (imgFiles != null)
            {


                using (MemoryStream ms = new MemoryStream())
                {
                    imgFiles.CopyTo(ms);
                    byte[] bt = ms.ToArray();
                    obj.Brandlogo = bt;
                    Brd.Contractstartdate = obj.Contractstartdate;
                    Brd.Totalnoofyearcontract = obj.Totalnoofyearcontract;
                    Brd.Brandlogo = obj.Brandlogo;
                    ogsd.SaveChanges();
                }

            }
            else
            {
                Brd.Contractstartdate = obj.Contractstartdate;
                Brd.Totalnoofyearcontract = obj.Totalnoofyearcontract;
                ogsd.SaveChanges();
            }

            return RedirectToAction("Index");


        }
        public ActionResult Delete(string id)
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
            Branddetail Brd = ogsd.Branddetails.FirstOrDefault(i => i.Brandname == id);
            return View(Brd);
        }

        [HttpPost]

        public ActionResult Delete(Branddetail obj)
        {
            try
            {
                OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();
                string Brandname = Request.Form["Brandlogo"].ToString();
                Branddetail Brd = ogsd.Branddetails.FirstOrDefault(i => i.Brandname == obj.Brandname);
                ogsd.Branddetails.Remove(Brd);
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





