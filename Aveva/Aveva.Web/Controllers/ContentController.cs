using Aveva.Models;
using Aveva.Services;
using System.Web.Mvc;

namespace Aveva.Web.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult GetHeader()
        {
            HeaderContentModel model = ViewModelsMapper.MapHeaderContent(Sitecore.Context.Item);
            return View(model);
        }

        public ActionResult GetLeftColumn()
        {
            ContentColumnLeftModel model = ViewModelsMapper.MapContentColumnLeft(Sitecore.Context.Item);
            return View(model);
        }

        public ActionResult GetCentralColumn()
        {
            ContentColumnCentralModel model = ViewModelsMapper.MapContentColumnCentral(Sitecore.Context.Item);
            return View(model);
        }

        public ActionResult GetRightColumn()
        {
            ContentColumnRightModel model = ViewModelsMapper.MapContentColumnRight(Sitecore.Context.Item);
            return View(model);
        }
    }
}