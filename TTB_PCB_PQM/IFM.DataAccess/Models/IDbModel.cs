using System;

namespace IFM.DataAccess.Models
{
    public interface IDbModel
    {
        int ID { get; set; }
        int status { get; set; }
        string comments { get; set; }
        string updater { get; set; }
        DateTime update_time { get; set; }
        string creator { get; set; }
        DateTime create_time { get; set; }
        ModelStatus enum_status { get; set; }
    }
}
