using System.Collections.Generic;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class itemsResponseData
    {
        public int itemsCount { get; set; }
        public List<CategoryItem> allItemsData { get; set; }
    }
}
