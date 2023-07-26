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
    public partial class View_STM_Mounter_History : RibbonForm
    {
        DataTable dt;
        List<object> lstItems;
        public View_STM_Mounter_History()
        {
            InitializeComponent();
            dtp_from.Value = DateTime.Now.AddDays(-2);
            dtp_to.Value = DateTime.Now.AddDays(+1);
            AcceptButton = btn_enter;
            cbm_typeview.Text = "History";


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
                sqlget.Append(@"select id, lot_no, model_cd , item_list,creator, create_time  from smt_m_mounter_history 
                             where create_time <= '" + dtp_to.Value + @"'
                            and create_time >='" + dtp_from.Value + @"' ");
                if (cbm_modelcd.Text != "")
                {
                    sqlget.Append("and model_cd = '" + cbm_modelcd.Text + @"' ");
                }
                sqlget.Append("order by id desc ");
                con.sqlDataAdapterFillDatatable(sqlget.ToString(), ref dt);
                gc_data.DataSource = dt;

                //get station
                string sql_cbm = "select distinct model_cd from smt_m_model order by model_cd ";
                con.getComboBoxData(sql_cbm, ref cbm_modelcd);

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

        bool checkcondition()
        {
            if (txt_barcode.Text.Length < 5 || cbm_modelcd.Text == "" || cbm_modelcd.SelectedItem == null || cbm_typeview.Text == "Check Code")
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Mã Lỗi: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            addgridcontroll(txt_barcode.Text);
            insertdata();
        }
        void addgridcontroll(string itemnew)
        {
            if (dt.Rows.Count < 1) return;
            var list = (from r in dt.AsEnumerable()
                     select r["item_list"]).Distinct().ToList(); if (dt.Rows.Count < 1) return;
       
        }
        private void gv_data_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(gv_data.GetRowCellValue(e.RowHandle, "result_"));

                if (result > 0)
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else if (result == 0)
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
                e.HighPriority = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
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
        private void cbm_modelcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddatafrom();

        }
        void loaddatafrom()
        {
            pgsqlconnection con = new pgsqlconnection();
            string sql_model = "select coalesce(max(lot_no) + 1, 1) from smt_m_mounter_history where 1=1 and model_cd = '" + cbm_modelcd.Text + "' ";
            txt_lotno.Text = con.sqlExecuteScalarString(sql_model);
            dt = new DataTable();
            string sqlgetmasterlist = @"select a.model_cd, a.item_list,b.lot_no from smt_m_mounter_items a
                                        left join 
                                        (
                                        select coalesce(max(lot_no) + 1, 1) as lot_no, model_cd  from smt_m_mounter_history 
                                        where 1=1 
                                        group by model_cd 
                                        ) b
                                        on a.model_cd  = b.model_cd
                                        where a.model_cd ='" + cbm_modelcd.Text + "'";
            con.sqlDataAdapterFillDatatable(sqlgetmasterlist, ref dt);
            gc_data.DataSource = dt;
        }
        private void cbm_typeview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbm_typeview.Text == "Check Code")
            {
                cbm_typeview.BackColor = Color.Green;
            }
            else
            {
                cbm_typeview.BackColor = Color.White;
            }
            loaddatafrom();
        }
    }
}