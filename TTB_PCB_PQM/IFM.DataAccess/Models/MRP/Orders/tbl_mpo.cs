using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.MRP.Orders
{
    public class tbl_mpo : DbModel
    {
        [Display(Name = "Product Order", AutoGenerateField = true, Order = 1)]
        public string mpo_cd { get; set; }
        [Display(Name = "Quote", AutoGenerateField = true, Order = 2)]
        public string quote_cd { get; set; }
        [Display(Name = "Item Code", AutoGenerateField = true, Order = 3)]
        public string item_cd { get; set; }
        [Display(Name = "Item Name", AutoGenerateField = true, Order = 4)]
        public string item_name { get; set; }
        [Display(Name = "Order Qty", AutoGenerateField = true, Order = 5)]
        public decimal qty { get; set; }
        [Display(Name = "Unit", AutoGenerateField = true, Order = 6)]
        public string unit { get; set; }
        [Display(Name = "Unit Price", AutoGenerateField = true, Order = 7)]
        public decimal unit_price { get; set; }
        [Display(Name = "Unit Cost", AutoGenerateField = true, Order = 8)]
        public decimal unit_cost { get; set; }
        [Display(Name = "Drawing Path", AutoGenerateField = true, Order = 9)]
        public string drawing_path { get; set; }
        [Display(Name = "Start Date", AutoGenerateField = true, Order = 10)]
        public DateTime start_date { get; set; }
        [Display(Name = "Due Date", AutoGenerateField = true, Order = 11)]
        public DateTime due_date { get; set; }
        [Display(Name = "State", AutoGenerateField = true, Order = 12)]
        public string mpo_state { get; set; }
    }
}
