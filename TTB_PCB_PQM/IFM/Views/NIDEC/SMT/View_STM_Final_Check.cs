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
using DevExpress.XtraGrid.Views.Grid;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Final_Check : RibbonForm
    {
        DataTable dt;
        string model_;
        string datetimeCur_;
        string datetimePrevious_;
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
                getsizelayout();
                createlayout("Null");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void getsizelayout()
        {
            string sql_model = "select distinct(model_cd)   from smt_m_model smm  order by model_cd";
            string sql_cl = "select model_columns  from smt_m_model smm2  where 1=1 and model_cd  ='" + cbm_modelcd.Text + "' ";
            string sql_row = "select model_rows  from smt_m_model smm2  where 1=1 and model_cd  ='" + cbm_modelcd.Text + "' ";
            pgsqlconnection con = new pgsqlconnection();
            con.getComboBoxData(sql_model, ref cbm_modelcd);
            if (cbm_modelcd.Text != "")
            {
                nm_column.Value = int.Parse(con.sqlExecuteScalarString_Autosystem(sql_cl));
                nm_row.Value = int.Parse(con.sqlExecuteScalarString_Autosystem(sql_row));
            }
        }
        void createlayout(string strtxt)
        {
            gv_layout.DataSource = null;
            gv_layout.Rows.Clear();
            gv_layout.Refresh();

            int col_ = int.Parse(nm_column.Value.ToString());
            int row_ = int.Parse(nm_row.Value.ToString());
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
                    gv_layout.Rows[rw].Cells[cl].Value = strtxt;
                }
            }
            gv_layout.Refresh();

        }

        private void cbm_modelcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            // OnLoad(e);
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
            OnLoad(e);
            if (checkcondition())
            {
                model_ = cbm_modelcd.Text;
                datetimeCur_ = DateTime.Now.ToString("yyyyMM");
                datetimePrevious_ = DateTime.Now.AddMonths(-1).ToString("yyyyMM");
                getPQM(model_ + datetimeCur_);
                if (gv_data.RowCount < 1)
                {
                    getPQM(model_ + datetimePrevious_);
                }
                txt_barcode.Text = "";
            }
        }

        void getPQM(string table)
        {
            dt = new DataTable();
            gc_data.DataSource = null;
            gv_data.Columns.Clear();
            string sqlgetPQM = @"select a.site ,a.factory ,a.serno ,a.process , max(a.result) as result,max(a.inspectdate) as inspectdate  from 
                                    (
                                    select l.site , l.factory ,l.serno, l.process, sum(CAST(ld.judge AS INTEGER)) as result  ,max(ld.inspectdate) as inspectdate  from " + table + @" l 
                                    left join " + table + @"data ld 
                                    on l.serno  = ld.serno 
                                    where 1=1
                                    and l.inspectdate  = ld.inspectdate 
                                    and l.serno = '" + txt_barcode.Text + @"'
                                    group  by l.site , l.factory ,l.serno ,l.process , l.inspectdate
                                    )a 
                                    group  by a.site ,a.factory ,a.serno ,a.process";
            pgsqlconnection_NewDB conPQM = new pgsqlconnection_NewDB();
            conPQM.sqlDataAdapterFillDatatable(sqlgetPQM, ref dt);
            gc_data.DataSource = dt;
        }
        bool checkcondition()
        {
            if (txt_barcode.Text.Length < 5||cbm_modelcd.Text =="")
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void gv_data_RowStyle(object sender, RowStyleEventArgs e)
        {
            int result = Convert.ToInt32(gv_data.GetRowCellValue(e.RowHandle, "result"));

            if (result > 0)
            {
                e.Appearance.BackColor = Color.Red;
                createlayout("OK");
            }
            else
            {
                e.Appearance.BackColor = Color.LightGreen;
                createlayout("NG");
            }
            e.HighPriority = true;
        }
    }
}