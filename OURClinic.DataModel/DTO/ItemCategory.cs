using System;
using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Items = new HashSet<Items>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameEng { get; set; }
        public int? ParentId { get; set; }
        public int? FkShopId { get; set; }
        public string InsUserId { get; set; }
        public string InsDate { get; set; }
        public string UpdUserId { get; set; }
        public string UpdDate { get; set; }
        public string CategoryImage { get; set; }

        public byte[] RecId { get; set; }

        public virtual ICollection<Items> Items { get; set; }

        
    }
}
