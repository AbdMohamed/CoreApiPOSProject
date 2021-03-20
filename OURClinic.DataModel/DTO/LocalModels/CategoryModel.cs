using System.Collections.Generic;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class CategoryModel : ItemCategory
    {
        public bool HasSubCategories { get; set; }
        //public virtual List<CategoryItem> ItemsInCat { get; set; }
        public virtual string CategoryImage { get; set; }


    }

}
