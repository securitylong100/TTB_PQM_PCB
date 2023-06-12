using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.CRM.Invoices
{
    public class tbl_invoice : DbModel
    {
        [Display(Name = "Invoice No", AutoGenerateField = true, Order = 1)]
        public string invoice_cd { get; set; }
        [Display(Name = "Invoice Date", AutoGenerateField = true, Order = 2)]
        public DateTime invoice_date { get; set; }
        [Display(Name = "Customer", AutoGenerateField = true, Order = 3)]
        public string cus_cd { get; set; }
        [Display(Name = "Expired Date", AutoGenerateField = true, Order = 4)]
        public DateTime? expired_date { get; set; }
        [Display(Name = "Remind Date", AutoGenerateField = true, Order = 5)]
        public DateTime? remind_date { get; set; }
        [Display(Name = "State", AutoGenerateField = true, Order = 6)]
        public string invoice_state { get; set; }
    }
}
