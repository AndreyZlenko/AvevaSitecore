using Aveva.Models;
using Aveva.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aveva.Web.Controllers
{
    public class NavigationBarController : Controller
    {
        public ActionResult GetContent()
        {
            NavigationItemModel model = ViewModelsMapper.MapNavigationItem(Sitecore.Context.Item);
            return View(model);
        }
    }
}