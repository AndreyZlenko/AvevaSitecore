using System.Collections.Generic;

namespace Aveva.Models
{
    public class HeaderModel
    {
        public string ItemUrl;
        public string LogoImageUrl;
        public string LogoImageAlt;
        // Navigation Items Links
        public List<ItemLinkModel> Items;

        public HeaderModel()
        {
            this.Items = new List<ItemLinkModel>();
        }
    }
}
