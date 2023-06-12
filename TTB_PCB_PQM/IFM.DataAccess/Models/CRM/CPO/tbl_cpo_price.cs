using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.CRM.CPO
{
    public class tbl_cpo_price : DbModel
    {
        [Display(Name = "Quote", AutoGenerateField = true, Order = 1)]
        public string quote_cd { get; set; }
        [Display(Name = "Q'ty", AutoGenerateField = true, Order = 2)]
        public decimal qty { get; set; }
        [Display(Name = "Price", AutoGenerateField = true, Order = 3)]
        public decimal price { get; set; }
    }
}
