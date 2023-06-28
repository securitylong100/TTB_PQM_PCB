using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Models;
using IFM.DataAccess.Models.SYS;
using System;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Windows.Forms;
using IFM.Class;
using System.Data;
using System.Text;
using DevExpress.XtraGrid.Columns;
using System.Windows.Controls;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Final_Check : RibbonForm
    {
        DataTable dt;

        public View_STM_Final_Check()
        {
            InitializeComponent();
            dtp_from.Value = DateTime.Now.AddDays(-2);
            dtp_to.Value = DateTime.Now.AddDays(+1);
            AcceptButton = btn_enter;
        }

        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }
        void BbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                //design layout main for other model
                createlayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void createlayout()
        {
            // Alignment = DataGridViewContentAlignment.MiddleCenter,
            gv_layout.DataSource = null;
            gv_layout.Rows.Clear();
            gv_layout.Refresh();
            int col_ = int.Parse(nm_column.Text);
            int row_ = int.Parse(nm_row.Text);
            gv_layout.ColumnCount = col_ + 1;
            for (int i = 1; i <= col_ + 1; i++)
            {
                gv_layout.Columns[i - 1].Name = (i - 1).ToString();
                gv_layout.Columns[i - 1].Width = 70;
                gv_layout.Columns[0].Width = 20;
                gv_layout.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int j = 1; j <= row_; j++)
            {
                string[] row = new string[] { j.ToString() };
                gv_layout.Rows.Add(row);
            }
            for (int cl = 1; cl < gv_layout.ColumnCount; cl++)
            {
                for (int rw = 0; rw < gv_layout.RowCount; rw++)
                {
                    gv_layout.Rows[rw].Cells[cl].Value = "Null";
                }
            }
            gv_layout.Refresh();
        }
        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_enter_Click(sender, e);
        }
        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_enter_Click(sender, e);
        }
        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnLoad(e);
        }
        private void btn_enter_Click(object sender, EventArgs e)
        {
            if(checkcondition())
            {
                getPQM();
            }    
        }
        void getPQM()
        {
            string sqlgetPQM = @"select a.site ,a.factory ,a.serno ,a.process , max(a.result),max(a.inspectdate) from 
                                    (
                                    select l.site , l.factory ,l.serno, l.process, sum(CAST(ld.judge AS INTEGER)) as result  ,max(ld.inspectdate) as inspectdate  from ld20202101 l 
                                    left join ld20202101data ld 
                                    on l.serno  = ld.serno 
                                    where 1=1
                                    and l.inspectdate  = ld.inspectdate 
                                    and l.serno = '"+txt_barcode.Text+@"'
                                    group  by l.site , l.factory ,l.serno ,l.process , l.inspectdate
                                    )a 
                                    group  by a.site ,a.factory ,a.serno ,a.process ";


        }
        bool checkcondition()
        {
            if (txt_barcode.Text.Length < 5 )
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}