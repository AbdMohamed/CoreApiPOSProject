using System;
using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class ItemsPackages
    {
       

        public decimal ItemPackageId { get; set; }
        public decimal FkItemId { get; set; }
        public short FkPackageId { get; set; }
        public int? FkPriceAttributeValA { get; set; }
        public int? FkPriceAttributeValB { get; set; }
        public decimal QtyPerPackage { get; set; }
        public decimal? ItemCost { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? CustomerPrice { get; set; }
        public decimal? WholeSalePrice { get; set; }
        public decimal? HalfWholeSalePrice { get; set; }
        public decimal? WholeSaleProfit { get; set; }
        public decimal? HalfWholeSaleProfit { get; set; }
        public decimal? SaleProfit { get; set; }
        public string InsUserName { get; set; }
        public DateTime InsDate { get; set; }
        public string UpdUserName { get; set; }
        public DateTime? UpdDate { get; set; }
        public byte[] RecId { get; set; }

        public virtual Items FkItem { get; set; }
        public virtual Package FkPackage { get; set; }

    }
}
