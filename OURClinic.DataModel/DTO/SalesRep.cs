using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OURCart.DataModel.DTO
{
    public partial class SalesRep
    {
        public SalesRep()
        {
            //CartProducts = new HashSet<CartProducts>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SalesRepId { get; set; }
        public string SalesRepName { get; set; }
        public string SalesRepNameEn { get; set; }
        public string AreaId { get; set; }      
        public decimal? PurchaseCommision { get; set; }
        public decimal? SalesCommision { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string InsUserId { get; set; } = "0";
        public string InsDate { get; set; } 
        public int UpdUserId { get; set; } = 0;
        public string UpdDate { get; set; } = "0";
        public byte[] RecId { get; set; }
        public string Phone { get; set; } = "0";
        public string GcmToken { get; set; }

    }
}
