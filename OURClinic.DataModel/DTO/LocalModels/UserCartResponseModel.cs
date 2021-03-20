using System;
using System.Collections.Generic;
using System.Text;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class UserCartResponseModel
    {
        public IEnumerable<userCartItem> allProducts { get; set; }
        public decimal? Total { get; set; }      //  Delivery Tax + Subtotal
        public decimal? SubTotal { get; set; }   // all products Prices
        public decimal? Delivery { get; set; }   // delivery Tax

    }
}
