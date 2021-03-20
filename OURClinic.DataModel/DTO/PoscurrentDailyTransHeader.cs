using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OURCart.DataModel.DTO
{
    public partial class PoscurrentDailyTransHeader
    {
        public PoscurrentDailyTransHeader()
        {
            PoscurrentDailyTransDetails = new HashSet<PoscurrentDailyTransDetails>();
        }

        [Key]
        public decimal HeaderId { get; set; }
        public int FkBrId { get; set; } = 0;
        public byte FkTransTypeId { get; set; } 
        public decimal? TransNumber { get; set; }
        public decimal? ManualNo { get; set; } 
        public string RefNo { get; set; }
        public string TransDate { get; set; } 
        public decimal? ClientId { get; set; }
        public string ClientName { get; set; }
        public byte? FkClientTypeId { get; set; }
        public byte? SalePriceType { get; set; }
        public int? CashierId { get; set; }
        public string CashierName { get; set; }
        public string Notes { get; set; }
        public byte? FkPaymentTypeId { get; set; }
        public int? CreditPeriod { get; set; }
        public string DueDate { get; set; }
        public byte FkInvoiceStatusId { get; set; } // 1 new 2 hold 3 reserve 4 paid
        public decimal? AdditionRate { get; set; }
        public decimal? Addition { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Total { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Remain { get; set; }
        public int? StoreId { get; set; }
        public string StoreName { get; set; }
        public decimal? DeliveryAmount { get; set; }
        public string SalesRepId { get; set; }
        public string SalesRepName { get; set; }
        public decimal? InsUserId { get; set; }
        public string InsUserName { get; set; }
        public DateTime? InsDate { get; set; }
        public decimal? UpdUserId { get; set; }
        public string UpdDate { get; set; }
        public byte[] RecId { get; set; }
        public decimal? FkPosCloseId { get; set; }
        public string OrgheaderRef { get; set; }
        public string CallerPhone { get; set; }
        public short? FkDeliveryStatusId { get; set; }
        public bool? IsPickupIn { get; set; }
        public string PicupDate { get; set; }
        public string InsDeliverySent { get; set; }
        public string InsDeliveryClosed { get; set; }
        public int? FkEmpId { get; set; }
        public short? FkVisaMachineId { get; set; }
        public decimal? FkVisaCardId { get; set; }
        public string VisaCardInfo { get; set; }
        public decimal? VisaCardDeduct { get; set; }
        public decimal? VisaCardDeductAmount { get; set; }
        public decimal? VisaAmount { get; set; }

        public virtual ICollection<PoscurrentDailyTransDetails> PoscurrentDailyTransDetails { get; set; }
    }
}
