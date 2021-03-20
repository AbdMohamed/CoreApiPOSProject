using System.ComponentModel.DataAnnotations;

namespace OURCart.DataModel.DTO.LocalModels
{
    //used to parse what return from db as total of all products in cureent user logged cart
    public class CartTotalModel
    {
        [Key]
        public decimal total { get; set; }
    }
}
