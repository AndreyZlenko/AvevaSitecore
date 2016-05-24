using Aveva.Models;
using Aveva.Services.TemplatesFields;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aveva.Services
{
    public static class ViewModelsMapper
    {
        #region Site Root

        public static RootSiteModel MapRootSiteItem( Item item )
        {
            RootSiteModel model = new RootSiteModel();

            model.ItemUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            // Header
            ImageField logoImageField = item.Fields[SiteRootItemFields.Logo];
            if(logoImageField != null && logoImageField.MediaItem != null)
            {
                model.LogoImageAlt = logoImageField.Alt;
                model.LogoImageUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(logoImageField.MediaItem));
            }
            // Footer
            model.Date = item[SiteRootItemFields.Date];
            model.Contacts = item[SiteRootItemFields.Contacts];
            model.Information = item[SiteRootItemFields.Information];
            // Content 
            ImageField headImageField = item.Fields[DropdownItemFields.HeadImage];
            if (headImageField != null && headImageField.MediaItem != null)
            {
                model.HeadImageAlt = headImageField.Alt;
                model.HeadImageUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(headImageField.MediaItem));
            }
            model.Article = item[DropdownItemFields.Article];
            // Navigation Items Links
            foreach(Item childItem in item.GetChildren())
            {
                if (childItem.TemplateID == SiteTemplates.NavigationItemTemplaateId)
                {
                    model.NavigationItems.Add(MapNavigationItemLink(childItem));
                }
            }

            return model;
        }

        public static NavigationItemLinkModel MapNavigationItemLink( Item item )
        {
            NavigationItemLinkModel model = new NavigationItemLinkModel();

            model.Name = item[NavigationItemFields.Name];
            model.Url = Sitecore.Links.LinkManager.GetItemUrl(item);
            // Dropdown Items Links
            foreach (Item childItem in item.GetChildren())
            {
                if (childItem.TemplateID == SiteTemplates.DropdownItemTemplaateId)
                {
                    model.DropdownItems.Add(MapDropdownItemLink(childItem));
                }
            }

            return model;
        }

        public static DropdownItemLinkModel MapDropdownItemLink( Item item )
        {
            DropdownItemLinkModel model = new DropdownItemLinkModel();

            model.Name = item[DropdownItemFields.Name];
            model.Url = Sitecore.Links.LinkManager.GetItemUrl(item);

            return model;
        }

        #endregion

        #region Navigation Bar

        public static NavigationItemModel MapNavigationItem(Item item)
        {
            NavigationItemModel model = new NavigationItemModel();
            // Navigation
            model.Name = item[NavigationItemFields.Name];
            model.Url = Sitecore.Links.LinkManager.GetItemUrl(item);
            // Content 
            ImageField headImageField = item.Fields[DropdownItemFields.HeadImage];
            if (headImageField != null && headImageField.MediaItem != null)
            {
                model.HeadImageAlt = headImageField.Alt;
                model.HeadImageUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(headImageField.MediaItem));
            }
            model.Article = item[DropdownItemFields.Article];

            return model;
        }

        #endregion

        #region Dropdown List

        public static DropdownItemModel MapDropdownItem(Item item)
        {
            DropdownItemModel model = new DropdownItemModel();
            ImageField headImageField = item.Fields[DropdownItemFields.HeadImage];
            if (headImageField != null && headImageField.MediaItem != null)
            {
                model.HeadImageAlt = headImageField.Alt;
                model.HeadImageUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(headImageField.MediaItem));
            }
            model.Article = item[DropdownItemFields.Article];

            return model;
        }

        #endregion

    }
}
