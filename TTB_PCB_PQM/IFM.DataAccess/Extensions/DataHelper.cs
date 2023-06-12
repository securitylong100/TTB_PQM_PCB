using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace IFM.DataAccess.Extensions
{
    public static class DataHelper
    {
        public static void QuickOpen(this IDbConnection conn, int timeout)
        {
            // We'll use a Stopwatch here for simplicity. A comparison to a stored DateTime.Now value could also be used
            Stopwatch sw = new Stopwatch();
            bool connectSuccess = false;

            // Try to open the connection, if anything goes wrong, make sure we set connectSuccess = false
            Thread t = new Thread(delegate ()
            {
                try
                {
                    sw.Start();
                    conn.Open();
                    connectSuccess = true;
                }
                catch { }
            })
            {
                // Make sure it's marked as a background thread so it'll get cleaned up automatically
                IsBackground = true
            };
            t.Start();

            // Keep trying to join the thread until we either succeed or the timeout value has been exceeded
            while (timeout > sw.ElapsedMilliseconds / 1000)
                if (t.Join(1))
                    break;
            // If we didn't connect successfully, throw an exception
            if (!connectSuccess)
            {
                throw new TimeoutException($"Connect time out - DB: {conn.Database} - {timeout}s");
            }
        }

        public static T MapTo<T>(this IDataReader reader)
        {
            var obj = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                int index = reader.GetIndex(property.Name);
                if (index > -1)
                {
                    object value = reader.IsDBNull(index) ? null : reader[property.Name];
                    property.SetValue(obj, value);
                }
            }
            return obj;
        }

        public static T[] MapToArray<T>(this IDataReader reader)
        {
            try
            {
                return reader.Collect<T>().ToArray();
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
        }

        public static List<T> MapToList<T>(this IDataReader reader)
        {
            try
            {
                return reader.Collect<T>().ToList();
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }
        }

        public static DataTable ToTable<T>(this IEnumerable<T> data)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            return data.Select(x => properties.Select(p => p.GetValue(x))).Cast<DataRow>().ToTable();
        }
     
        public static IEnumerable<T> Collect<T>(this IDataReader reader)
        {
            if (reader != null)
            {
                while (reader.Read())
                {
                    yield return reader.MapTo<T>();
                }
            }
        }

        public static int GetIndex(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return i;
            }
            return -1;
        }
    }
}
