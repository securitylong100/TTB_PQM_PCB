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
    public partial class View_STM_Mounter_History : RibbonForm
    {
        DataTable dt;

        public View_STM_Mounter_History()
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
                StringBuilder sqlget = new StringBuilder();
                sqlget.Append(@"select a.id,b.model_cd , a.tool_cd, a.tool_station, a.tool_check, b.tool_name ,a.creator, a.create_time  from smt_m_tool_history a 
                            left join smt_m_tool_master b  
                            on a.tool_cd  = b.tool_cd 
                            where a.create_time <= '" + dtp_to.Value + @"'
                            and a.create_time >='" + dtp_from.Value + @"' ");
                if(txt_barcode.Text !="")
                {
                    sqlget.Append("and a.tool_cd = '" + txt_barcode.Text + @"' ");
                }

                sqlget.Append("order by a.id desc "); 
                   
                con.sqlDataAdapterFillDatatable(sqlget.ToString(), ref dt);
                gc_data.DataSource = dt;

                //get station
                string sql_cbm = "select distinct tool_station from smt_m_tool_master smtm ";
                con.getComboBoxData(sql_cbm, ref cbm_station);
                //string sql_model = "select distinct (model_cd) from smt_m_model order by model_cd ";
                //con.getComboBoxData(sql_model, ref cbm_model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            txt_barcode.Text = "";
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
            if (txt_barcode.Text.Length < 5 || cbm_station.Text == "" || cbm_status.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Mã Lỗi: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (exitsBarcode(txt_barcode.Text) == 0)
            {
                MessageBox.Show("Barcode này chưa được đăng ký ở master cho model này", "Mã Lỗi: 102", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (currentstatus() == "SMT_SDR_IN" && beforestatus(txt_barcode.Text) == "SMT_SDR_IN")
            {
                MessageBox.Show("Barcode đã được check In trước đó !", "Mã Lỗi: 103", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (currentstatus() == "SMT_SDR_IN" && beforestatus(txt_barcode.Text) != "SMT_CLR_OUT")
            {
                MessageBox.Show("Barcode Chưa được vệ sinh !", "Mã Lỗi: 104", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (currentstatus() == "SMT_SDR_OUT" && beforestatus(txt_barcode.Text) != "SMT_SDR_IN")
            {
                MessageBox.Show("Barcode Chưa được Check IN !", "Mã Lỗi: 105", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (currentstatus() == "SMT_SDR_IN" && beforestatus(txt_barcode.Text) != "SMT_CLR_OUT")
            //{
            //    MessageBox.Show("Lỗi 103: Barcode Chưa được vệ sinh !", "Mã Lỗi: 103", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //else if (currentstatus() == "SMT_SDR_OUT" && beforestatus(txt_barcode.Text) != "SMT_SDR_IN")
            //{
            //    MessageBox.Show("Barcode Chưa được Check IN !", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            return true;
        }
        int exitsBarcode(string barcode)
        {
            try
            {
                pgsqlconnection con = new pgsqlconnection();
                string sql = "select count(*)  from smt_m_tool_master where tool_cd  ='" + barcode + "'"; //updaed new version
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
                                    ( tool_cd , tool_station , tool_check , creator ,create_time )
                                    VALUES("
                                     );
                    sqlinsert.Append("'" + txt_barcode.Text + "',");
                    sqlinsert.Append("'" + cbm_station.Text + "',");
                    sqlinsert.Append("'" + cbm_status.Text + "',");
                    sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteNonQuery_auto(sqlinsert.ToString());
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