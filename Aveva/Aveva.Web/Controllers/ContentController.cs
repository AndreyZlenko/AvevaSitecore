using Aveva.Models;
using Aveva.Models.Content;
using Aveva.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aveva.Web.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult Header()
        {
            HeaderContentModel model = ViewModelsMapper.MapHeaderContent(Sitecore.Context.Item);
            return View(model);
        }

        public ActionResult LeftNavigationBar()
        {
            List<ItemLinkModel> model = ViewModelsMapper.MapLeftNavigationBar(Sitecore.Context.Item);
            return View(model);
        }

        public ActionResult CentralColumn()
        {
            List<BaseModel> model = ViewModelsMapper.MapContentColumn(Sitecore.Context.Item, ViewModelsMapper.Column.CENTAL);
            return View(model);
        }
    }
}