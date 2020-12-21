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
    public class OrderController : BaseController
    {
        // GET: Order
        public ActionResult Index()
        {
            var li = service.orderService.GetAll();
            return View(li);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(OrderVM gelen)
        {
            if (ModelState.IsValid)
            {
                Order ord = new Order()
                {
                    CustomerID = gelen.CustomerID,
                    OrderDate = DateTime.Now,
                    Piece = gelen.Piece,
                    Price = gelen.Price,
                    ProductID = gelen.ProductID,
                    EmployeeID = ((AdminSessionContext)Session["AdminSessionContext"]).ID,

                };
                service.orderService.Insert(ord);
                service.productService.StockStatus((int)ord.Piece, (int)ord.ProductID);
                TempData["mesaj"] = "İşlem Başarılı";
                return Redirect("/Order/Index");
            }
            else
            {
                TempData["mesaj"] = "İşlem Başarısız";
                return Redirect("/Order/Index");
            }
        }


        public ActionResult Update(int? ID)
        {
            if (ID != null)
            {
                var bul = service.orderService.Find((int)ID);
                return View(bul);
            }
            else
            {
                return Redirect("/Order/Index");
            }
        }
        [HttpPost]
        public ActionResult Update(OrderVM ord, CustomerVM custo)
        {
            if (ord.CustomerID == 0)
            {
                Customer cust = new Customer()
                {
                    Adress = custo.Adress,
                    Email = custo.Email,
                    FirstName = custo.FirstName,
                    LastName = custo.LastName,
                    Phone = custo.Phone
                };
                service.customerService.Insert(cust);
                Order order = new Order()
                {
                    CustomerID = cust.ID,
                    OrderDate = DateTime.Now,
                    EmployeeID = ((AdminSessionContext)Session["AdminSessionContext"]).ID,
                    Piece = ord.Piece,
                    Price = ord.Price,
                    ProductID = ord.ProductID,
                    ID = ord.ID,
                };
                service.orderService.Update(order);
                service.productService.StockStatus(ord.Piece, ord.ProductID);
                return Redirect("/Order/Index");
            }
            else
            {
                Order order = new Order()
                {
                    CustomerID = ord.CustomerID,
                    OrderDate = DateTime.Now,
                    EmployeeID = ((AdminSessionContext)Session["AdminSessionContext"]).ID,
                    Piece = ord.Piece,
                    Price = ord.Price,
                    ProductID = ord.ProductID,
                    ID = ord.ID,
                };
                service.orderService.Update(order);
                service.productService.StockStatus(ord.Piece, ord.ProductID);
                return Redirect("/Order/Index");
            }
        }
    }
}