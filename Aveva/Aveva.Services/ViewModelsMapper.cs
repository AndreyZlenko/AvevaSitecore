using Aveva.Models;
using Aveva.Models.Content;
using Aveva.Services.TemplatesFields;
using Aveva.Services.TemplatesFields.Content;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System.Collections.Generic;

namespace Aveva.Services
{
    public static class ViewModelsMapper
    {
        #region Header

        public static HeaderModel MapHeader(Item item)
        {
            HeaderModel model = new HeaderModel();

            model.ItemUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            // Header
            ImageField logoImageField = item.Fields[SiteRootItemFields.Logo];
            if (logoImageField != null && logoImageField.MediaItem != null)
            {
                model.LogoImageAlt = logoImageField.Alt;
                model.LogoImageUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(logoImageField.MediaItem));
            }

            // Navigation Items Links
            foreach (Item childItem in item.GetChildren())
            {
                if (childItem.TemplateID == SiteTemplates.NavigationItemTemplaateId)
                {
                    model.Items.Add(MapNavigationItemLink(childItem));
                }
            }

            return model;
        }

        private static ItemLinkModel MapNavigationItemLink(Item item)
        {
            ItemLinkModel model = new ItemLinkModel();

            model.Name = item[NavigationItemFields.Name];
            model.Url = Sitecore.Links.LinkManager.GetItemUrl(item);
            // Dropdown Items Links
            foreach (Item childItem in item.GetChildren())
            {
                if (childItem.TemplateID == SiteTemplates.DropdownItemTemplaateId)
                {
                    model.Items.Add(MapDropdownItemLink(childItem));
                }
            }

            return model;
        }

        private static ItemLinkModel MapDropdownItemLink(Item item)
        {
            ItemLinkModel model = new ItemLinkModel();

            model.Name = item[DropdownItemFields.Name];
            model.Url = Sitecore.Links.LinkManager.GetItemUrl(item);

            return model;
        }

        #endregion

        #region Footer

        public static FooterModel MapFooter(Item item)
        {
            FooterModel model = new FooterModel();
            // Footer
            model.Date = item[SiteRootItemFields.Date];
            model.Contacts = item[SiteRootItemFields.Contacts];
            model.Information = item[SiteRootItemFields.Information];

            return model;
        }

        #endregion

        #region Header of content

        public static HeaderContentModel MapHeaderContent(Item item)
        {
            HeaderContentModel model = new HeaderContentModel();

            ImageField headImageField = item.Fields[DropdownItemFields.HeadImage];
            if (headImageField != null && headImageField.MediaItem != null)
            {
                model.ImageAlt = headImageField.Alt;
                model.ImageUrl = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(headImageField.MediaItem));
            }

            return model;
        }

        #endregion

        #region Content column

        public enum Column { LEFT = 0, CENTAL = 1, RIGHT = 2 }

        public static List<BaseModel> MapContentColumn(Item item, Column column)
        {
            List<BaseModel> model = new List<BaseModel>();

            MultilistField contentItems = null;

            switch (column)
            {
                case Column.LEFT:
                    contentItems = item.Fields[DropdownItemFields.LeftColumn];
                    break;
                case Column.CENTAL:
                    contentItems = item.Fields[DropdownItemFields.CentralColumn];
                    break;
                case Column.RIGHT:
                    contentItems = item.Fields[DropdownItemFields.RightColumn];
                    break;
            }

            if (contentItems != null)
            {
                foreach (Item contentItem in contentItems.GetItems())
                {
                    if (contentItem.TemplateID == SiteTemplates.ContentBoxTemplaateId)
                    {
                        BoxModel boxModel = new BoxModel();
                        boxModel.Type = ContentType.BOX;
                        boxModel.Topic = contentItem[BoxItemFields.Topic];
                        boxModel.Content = contentItem[BoxItemFields.Content];
                        model.Add(boxModel);
                    }
                    else if (contentItem.TemplateID == SiteTemplates.ContentListTemplaateId)
                    {
                        ListModel listModel = new ListModel();
                        listModel.Type = ContentType.LIST;
                        listModel.Topic = contentItem[ListItemFields.Topic];
                        listModel.Content = contentItem[ListItemFields.Content];
                        model.Add(listModel);
                    }
                }
            }

            return model;
        }

        public static List<ItemLinkModel> MapLeftNavigationBar(Item item)
        {
            List<ItemLinkModel> model = new List<ItemLinkModel>();

            if (item.TemplateID == SiteTemplates.DropdownItemTemplaateId)
                item = item.Parent;

            if (item.TemplateID == SiteTemplates.NavigationItemTemplaateId)
            {
                foreach (Item childItem in item.GetChildren())
                {
                    if (childItem.TemplateID == SiteTemplates.DropdownItemTemplaateId)
                    {
                        ItemLinkModel navItem = new ItemLinkModel();
                        navItem.Name = childItem[NavigationItemFields.Name];
                        navItem.Url = Sitecore.Links.LinkManager.GetItemUrl(childItem);
                        model.Add(navItem);
                    }
                }
            }

            return model;
        }

        #endregion
    }
}
