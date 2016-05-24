using System.Collections.Generic;

namespace Aveva.Models
{
    public class NavigationItemLinkModel
    {
        public string Name;
        public string Url;
        // Dropdown Items Links
        public List<DropdownItemLinkModel> DropdownItems;

        public NavigationItemLinkModel()
        {
            this.DropdownItems = new List<DropdownItemLinkModel>();
        }
    }
}
