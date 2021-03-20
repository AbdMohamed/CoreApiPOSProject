using System.ComponentModel.DataAnnotations;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class OffersModel
    {
        [Key]
        public decimal ItemId { get; set; }
        public decimal PromoHeaderId { get; set; }
        public decimal PromoNo { get; set; }
        public string PromoName { get; set; }
        public string TransDate { get; set; }
        public string PromoDateFrom { get; set; }
        public string PromoDateTo { get; set; }
        public string PromoTimeFrom { get; set; }
        public string PromoTimeTo { get; set; }
        public string PurchaseDateFrom { get; set; }
        public string PurchaseDateTo { get; set; }
        public string InsDate { get; set; }
        public decimal ItemCost { get; set; }
        public decimal CustPrice { get; set; }
        public decimal NewCustPrice { get; set; }
        public decimal? VendDiscount { get; set; }
        public decimal ItemTax { get; set; }
        public string ItemName { get; set; }
        public string ItemNameEn { get; set; }
    }
}
