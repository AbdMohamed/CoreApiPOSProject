using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OURCart.DataModel.DTO
{
    public partial class DeliveryClient
    {
        public DeliveryClient()
        {
            //CartProducts = new HashSet<CartProducts>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public decimal DelClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientNameEn { get; set; }
        public int? FkMemberShipId { get; set; }
        public int? FkAreaId { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Address { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string SpecialMark { get; set; }
        public string PrintNotes { get; set; }
        public string AdminNotes { get; set; }
        public bool WholeSale { get; set; }
        public bool PosdiscountType { get; set; }
        public decimal Posdiscount { get; set; }
        public decimal SalesBalance { get; set; }
        public decimal PointsBalance { get; set; }
        public string InsUserId { get; set; } = "0";
        public DateTime? InsDate { get; set; } = DateTime.Now;
        public string UpdUserId { get; set; }
        public DateTime? UpdDate { get; set; }
        public byte[] RecId { get; set; }
      
        public string Email { get; set; }
        public string FkAccNo { get; set; }
        public string Password { get; set; }
        public string LocationAddress { get; set; }
        public string HouseNum { get; set; }

        public virtual Area FkArea { get; set; }

        public string GcmToken { get; set; }
        //public virtual ICollection<CartProducts> CartProducts { get; set; }
    }
}
