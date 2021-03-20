using System;
using System.Collections.Generic;
using System.Text;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class orderStatusModel
    {
       public decimal HeaderId { set; get; }
       public string SalesRepId { set; get; }
       public short FkDeliveryStatusId { set; get; }

}

    public class cartItemsWithFees
    {
        public decimal fees { set; get; }
        public List<CategoryItemWithQnty> cartProducts { set; get; }
    }
}
