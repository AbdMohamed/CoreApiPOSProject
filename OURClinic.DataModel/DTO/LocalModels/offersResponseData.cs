using System.Collections.Generic;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class offersResponseData
    {
        public int itemsCount { get; set; }
        public List<CategoryOffersDisplayItem> allItemsData { get; set; }

    }
}
