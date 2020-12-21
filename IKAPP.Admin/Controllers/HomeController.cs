using IKAPP.Admin.Attribute;
using IKAPP.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IKAPP.Admin.Controllers
{
    [Auth]
    public class HomeController : BaseController
    {
      
        public ActionResult Index()
        {
            HomeVM vm = new HomeVM();

            var urun = service.productService.GetAll().Where(x => x.CriticalStatus == true).ToList();
            var musteri = service.customerService.GetAll().Take(10).ToList();
            var siparis = service.orderService.GetAll().Where(x => x.OrderDate >= DateTime.Now.Date.AddDays(-10)).Take(10).ToList();

            vm.musteriler = musteri;
            vm.siparisler = siparis;
            vm.urunler = urun;
            return View(vm);
        }
    }
}