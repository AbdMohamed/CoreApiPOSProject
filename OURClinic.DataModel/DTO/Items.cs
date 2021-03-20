using System;
using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class Items
    {
        public Items()
        {
            ItemBarCode = new HashSet<ItemBarCode>();
            ItemsPackages = new HashSet<ItemsPackages>();

        }

        public decimal ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameEn { get; set; }
        public string SearchItemName { get; set; }
        public int? FkVariantAid { get; set; }
        public int? FkVariantBid { get; set; }
        public int FkCategoryId { get; set; }
        public decimal? FkVendorId { get; set; }
        public byte FkItemTypeId { get; set; }
        public string FkFixedAssetId { get; set; }
        public decimal? ReorderQuantity { get; set; }
        public decimal? MaxOrderQuantity { get; set; }
        public decimal? MaxStockQuantity { get; set; }
        public decimal? AllowedExcessRate { get; set; }
        public int? ExpiryDays { get; set; }
        public decimal? PurchaseDiscount { get; set; }
        public decimal? PurchaseDiscountRate { get; set; }
        public decimal? VendorDiscount { get; set; }
        public decimal? VendorDiscountRate { get; set; }
        public decimal? CashDiscount { get; set; }
        public decimal? CashDiscountRate { get; set; }
        public decimal? DeferralDiscount { get; set; }
        public decimal? DeferralDiscountRate { get; set; }
        public decimal? ReturnDiscount { get; set; }
        public decimal? ReturnDiscountRate { get; set; }
        public decimal? MonthlyDiscount { get; set; }
        public decimal? MonthlyDiscountRate { get; set; }
        public decimal? QuarterAnnualDiscount { get; set; }
        public decimal? QuarterAnnualDiscountRate { get; set; }
        public decimal? AnnualDiscount { get; set; }
        public decimal? AnnualDiscountRate { get; set; }
        public decimal? ExtraDiscount { get; set; }
        public decimal? ExtraDiscountRate { get; set; }
        public decimal? Additions { get; set; }
        public decimal? AdditionsRate { get; set; }
        public decimal? ItemTax { get; set; }
        public decimal? ItemTaxRate { get; set; }
        public bool? StopSale { get; set; }
        public bool? StopPurchase { get; set; }
        public bool? StopTransfer { get; set; }
        public bool? StopInventory { get; set; }
        public bool? IsForResale { get; set; }
        public bool? IsOpenSale { get; set; }
        public bool? IsRecipe { get; set; }
        public bool? IsActive { get; set; }
        public bool? ShowStockInClosure { get; set; }
        public bool? ShowSalesInClosure { get; set; }
        public bool? HasSerial { get; set; }
        public string Notes { get; set; }
        public string PurchaseNotes { get; set; }
        public string SalesNotes { get; set; }
        public decimal? QtyIncreaseBy { get; set; }
        public decimal? MaxOrderQty { get; set; }
        public decimal? OnHandQty { get; set; }
        public string MainImgUrl { get; set; }
        public string InsUserName { get; set; }
        public DateTime? InsDate { get; set; }
        public string UpdUserName { get; set; }
        public DateTime? UpdDate { get; set; }
        public byte[] RecId { get; set; }

        public virtual ItemCategory FkCategory { get; set; }
        public virtual ItemType FkItemType { get; set; }
        public virtual Client FkVendor { get; set; }

        public virtual ICollection<ItemBarCode> ItemBarCode { get; set; }
        public virtual ICollection<ItemsPackages> ItemsPackages { get; set; }

    }
}
