using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.CRM.Customers
{
    public class tbl_customer : DbModel
    {
        [Display(Name = "Customer Code", AutoGenerateField = true, Order = 1)]
        public string cus_cd { get; set; }
        [Display(Name = "Customer Name", AutoGenerateField = true, Order = 2)]
        public string cus_name { get; set; }
        [Display(Name = "Address", AutoGenerateField = true, Order = 3)]
        public string address { get; set; }
        [Display(Name = "Phone", AutoGenerateField = true, Order = 4)]
        public string phone { get; set; }
        [Display(Name = "Email", AutoGenerateField = true, Order = 5)]
        public string email { get; set; }
        [Display(Name = "Contact Person", AutoGenerateField = true, Order = 6)]
        public string contact_person { get; set; }
        [Display(Name = "Payment Period", AutoGenerateField = true, Order = 7)]
        public int payment_period { get; set; }
        [Display(Name = "Debt Period", AutoGenerateField = true, Order = 8)]
        public int debt_period { get; set; }
    }
}
