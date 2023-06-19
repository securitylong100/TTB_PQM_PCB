using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.SYS
{
    public class m_user_role : DbModel
    {
        [Display(Name = "View", AutoGenerateField = true, Order = 1)]
        public string assign_code { get; set; }
        [Display(Name = "User", AutoGenerateField = true, Order = 2)]
        public string user_cd { get; set; }
        [Display(Name = "Priority", AutoGenerateField = true, Order = 3)]
        public int priority { get; set; }
        public m_user_role()
        {
            ID = 0;
            comments = string.Empty ==""?"Null":comments;
            updater = string.Empty;
            update_time = DateTime.Now;
            creator = string.Empty;
            create_time = DateTime.Now;
        }
    }
    public class m_user : DbModel
    {
        [Display(Name = "UserCode", AutoGenerateField = true, Order = 1)]
        public string user_cd { get; set; }
        [Display(Name = "Username", AutoGenerateField = true, Order = 2)]
        public string user_name { get; set; }
        [Display(Name = "Password", AutoGenerateField = true, Order = 3)]
        public string user_pass { get; set; }
        [Display(Name = "Role", AutoGenerateField = true, Order = 4)]
        public int user_role { get; set; }
        [Display(Name = "Email", AutoGenerateField = true, Order = 5)]
        public string user_email { get; set; }
        [Display(Name = "Permision", AutoGenerateField = true, Order = 6)]
        public string user_permision { get; set; }
        [Display(Name = "Language", AutoGenerateField = true, Order = 7)]
        public string user_lang { get; set; }
      
        public static m_user Empty { get; } = new m_user();
        public m_user()
        {
            ID = 0;
            comments = string.Empty;
            updater = string.Empty;
            update_time = DateTime.Now;
            creator = string.Empty;
            create_time = DateTime.Now;
        }
       
    }
}
