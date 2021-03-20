using System.ComponentModel.DataAnnotations;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class itemsCountInCategory
    {
        [Key]
        public int itemsCount { get; set; }
    }
}
