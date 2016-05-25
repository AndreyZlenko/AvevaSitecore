using System.Collections.Generic;

namespace Aveva.Models
{
    public class ItemLinkModel
    {
        public string Name;
        public string Url;

        public List<ItemLinkModel> Items;

        public ItemLinkModel()
        {
            this.Items = new List<ItemLinkModel>();
        }
    }
}
