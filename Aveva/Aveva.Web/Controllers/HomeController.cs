using Aveva.Models;
using Aveva.Services;
using System.Web.Mvc;

namespace Aveva.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GetHeader()
        {
            HeaderModel model = ViewModelsMapper.MapHeader(Sitecore.Context.Item);
            return View(model);
        }

        public ActionResult GetFooter()
        {
            FooterModel model = ViewModelsMapper.MapFooter(Sitecore.Context.Item);
            return View(model);
        }
    }
}