using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IFM.Common
{
    public class ExcelExport
    {
        public void ExportToExcel(DataGridView dgv)
        {
            try
            {
                if (dgv.DataSource == null || dgv.Rows.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;

                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }

                // rows
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excelApp.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.\n" + ex.Message);
            }
        }
    }
}
