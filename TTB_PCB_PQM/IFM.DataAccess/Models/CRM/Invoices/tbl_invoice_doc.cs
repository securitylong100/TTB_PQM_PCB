using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.CRM.Invoices
{
    public class tbl_invoice_doc : DbModel
    {
        [Display(Name = "Invoice No", AutoGenerateField = true, Order = 1)]
        public string invoice_cd { get; set; }
        [Display(Name = "State", AutoGenerateField = true, Order = 2)]
        public string doc_state { get; set; }
        [Display(Name = "Document Date", AutoGenerateField = true, Order = 3)]
        public DateTime doc_date { get; set; }
        [Display(Name = "Document Path", AutoGenerateField = true, Order = 4)]
        public string doc_path { get; set; }
    }
}