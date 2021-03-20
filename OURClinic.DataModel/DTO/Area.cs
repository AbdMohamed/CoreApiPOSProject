using System;
using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class Area
    {
        public Area()
        {
            DeliveryClient = new HashSet<DeliveryClient>();
        }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaNameEn { get; set; }
        public int? FkStoreId { get; set; }
        public decimal DeliveryAmount { get; set; }
        public decimal? InsUserId { get; set; }
        public DateTime? InsDate { get; set; }
        public decimal? UpdUserId { get; set; }
        public DateTime? UpdDate { get; set; }
        public byte[] RecId { get; set; }

        public virtual ICollection<DeliveryClient> DeliveryClient { get; set; }
    }
}
