using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OURCart.DataModel.DTO
{

    /// <summary>
    ///  ItemId required    /// </summary>
    public partial class CartProducts
    {
       

        public int Id { get; set; }
        public decimal quantity { get; set; }
        public bool IsNew { get; set; }
        public decimal FkItemId { get; set; } //items
        public decimal fkPackageID { get; set; } //items

        public DateTime? InsertDateTime { get; set; }
        //2019-06-22 20:33:00 used to bind date time in flutter
        //public String InsertDateTimeFormat { get { return InsertDateTime?.ToString("yyyy-MM-dd HH:mm:ss"); } }
        public decimal? fk_itemBarCodeID { get; set; }
        public decimal FkDeliveryClientId { get; set; } //one sala
        //[ForeignKey("FkItemId")]
       // public virtual Items item { get; set; /*}*/
        //public virtual DeliveryClient FkDeliveryClient { get; set; }
    }
}
