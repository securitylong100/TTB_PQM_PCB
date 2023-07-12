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

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Tool_History : RibbonForm
    {
        DataTable dt;
       
        public View_STM_Tool_History()
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
            gc_data.ShowRibbonPrintPreview();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                dt = new DataTable();
                pgsqlconnection con = new pgsqlconnection();
                string sql = "select * from smt_m_tool_history where create_time <= '" + dtp_to.Value + "' and create_time >='" + dtp_from.Value + "' order by id desc";

                con.sqlDataAdapterFillDatatable(sql, ref dt);
                gc_data.DataSource = dt;

                //get station
                string sql_cbm = "select distinct tool_station from smt_m_tool_master smtm ";
                con.getComboBoxData(sql_cbm, ref cbm_station);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

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
        private void cbm_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbm_status.SelectedIndex != null)
            {
                if (cbm_status.SelectedItem == "IN")
                {
                    pn_background.BackColor = Color.Khaki;
                }
                if (cbm_status.SelectedItem == "OUT")
                {
                    pn_background.BackColor = Color.YellowGreen;
                }
            }
        }
        bool checkcondition()
        {
            if (txt_barcode.Text.Length < 5 || cbm_station.SelectedIndex == null || cbm_status.SelectedIndex == null)
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (exitsBarcode(txt_barcode.Text) == 0)
            {
                MessageBox.Show("Barcode này chưa được đăng ký ở master", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (currentstatus() == "SMT_SDR_IN" && beforestatus(txt_barcode.Text) != "SMT_CLR_OUT")
            {
                MessageBox.Show("Barcode Chưa được vệ sinh !", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (currentstatus() == "SMT_SDR_OUT" && beforestatus(txt_barcode.Text) != "SMT_SDR_IN")
            {
                MessageBox.Show("Barcode Chưa được Check IN !", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        int exitsBarcode(string barcode)
        {
            try
            {
                pgsqlconnection con = new pgsqlconnection();
                string sql = "select count(*)  from smt_m_tool_history where tool_cd  ='" + barcode + "'"; //updaed new version
                return con.sqlExecuteNonQueryInt(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
                return 0;
            }
        }
        string beforestatus(string barcode)
        {
            pgsqlconnection con = new pgsqlconnection();
            string sql = @"select  tool_station||'_'||tool_check  from smt_m_tool_history smth  where 1=1
                            and tool_cd  = '" + barcode + @"'
                            order by id desc limit 1";
            return con.sqlExecuteScalarString_Autosystem(sql);
        }
        string currentstatus()
        {
            string connecstring = cbm_station.Text + "_" + cbm_status.Text;
            return connecstring;
        }
        private void btn_enter_Click(object sender, EventArgs e)
        {
            if (checkcondition())
            {
                try
                {
                    pgsqlconnection con = new pgsqlconnection();
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO smt_m_tool_history
                                    (tool_cd , tool_station , tool_check , creator ,create_time )
                                    VALUES("
                                     );
                    sqlinsert.Append("'" + txt_barcode.Text + "',");
                    sqlinsert.Append("'" + cbm_station.Text + "',");
                    sqlinsert.Append("'" + cbm_status.Text + "',");
                    sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteNonQuery(sqlinsert.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
            OnLoad(e);
        }
    }
}