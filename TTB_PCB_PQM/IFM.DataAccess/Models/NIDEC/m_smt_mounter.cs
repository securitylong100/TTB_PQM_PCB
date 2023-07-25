using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models.NIDEC
{
    public class m_smt_mounter : DbModel
    {
        [Display(Name = "ModelCode", AutoGenerateField = true, Order = 1)]
        public string model_cd { get; set; }

        [Display(Name = "ItemList", AutoGenerateField = true, Order = 2)]
        public string item_list { get; set; }


        public m_smt_mounter()
        {
            ID = 0;
            item_list = string.Empty == "" ? "Null" : item_list;
            model_cd = string.Empty == "" ? "" : model_cd;
           // comments = string.Empty ==""?"Null":comments;
            updater = string.Empty;
            update_time = DateTime.Now;
            creator = string.Empty;
            create_time = DateTime.Now;
        }
    }
  
}
