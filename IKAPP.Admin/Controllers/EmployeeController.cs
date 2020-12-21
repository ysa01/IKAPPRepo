
using IKAPP.Admin.Attribute;
using IKAPP.Admin.Models;
using IKAPP.DAL.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IKAPP.Admin.Controllers
{
    [Auth]
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {
            var li = service.employeeService.GetAll();
            return View(li);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeeVM gelen, HttpPostedFileBase resim)
        {
            if (resim == null)
            {
                Employee emp = new Employee()
                {
                    Adress = gelen.Adress,
                    Email = gelen.Email,
                    FirstName = gelen.FirstName,
                    LastName = gelen.LastName,
                    Phone = gelen.Phone,
                    ImageURL = "/Assets/Img/empty.jpg"
                };
                service.employeeService.Insert(emp);
                TempData["mesaj"] = "İşlem Başarılı";
                return Redirect("/Employee/Index");
            }
            else
            {
                string uzanti = Path.GetExtension(resim.FileName);
                string resimadi = gelen.Phone + uzanti;
                resim.SaveAs(Server.MapPath("/Assets/Img/" + resimadi));
                Employee emp = new Employee()
                {
                    Adress = gelen.Adress,
                    Email = gelen.Email,
                    FirstName = gelen.FirstName,
                    LastName = gelen.LastName,
                    Phone = gelen.Phone,
                    ImageURL = "/Assets/Img/" + resimadi,
                };
                service.employeeService.Insert(emp);
                TempData["mesaj"] = "İşlem Başarılı";
                return Redirect("/Employee/Index");
            }
        }

        public ActionResult Update(int? ID)
        {
            if (ID != null)
            {
                var bul = service.employeeService.Find((int)ID);
                if (bul != null)
                {
                    return View(bul);
                }
                else
                {
                    return Redirect("/Employee/Index");
                }

            }
            else
            {
                return Redirect("/Employee/Index");
            }

        }

        [HttpPost]
        public ActionResult Update(EmployeeVM gelen, HttpPostedFileBase resim)
        {
            if (resim != null)
            {
                var use = service.employeeService.Find(gelen.ID);
                if (System.IO.File.Exists(use.ImageURL))
                {
                    System.IO.File.Delete(use.ImageURL);
                }
                string uzanti = Path.GetExtension(resim.FileName);
                string resimadi = gelen.Phone + uzanti;
                resim.SaveAs(Server.MapPath("/Assets/Img/" + resimadi));
                Employee emp = new Employee()
                {
                    ID = gelen.ID,
                    Adress = gelen.Adress,
                    Email = gelen.Email,
                    FirstName = gelen.FirstName,
                    LastName = gelen.LastName,
                    Phone = gelen.Phone,
                    ImageURL = "/Assets/Img/" + resimadi
                };
                service.employeeService.Update(emp);
                TempData["mesaj"] = "İşlem Başarılı";
                return Redirect("/Employee/Index");
            }
            else
            {
                var use = service.employeeService.Find(gelen.ID);
                Employee emp = new Employee()
                {
                    ID = gelen.ID,
                    Adress = gelen.Adress,
                    Email = gelen.Email,
                    FirstName = gelen.FirstName,
                    LastName = gelen.LastName,
                    Phone = gelen.Phone,
                    ImageURL = use.ImageURL
                };
                service.employeeService.Update(emp);
                TempData["mesaj"] = "İşlem Başarılı";
                return Redirect("/Employee/Index");
            }


        }

        public ActionResult UpdateJS(int? id)
        {
            if (id != null)
            {
                var result = service.employeeService.empFind((int)id);

                if (result != null)
                {
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
            else
            {
                return Json(new
                {
                    Status = false,
                    Data = ""
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult TempImage(HttpPostedFileBase tempres)
        {
            using (BinaryReader reader = new BinaryReader(tempres.InputStream))
            {
                Session["TempImage"] = reader.ReadBytes((Int32)tempres.ContentLength);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult TempImageShow(HttpPostedFileBase tempres)
        {
            return new FileContentResult((byte[])Session["TempImage"], "image/png");
        }


        public ActionResult SignUpMail(int? ID)
        {
            if (ID != null)
            {
                var emp = service.employeeService.Find((int)ID);
                var body = "Merhaba sistemimize aşağıdaki bilgiler ile giriş sağlayabilirsiniz <br/>" + "Kullanıcı Adı: " + emp.Email + "<br/>" + "Şifre: " + emp.Password + "<br/>" + "İyi çalışmalar dileriz.";
                var sub = "Firma Yeni Kullanıcı Bilgisi";
                EmployeeMailVM vm = new EmployeeMailVM(emp.Email, sub, body);
                vm.SendMail();
                service.employeeService.MailUp((int)ID);
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
    }

}