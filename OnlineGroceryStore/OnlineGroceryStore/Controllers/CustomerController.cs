using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.CategoryProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            OnlineGroceryStoreDBContext ogsd = new OnlineGroceryStoreDBContext();

            return View(ogsd.Products.ToList());
            
        }
    }
}
