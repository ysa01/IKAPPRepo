using IKAPP.BLL.Repository.Service;
using System.Web.Mvc;

namespace IKAPP.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected EntityService service = new EntityService();
    }
}