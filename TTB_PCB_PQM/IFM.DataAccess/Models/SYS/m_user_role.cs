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
    }
}
