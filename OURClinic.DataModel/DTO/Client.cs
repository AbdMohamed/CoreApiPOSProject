using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public partial class Client
    {
        public Client()
        {
            Items = new HashSet<Items>();
        }

        public decimal ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientNameEng { get; set; }
        public int? CityId { get; set; }
        public byte? PriceCatId { get; set; }
        public byte? ClientTypeId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string TaxCardNo { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? CreditLimitInvoice { get; set; }
        public string TaxFileNo { get; set; }
        public string CommercailRegistryNo { get; set; }
        public string KeyPerson { get; set; }
        public string TaxRegistrationNo { get; set; }
        public string FkClientCategoryId { get; set; }
        public decimal? WithholdingTax { get; set; }
        public string CreditPeriod { get; set; }
        public string InsUserId { get; set; }
        public string InsDate { get; set; }
        public int? UpdUserId { get; set; }
        public string UpdDate { get; set; }
        public byte[] RecId { get; set; }
        public string FkAccNo { get; set; }
        public string ContractStartDate { get; set; }
        public decimal? ContractPeriod { get; set; }
        public string ContractNotes { get; set; }
        public string FkSalesRepId { get; set; }
        public int? AreaId { get; set; }
        public byte? FkAgeGroupId { get; set; }
        public string Password { get; set; }
        public string ActivationCode { get; set; }
        public bool IsActivated { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
