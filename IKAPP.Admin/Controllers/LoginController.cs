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
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginControl(LoginVM cre)
        {
            if (ModelState.IsValid)
            {
                if (service.userService.login(cre.UserName, cre.Password))
                {
                    User use = service.userService.FindUserName(cre.UserName);
                    AdminSessionContext _adminSessionContext = new AdminSessionContext()
                    {
                        ID = use.ID,
                        UserName = use.UserName,
                    };
                    Session["AdminSessionContext"] = _adminSessionContext;
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Redirect("/Login/Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/Login");
        }
    }
}