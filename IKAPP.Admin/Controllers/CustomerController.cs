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
    public class CustomerController : BaseController
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(service.customerService.GetAll());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CustomerVM gelen)
        {
            Customer cust = new Customer()
            {
                Adress = gelen.Adress,
                Email = gelen.Email,
                FirstName = gelen.FirstName,
                LastName = gelen.LastName,
                Phone = gelen.Phone,
            };
            service.customerService.Insert(cust);
            TempData["mesaj"] = "İşlem Başarılı";
            return Redirect("/Customer/Index");
        }
        public ActionResult Update(int? ID)
        {
            if (ID != null)
            {
                var bul = service.customerService.Find((int)ID);
                return View(bul);
            }
            else
            {
                return Redirect("/Customer/Index");
            }
        }

        [HttpPost]
        public ActionResult Update(CustomerVM gelen)
        {
            Customer cust = new Customer()
            {
                ID = gelen.ID,
                Adress = gelen.Adress,
                Email = gelen.Email,
                FirstName = gelen.FirstName,
                LastName = gelen.LastName,
                Phone = gelen.Phone,
            };
            service.customerService.Update(cust);
            TempData["mesaj"] = "İşlem Başarılı";
            return Redirect("/Customer/Index");
        }

        public ActionResult Search(string Phone)
        {
            var result = service.customerService.PhoneSearch(Phone);
            if (result != null)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateJS(int? ID)
        {
            if (ID != null)
            {
                var result = service.customerService.Find((int)ID);
                return Json(new
                {
                    Status = true,
                    Data = result
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    Status = false,
                    Data = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}