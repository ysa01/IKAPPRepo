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
    public class SetupController : BaseController
    {
        #region CategoryJobs
        
        public ActionResult CategoryIndex()
        {
            return View(service.categoryService.GetAll());
        }

        public ActionResult CategoryInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryInsert(CategoryVM gelen)
        {
            Category cat = new Category()
            {
                CategoryName = gelen.CategoryName,
            };
            service.categoryService.Insert(cat);
            return Redirect("/Setup/CategoryIndex");
        }

        public ActionResult CategoryUpdate(int? ID)
        {
            if (ID != null)
            {
                var bul = service.categoryService.Find((int)ID);
                return View(bul);
            }
            else return Redirect("/Setup/CategoryIndex");
        }

        [HttpPost]
        public ActionResult CategoryUpdate(CategoryVM gelen)
        {
            Category cat = new Category();
            cat.ID = gelen.ID;
            cat.CategoryName = gelen.CategoryName;
            service.categoryService.Update(cat);
            return Redirect("/Setup/CategoryIndex");
        }

        #endregion


    }
}