using System;

namespace OURCart.DataModel.DTO
{
    public partial class ItemBarCode
    {
        public decimal ItemBarCodeId { get; set; }
        public decimal FkItemPackageId { get; set; }
        public decimal FkItemId { get; set; }
        public short FkPackageId { get; set; }
        public string BarCode { get; set; }
        public string BarCodeFormat { get; set; }
        public decimal? BarCodePrice { get; set; }
        public string Description { get; set; }
        public string InsUserName { get; set; }
        public DateTime? InsDate { get; set; }
        public string UpdUserName { get; set; }
        public DateTime? UpdDate { get; set; }
        public byte[] RecId { get; set; }

        public virtual Items FkItem { get; set; }
        public virtual Package FkPackage { get; set; }
    }
}
