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
using System.Linq;
using System.Collections.Generic;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Mounter_History_2 : RibbonForm
    {
        DataTable dt;
        DataTable dt2;
        List<object> lstItems;
        public View_STM_Mounter_History_2()
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
            gc_datamaster.ShowRibbonPrintPreview();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                getmasterlist();
                pgsqlconnection con = new pgsqlconnection();
                string sql_cbm = "select distinct model_cd from smt_m_model order by model_cd ";
                con.getComboBoxData(sql_cbm, ref cbm_modelcd);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            txt_barcode.Text = "";
        }
        void getmasterlist()
        {
            try
            {
                dt = new DataTable();
                pgsqlconnection con = new pgsqlconnection();
                StringBuilder sqlget = new StringBuilder();
                sqlget.Append(@"select id,  model_cd , item_list, create_time  from smt_m_mounter_items 
                             where 1=1 ");
                if (cbm_modelcd.Text != "")
                {
                    sqlget.Append("and model_cd = '" + cbm_modelcd.Text + @"' ");
                }
                sqlget.Append("order by  item_list ");
                con.sqlDataAdapterFillDatatable(sqlget.ToString(), ref dt);
                gc_datamaster.DataSource = dt;
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
            dt2 = new DataTable();
            gc_datahistory.DataSource = dt2;
            loadlotno();
        }
        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            getmasterlist();
        }

        bool checkcondition()
        {
            if (txt_barcode.Text.Length < 5 || cbm_modelcd.Text == "" || cbm_modelcd.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin!", "Mã Lỗi: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //kiểm tra xem có trong master ko
            bool checkmaster = false;
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show(" Thông Tin List Linh Kiện Master Đang Trống!", "Mã Lỗi: 102", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                var x = (from r in dt.AsEnumerable()
                         select r["item_list"]).Distinct().ToList();
                foreach (var x1 in x)
                {
                    if (txt_barcode.Text == x1.ToString())
                    {
                        checkmaster = true;
                    }
                }
                if (checkmaster == false)
                {
                    MessageBox.Show(" Linh kiện này không có trong Master!", "Mã Lỗi: 103", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            //kiểm tra có bị trùng 2 rows ko
            pgsqlconnection con = new pgsqlconnection();
            string sql = "select count(*)  from smt_m_mounter_history where model_cd  ='" + cbm_modelcd.Text + "' and lot_no  ='" + txt_lotno.Text + "' and item_list  ='" + txt_barcode.Text + "'";
            if (int.Parse(con.sqlExecuteScalarString(sql)) != 0)
            {
                MessageBox.Show(" Linh kiện Này Đã Được Thêm Vào Trước Đó!", "Mã Lỗi: 104", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            insertdata();
            gethistorylist();
            if (gv_datahistory.RowCount == gv_datamaster.RowCount)
            {
                MessageBox.Show(" Kết Quả So Sánh Đã Đúng", "Thông Báo Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt2 = new DataTable();
                gc_datahistory.DataSource = dt2;
                loadlotno();
            }
            getmasterlist();
            txt_barcode.Text = "";
        }
        void gethistorylist()
        {
            dt2 = new DataTable();
            pgsqlconnection con = new pgsqlconnection();
            StringBuilder sqlgethistorylist = new StringBuilder();
            sqlgethistorylist.Append(@"select * from smt_m_mounter_history where lot_no ='" + (int.Parse(txt_lotno.Text) - 0) + "' and model_cd ='" + cbm_modelcd.Text + "'");
            con.sqlDataAdapterFillDatatable(sqlgethistorylist.ToString(), ref dt2);
            gc_datahistory.DataSource = dt2;
            var x = (from r in dt2.AsEnumerable()
                     select r["item_list"]).Distinct().ToList();
            lstItems = x.ToList();

        }
        void insertdata()
        {
            if (checkcondition())
            {
                try
                {
                    pgsqlconnection con = new pgsqlconnection();
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO smt_m_mounter_history
                                    ( lot_no , model_cd , item_list , creator ,create_time )
                                    VALUES("
                                     );
                    sqlinsert.Append("'" + txt_lotno.Text + "',");
                    sqlinsert.Append("'" + cbm_modelcd.Text + "',");
                    sqlinsert.Append("'" + txt_barcode.Text + "',");
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
        }

        private void gv_datamaster_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                if (lstItems == null) return;
                foreach (string item_ in lstItems.ToArray())
                {      
                    string result = Convert.ToString(gv_datamaster.GetRowCellValue(e.RowHandle, "item_list"));
                    if (item_ == result && gv_datamaster.RowCount>0 && gv_datahistory.RowCount>0)
                    {
                        e.Appearance.BackColor = Color.Green;
                    }
                    else if(gv_datahistory.RowCount < 1)
                    {
                        e.Appearance.BackColor = Color.White;
                    }    
                }

                e.HighPriority = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void cbm_modelcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadlotno();
            getmasterlist();
        }
        void loadlotno()
        {
            pgsqlconnection con = new pgsqlconnection();
            string sql_model = "select coalesce(max(lot_no) + 1, 1) from smt_m_mounter_history where 1=1 and model_cd = '" + cbm_modelcd.Text + "' ";
            txt_lotno.Text = con.sqlExecuteScalarString(sql_model);
        }

        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            dt2 = new DataTable();
            pgsqlconnection con = new pgsqlconnection();
            StringBuilder sqlgethistorylist = new StringBuilder();
            sqlgethistorylist.Append(@"select * from smt_m_mounter_history where 1=1 ");
            if(cbm_modelcd.Text !="")
            {
                sqlgethistorylist.Append(@" and model_cd ="+cbm_modelcd.Text+"");
            }
            if (txt_barcode.Text != "")
            {
                sqlgethistorylist.Append(@" and item_list =" + txt_barcode.Text + "");
            }
           else
            {
                sqlgethistorylist.Append(" and create_time >= '" + dtp_from.Value + "' ");
                sqlgethistorylist.Append(" and create_time <= '" + dtp_to.Value + "' ");
            }
            sqlgethistorylist.Append(@" order by model_cd, item_list");
            con.sqlDataAdapterFillDatatable(sqlgethistorylist.ToString(), ref dt2);
            gc_datahistory.DataSource = dt2;
        }
    }
}