using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.NIDEC
{
    public class m_smt_tool : DbModel
    {
        [Display(Name = "ToolCD", AutoGenerateField = true, Order = 1)]
        public string tool_cd { get; set; }
        [Display(Name = "ToolName", AutoGenerateField = true, Order = 2)]
        public string tool_name { get; set; }
        [Display(Name = "ToolStation", AutoGenerateField = true, Order = 3)]
        public string tool_station { get; set; }
        [Display(Name = "ModelCode", AutoGenerateField = true, Order = 4)]
        public string model_cd { get; set; }
        [Display(Name = "ToolActive", AutoGenerateField = true, Order = 5)]
        public int tool_active { get; set; }
        [Display(Name = "Priority", AutoGenerateField = true, Order = 6)]
        public int priority { get; set; }
        public m_smt_tool()
        {
            ID = 0;
            tool_station = string.Empty == "" ? "SMT_SDR" : tool_station;
            model_cd = string.Empty == "" ? "" : model_cd;
            comments = string.Empty ==""?"Null":comments;
            updater = string.Empty;
            update_time = DateTime.Now;
            creator = string.Empty;
            create_time = DateTime.Now;
        }
    }
  
}
