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
        [Display(Name = "ToolProject", AutoGenerateField = true, Order = 4)]
        public string tool_project { get; set; }
        [Display(Name = "ToolActive", AutoGenerateField = true, Order = 5)]
        public int tool_active { get; set; }
        [Display(Name = "Priority", AutoGenerateField = true, Order = 6)]
        public int priority { get; set; }
        public m_smt_tool()
        {
            ID = 0;
            tool_station = string.Empty == "" ? "" : tool_station;
            tool_project = string.Empty == "" ? "SMT Frame" : tool_project;
            comments = string.Empty ==""?"Null":comments;
            updater = string.Empty;
            update_time = DateTime.Now;
            creator = string.Empty;
            create_time = DateTime.Now;
        }
    }
  
}
