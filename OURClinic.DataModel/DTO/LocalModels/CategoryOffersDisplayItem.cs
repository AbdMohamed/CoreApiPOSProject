using System;
using System.Collections.Generic;
using System.Text;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class CategoryOffersDisplayItem : CategoryItemsDisplayItem
    {
        public decimal PromoNo { get; set; }
        public string PromoName { get; set; }
        public string TransDate { get; set; }
        public string PromoDateFrom { get; set; }
        public string PromoDateTo { get; set; }
        public decimal? ItemCost { get; set; }
        public decimal? CustPrice { get; set; }
        public decimal? NewCustPrice { get; set; }
    }
}
