using Aveva.Models;
using Aveva.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aveva.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            RootSiteModel model = ViewModelsMapper.MapRootSiteItem(Sitecore.Context.Item);
            return View(model);
        }
    }
}