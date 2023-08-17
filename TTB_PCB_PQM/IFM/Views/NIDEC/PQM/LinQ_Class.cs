using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Windows;

namespace IFM.Views.NIDEC.PQM
{
    public static class LinQ_Class
    {
        public static DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue, DataColumn pivotValue1)
        {
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            temp.Columns.Remove(pivotValue1.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            try
            {
                // find primary key columns 
                //(i.e. everything but pivot column and pivot value)

                result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
                dt.AsEnumerable()
                    .Select(r => r[pivotColumn.ColumnName].ToString())
                    .Distinct().ToList()
                    .ForEach(c =>
                    {
                        result.Columns.Add(c, pivotColumn.DataType);
                        result.Columns.Add(c + "judge", pivotColumn.DataType);
                    });

                // load it
                foreach (DataRow row in dt.Rows)
                {
                    // find row to update
                    DataRow aggRow = result.Rows.Find(
                        pkColumnNames
                            .Select(c => row[c])
                            .ToArray());
                    // the aggregate used here is LATEST 
                    // adjust the next line if you want (SUM, MAX, etc...)
                    aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];
                    aggRow[row[pivotColumn.ColumnName].ToString() + "judge"] = row[pivotValue1.ColumnName];
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            return result;
        }

        public static DataTable Joined(DataTable dt1, DataTable dt2)
        {
            DataTable dtjoined = new DataTable();
            try
            {
                var result = from a in dt1.AsEnumerable()
                             join b in dt2.AsEnumerable()
                             on new { x = a["serno"], y = a["inspectdate"] }
                             equals new { x = b["serno"], y = b["inspectdate"] }
                             select new
                             {
                                 a,
                                 b
                             };

                foreach (DataColumn col in dt1.Columns)
                    dtjoined.Columns.Add(col.ColumnName);
                foreach (DataColumn col in dt2.Columns)
                {
                    if (!dtjoined.Columns.Contains(col.ColumnName))
                        dtjoined.Columns.Add(col.ColumnName);
                }
                foreach (var row in result)
                {
                    var newrow = dtjoined.NewRow();
                    int n = row.b.ItemArray.Count();
                    object[] a = new object[n - 2];
                    for (int i = 0; i < n - 2; i++)
                    {
                        a[i] = row.b.ItemArray[i + 2];
                    }
                    newrow.ItemArray = (row.a.ItemArray.Concat(a)).ToArray();
                    dtjoined.Rows.Add(newrow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            return dtjoined;
        }
    }
}
