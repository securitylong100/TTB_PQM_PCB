using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.CRM.Invoices
{
    public class tbl_payment : DbModel
    {
        [Display(Name = "Invoice No", AutoGenerateField = true, Order = 1)]
        public string invoice_cd { get; set; }
        [Display(Name = "Payment Date", AutoGenerateField = true, Order = 2)]
        public DateTime payment_date { get; set; }
        [Display(Name = "Deposit", AutoGenerateField = true, Order = 3)]
        public decimal deposit { get; set; }
    }
}
