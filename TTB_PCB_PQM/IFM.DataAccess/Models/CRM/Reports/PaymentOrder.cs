using System;

namespace IFM.DataAccess.Models.CRM.Reports
{
    public class PaymentOrder
    {
        public string invoice_cd { get; set; }
        public DateTime invoice_date { get; set; }
        public string cpo_cd { get; set; }
        public string detail { get; set; }
        public DateTime rev_date { get; set; }
        public string cus_cd { get; set; }
        public string cus_name { get; set; }
        public string address { get; set; }
        public string method_pay { get; set; }
        public string comments { get; set; }
        public string unit { get; set; }
        public decimal price { get; set; }
        public decimal qty { get; set; }
    }
}
