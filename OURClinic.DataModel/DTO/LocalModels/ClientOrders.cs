using System;
using System.Collections.Generic;
using System.Text;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class ClientOrders
    {
        public decimal? Total { get; set; }
        public decimal? DeliveryFees { get; set; }

        public decimal HeaderId { get; set; }
        public decimal? ClientId { get; set; }
        public DateTime? InsDate { get; set; } 
        public string SalesRepId { get; set; }
        public string SalesRepName { get; set; }
        public string Notes { get; set; }

        public short? FkDeliveryStatusId { get; set; }


        public List<CategoryItemWithQnty> POSCurrentDailyTransDetails { get; set; }
    }
    public class ClientOrdersClient
    {
        public decimal? Total { get; set; }
        public decimal? DeliveryFees { get; set; }

        public decimal HeaderId { get; set; }
        public decimal? ClientId { get; set; }
        public DateTime? InsDate { get; set; }
        public string SalesRepId { get; set; }
        public string Notes { get; set; }


        public short? FkDeliveryStatusId { get; set; }
        public DeliveryClient client { get; set; }



        public List<CategoryItemWithQnty> POSCurrentDailyTransDetails { get; set; }
    }
}
