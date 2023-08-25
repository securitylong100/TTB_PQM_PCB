using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.NIDEC
{
    public class m_smt_model : DbModel
    {
        [Display(Name = "ModelCode", AutoGenerateField = true, Order = 1)]
        public string model_cd { get; set; }

        [Display(Name = "ModelColumns", AutoGenerateField = true, Order = 2)]
        public int model_columns { get; set; }
        [Display(Name = "ModelRows", AutoGenerateField = true, Order = 3)]
        public int model_rows { get; set; }


        public m_smt_model()
        {
            ID = 0;    
            model_cd = string.Empty == "" ? "" : model_cd;
          
            updater = string.Empty;
            update_time = DateTime.Now;
            creator = string.Empty;
            create_time = DateTime.Now;
        }
    }
  
}
