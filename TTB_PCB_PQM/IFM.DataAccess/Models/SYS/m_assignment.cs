using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.SYS
{
    public class m_assignment : DbModel
    {
        [Display(Name = "Code", AutoGenerateField = true, Order = 1)]
        public string assign_code { get; set; }
        [Display(Name = "Name", AutoGenerateField = true, Order = 2)]
        public string assign_name { get; set; }
        [Display(Name = "Name (VN)", AutoGenerateField = true, Order = 3)]
        public string assign_name_vn { get; set; }
        [Display(Name = "View", AutoGenerateField = true, Order = 4)]
        public string assign_view { get; set; }
        [Display(Name = "Parent", AutoGenerateField = true, Order = 5)]
        public string parent_code { get; set; }
        [Display(Name = "Priority", AutoGenerateField = true, Order = 6)]
        public int priority { get; set; }

        public static m_assignment Empty { get; } = new m_assignment();

        public m_assignment()
        {
            ID = 0;
            assign_code = string.Empty == "" ? "Null" : comments;
            assign_name = string.Empty == "" ? "Null" : comments;
            assign_name_vn = string.Empty == "" ? "Null" : comments;
            assign_view = string.Empty == "" ? "Null" : comments;
            parent_code = string.Empty == "" ? "Null" : comments;
            priority = 0;
            status = 3;
            comments = string.Empty == "" ? "Null" : comments;
            updater = string.Empty;
            update_time = DateTime.Now;
            creator = string.Empty;
            create_time = DateTime.Now;
            //ID = 0;
            //comments = string.Empty == "" ? "Null" : comments;
            //updater = string.Empty;
            //update_time = DateTime.Now;
            //creator = string.Empty;
            //create_time = DateTime.Now;
        }
    }
}
