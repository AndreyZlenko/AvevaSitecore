using Aveva.Models;
using Aveva.Services.TemplatesFields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

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

        #region Content column left

        public static ContentColumnLeftModel MapContentColumnLeft(Item item)
        {
            ContentColumnLeftModel model = new ContentColumnLeftModel();

            model.Content = item[DropdownItemFields.LeftColumn];

            return model;
        }

        #endregion

        #region Content column central

        public static ContentColumnCentralModel MapContentColumnCentral(Item item)
        {
            ContentColumnCentralModel model = new ContentColumnCentralModel();

            model.Content = item[DropdownItemFields.CentralColumn];

            return model;
        }

        #endregion

        #region Content column right

        public static ContentColumnRightModel MapContentColumnRight(Item item)
        {
            ContentColumnRightModel model = new ContentColumnRightModel();

            model.Content = item[DropdownItemFields.RightColumn];

            return model;
        }

        #endregion
    }
}
