using DevExpress.XtraEditors.Repository;
using System;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;

using DevExpress.XtraBars.Ribbon;

using IFM.Common;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Models;
using IFM.DataAccess.Models.SYS;

using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors.Repository;

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
        public void getcombox(DevExpress.XtraGrid.Views.Grid.GridView gv_, DevExpress.XtraGrid.GridControl gc_)
        {
            RepositoryItemComboBox riComboBox = new RepositoryItemComboBox();
            riComboBox.Items.Add(0);
            riComboBox.Items.Add(1);
            riComboBox.Items.Add(2);
            gc_.RepositoryItems.Add(riComboBox);
            gv_.Columns["status"].ColumnEdit = riComboBox;
        }
    }
}
