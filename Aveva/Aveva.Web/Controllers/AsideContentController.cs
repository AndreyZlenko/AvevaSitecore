using Aveva.Models.Content;
using Aveva.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Aveva.Web.Controllers
{
    public class AsideContentController : Controller
    {
        public ActionResult LeftColumn()
        {
            List<BaseModel> model = ViewModelsMapper.MapContentColumn(Sitecore.Context.Item, ViewModelsMapper.Column.LEFT);
            return View("AsideColumn", model);
        }

        public ActionResult RightColumn()
        {
            List<BaseModel> model = ViewModelsMapper.MapContentColumn(Sitecore.Context.Item, ViewModelsMapper.Column.RIGHT);
            return View("AsideColumn", model);
        }
    }
}