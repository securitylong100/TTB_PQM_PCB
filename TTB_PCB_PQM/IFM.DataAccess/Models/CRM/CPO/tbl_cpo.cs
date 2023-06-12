using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.CRM.CPO
{
    public class tbl_cpo : DbModel
    {
        [Display(Name = "Quote", AutoGenerateField = true, Order = 1)]
        public string quote_cd { get; set; }
        [Display(Name = "Customer", AutoGenerateField = true, Order = 2)]
        public string cus_cd { get; set; }
        [Display(Name = "Customer Order", AutoGenerateField = true, Order = 3)]
        public string cpo_cd { get; set; }
        [Display(Name = "Detail", AutoGenerateField = true, Order = 4)]
        public string detail { get; set; }
        [Display(Name = "Receive Date", AutoGenerateField = true, Order = 5)]
        public DateTime rev_date { get; set; }
        [Display(Name = "Quote Date", AutoGenerateField = true, Order = 6)]
        public DateTime quote_date { get; set; }
        [Display(Name = "Confirm Date", AutoGenerateField = true, Order = 7)]
        public DateTime? cfm_date { get; set; }
        [Display(Name = "Ship Date", AutoGenerateField = true, Order = 8)]
        public DateTime? ship_date { get; set; }
        [Display(Name = "State", AutoGenerateField = true, Order = 9)]
        public int quote_state { get; set; }

        public QuoteStates QuoteState
        {
            get => (QuoteStates)quote_state;
            set => quote_state = (int)value;
        }

        public tbl_cpo()
        {
            QuoteState = QuoteStates.New;
        }
    }

    public enum QuoteStates
    {
        New = 0,
        Send = 1,
        Approved = 2,
        Producted = 3,
        Shipped = 4,
        Customs = 5,
        Invoiced = 6,
        Debt = 7,
        Paid = 8
    }
}
