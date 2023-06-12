using System;
using System.ComponentModel.DataAnnotations;

namespace IFM.DataAccess.Models
{
    public class DbModel : IDbModel
    {
        [Display(Name = "No", AutoGenerateField = false, Order = 0)]
        public int ID { get; set; }

        [Display(Name = "Comments", AutoGenerateField = true, Order = 993)]
        public string comments { get; set; }

        [Display(Name = "Status (No)", AutoGenerateField = false, Order = 994)]
        public int status { get; set; }

        [Display(Name = "Status", AutoGenerateField = false, Order = 995)]
        public ModelStatus enum_status
        {
            get => (ModelStatus)status;
            set => status = (int)value;
        }

        [Display(Name = "Updater", AutoGenerateField = false, Order = 996)]
        public string updater { get; set; }

        [Display(Name = "Update Time", AutoGenerateField = false, Order = 997)]
        public DateTime update_time { get; set; }

        [Display(Name = "Creator", AutoGenerateField = false, Order = 998)]
        public string creator { get; set; }

        [Display(Name = "Create Time", AutoGenerateField = false, Order = 999)]
        public DateTime create_time { get; set; }

        public DbModel() { }

        public T Clone<T>() where T : DbModel
        {
            return (T)this.MemberwiseClone();
        }

        public void CopyTo<T>(ref T obj) where T : DbModel
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var sProperty = this.GetType().GetProperty(property.Name);
                if (sProperty != null)
                {
                    var val = property.GetValue(this);
                    property.SetValue(obj, val);
                }
            }
        }
    }
}
