using System;
using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class ItemsVendors
    {
        public int ItemVendorId { get; set; }
        public int FkItemId { get; set; }
        public int FkVendorId { get; set; }
    }
}
