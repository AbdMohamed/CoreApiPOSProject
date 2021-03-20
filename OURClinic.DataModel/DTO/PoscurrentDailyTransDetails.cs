using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OURCart.DataModel.DTO
{
    public partial class PoscurrentDailyTransDetails
    {
        public decimal DetailId { get; set; }
        public int FkBrId { get; set; }
        public decimal HeaderId { get; set; }
        public byte FktransTypeId { get; set; }
        public string BarcodeDescription { get; set; }
        public string Barcode { get; set; }
        public decimal FkItemBarcodeId { get; set; }
        public decimal ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal PackageId { get; set; }
        public string PackageName { get; set; }
        public int QtyPerPackage { get; set; }
        public decimal Qty { get; set; }
        public decimal? ReturnedQty { get; set; }
        public decimal? VendDiscount { get; set; }
        public decimal? VendDiscountRate { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal Total { get; set; }
        public string Notes { get; set; }
        public decimal AffectedPieces { get; set; }
        public decimal CustPrice { get; set; }
        public int InsUserId { get; set; }
        public DateTime InsDate { get; set; }
        public string TransDate { get; set; }
        public decimal? DiscPromo { get; set; }
        public decimal? DiscSeason { get; set; }
        public decimal? DiscMember { get; set; }
        public decimal? DiscHeader { get; set; }
        public decimal ItemCost { get; set; }
        public int FkStoreId { get; set; }
        public int? FkParentItemId { get; set; }
        public decimal? WholeSalePrice { get; set; }
        public decimal? HalfWholeSalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }

        public virtual PoscurrentDailyTransHeader PoscurrentDailyTransHeader { get; set; }
    }
}
