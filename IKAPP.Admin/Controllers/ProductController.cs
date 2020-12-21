using IKAPP.Admin.Attribute;
using IKAPP.Admin.Models;
using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IKAPP.Admin.Controllers
{
    [Auth]
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index()
        {
            return View(service.productService.GetAll());
        }

        public ActionResult Insert()
        {
            return View(service.categoryService.GetAll());
        }

        [HttpPost]
        public ActionResult Insert(ProductVM gelen)
        {
            Product pro = new Product()
            {
                BuyPrice = gelen.BuyPrice,
                CategoryID = gelen.CategoryID,
                Description = gelen.Description,
                ProductName = gelen.ProductName,
                SellPrice = gelen.SellPrice,
                Stock = gelen.Stock,
                Tax = gelen.Tax,
                Barcode = gelen.Barcode,
                CriticalStock = gelen.CriticalStock,
                IsActive = gelen.IsActive,
            };
            if (pro.Stock <= pro.CriticalStock)
            {
                pro.CriticalStatus = true;
            }
            else
            {
                pro.CriticalStatus = false;
            }
            service.productService.Insert(pro);
            return Redirect("/Product/Index");
        }

       
        public ActionResult BarcodeSearch(string Barcode)
        {
            var result = service.productService.BarSearch(Barcode);
            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


    }
}