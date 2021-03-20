using System;
using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Items>();
        }

        public byte ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeNameEng { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
