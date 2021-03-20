using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OURCart.DataModel.DTO.LocalModels
{
    /// <summary>
    /// - class contains all product data that is exist in user cart  
    /// will be used when user want to get all products in his cart 
    /// </summary>
    public class userCartItem
    {
        public decimal ItemId { get; set; }
        public int fkCategoryId { get; set; }
        public decimal? PurchaseDiscount { get; set; }
        public string Notes { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public decimal? ItemCost { get; set; }
        public decimal? CustomerPrice { get; set; }
        public decimal PackageId { get; set; }
        public decimal ItemPackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageNameEn { get; set; }
        public byte PackageSize { get; set; }
        //public decimal fk_itemBarCodeID { get; set; }
        public string BarCode { get; set; }
        public string BarCodeFormat { get; set; }

        public int Id { get; set; } // cart product id in db 
        public int quantity { get; set; }
        //public decimal? fk_itemPackageID { get; set; }
        //public decimal fk_temID { get; set; }
        public DateTime? insertDateTime { get; set; }
        //2019-06-22 20:33:00
        public String InsertDateTimeFormat { get { return insertDateTime?.ToString("yyyy-MM-dd HH:mm:ss"); } }
        public decimal? fk_itemBarCodeID { get; set; }
        public decimal fk_DeliveryClientId { get; set; }


    }
}
