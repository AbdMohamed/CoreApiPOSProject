using System;
using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class Package
    {
        public Package()
        {
            ItemBarCode = new HashSet<ItemBarCode>();
            ItemsPackages = new HashSet<ItemsPackages>();
        }

        public short PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageNameEn { get; set; }
        public byte? PackageSize { get; set; }
        public string InsUser { get; set; }
        public DateTime? InsDate { get; set; }
        public string UpdUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public byte[] RecId { get; set; }

        public virtual ICollection<ItemBarCode> ItemBarCode { get; set; }
        public virtual ICollection<ItemsPackages> ItemsPackages { get; set; }
    }
}
