using System;

namespace IFM.Common.OnGrid
{
    public class Functions
    {
        public string ConvertDate(string input)
        {
            string result;
            DateTime dtime;
            dtime = Convert.ToDateTime(input);
            result = dtime.ToString("yyyy-MM-dd HH:mm:00");
            return result;
        }
        public string ConvertDateFull(string input)
        {
            string result;
            DateTime dtime;
            dtime = Convert.ToDateTime(input);
            result = dtime.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }
        public DateTime CovertStringToDate(string input)
        {
            DateTime result;
            result = Convert.ToDateTime(input);
            return result;
        }
    }
}
