using System.Collections.Generic;

namespace Aveva.Models
{
    public class RootSiteModel
    {
        public string ItemUrl;
        // Header
        public string LogoImageUrl;
        public string LogoImageAlt;
        // Footer
        public string Date;
        public string Contacts;
        public string Information;
        // Navigation Items Links
        public List<NavigationItemLinkModel> NavigationItems;
        // Content 
        public string HeadImageUrl;
        public string HeadImageAlt;
        public string Article;

        public RootSiteModel()
        {
            this.NavigationItems = new List<NavigationItemLinkModel>();
        }
    }
}
