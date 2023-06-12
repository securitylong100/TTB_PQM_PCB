using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.SYS
{
    public class sp_user_login
    {
        [Display(Name = "User Code", AutoGenerateField = true, Order = 1)]
        public string user_cd { get; set; }
        [Display(Name = "User Name", AutoGenerateField = true, Order = 2)]
        public string user_name { get; set; }
        [Display(Name = "Assignments", AutoGenerateField = true, Order = 3)]
        public string assign_code { get; set; }
        [Display(Name = "Language", AutoGenerateField = true, Order = 4)]
        public string user_lang { get; set; }
    }
}
