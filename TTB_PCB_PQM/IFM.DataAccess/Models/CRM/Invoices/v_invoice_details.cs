using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.CRM.Invoices
{
    public class v_invoice_details
    {
        [Display(Name = "Invoice No", AutoGenerateField = true, Order = 1)]
        public string invoice_cd { get; set; }
        [Display(Name = "IFM Code", AutoGenerateField = true, Order = 2)]
        public string global_cd { get; set; }
        [Display(Name = "Detail", AutoGenerateField = true, Order = 3)]
        public string detail { get; set; }
        [Display(Name = "Price", AutoGenerateField = true, Order = 4)]
        public decimal price { get; set; }
        [Display(Name = "Discount", AutoGenerateField = true, Order = 5)]
        public decimal discount { get; set; }
        [Display(Name = "Recieve Date", AutoGenerateField = true, Order = 6)]
        public DateTime rev_date { get; set; }
        [Display(Name = "Confirm Date", AutoGenerateField = true, Order = 7)]
        public DateTime? cfm_date { get; set; }
        [Display(Name = "Ship Date", AutoGenerateField = true, Order = 8)]
        public DateTime? ship_date { get; set; }
        [Display(Name = "State", AutoGenerateField = true, Order = 9)]
        public string cpo_state { get; set; }
        [Display(Name = "Exchange Rate", AutoGenerateField = false, Order = 10)]
        public decimal exchange_rate { get; set; }
    }
}
