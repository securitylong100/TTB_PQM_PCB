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
    public partial class View_STM_Assy_Viewer : RibbonForm
    {
        DataTable dt;
        DataTable dt2;
        DateTimePicker dtp_to;
        public View_STM_Assy_Viewer()
        {
            InitializeComponent();           
            dtp_from.Value = DateTime.Now.AddDays(-0).Date;          
            AcceptButton = btn_enter;
        }

        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }
        void BbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_barcodepcb.ShowRibbonPrintPreview();
            gc_barcodeassy.ShowRibbonPrintPreview();
        }
        protected override void OnLoad(EventArgs e)
        {
           // getassylist();
           // getlistpcb();
        }
        void getassylist()
        {
              try
            {
                dtp_to = new DateTimePicker();
                dtp_to.Value = dtp_from.Value.AddDays(+1).Date;
                dt = new DataTable();
                pgsqlconnection con = new pgsqlconnection();
                StringBuilder sqlgetassy = new StringBuilder();
                sqlgetassy.Append(@"select id, assy_code, model_cd  ,creator, create_time  from smt_m_assy_code                            
                            where create_time <= '" + dtp_to.Value + @"'
                            and create_time >='" + dtp_from.Value + @"'                          
                            ");
                if (txt_barcode.Text != "")
                {
                    sqlgetassy.Append(" and assy_code = '" + txt_barcode.Text + "' ");
                }
                sqlgetassy.Append("  order by id desc");
                con.sqlDataAdapterFillDatatable(sqlgetassy.ToString(), ref dt);
                gc_barcodeassy.DataSource = dt;
                string sql_model = "select distinct (model_cd) from smt_m_model order by model_cd ";
                con.getComboBoxData(sql_model, ref cbm_modelcd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
}
        void getlistpcb()
        {
            try
            {
                dtp_to = new DateTimePicker();
                dtp_to.Value = dtp_from.Value.AddDays(+1).Date;
                dt2 = new DataTable();
              
                string sqlgetpcblist = @"SELECT * from (
                 select l.site , l.factory, l.model, l.serno, l.process, sum(CAST(ld.judge AS INTEGER)) as result  ,max(ld.inspectdate) as inspectdate
                  from " + cbm_modelcd.Text + dtp_from.Value.ToString("yyyyMM") + @" l
                   left
                   join " + cbm_modelcd.Text + dtp_from.Value.ToString("yyyyMM") + "data" + @" ld
                   on l.serno = ld.serno
                   where 1 = 1
                   and l.inspectdate = ld.inspectdate
                   group by l.site , l.factory ,l.serno ,l.process , l.inspectdate, l.model
                 ) a
                          where inspectdate in 
                		 (
                                  select b.date_ from
                                  (
                                             select lot, serno, max(inspectdate) as date_, inspect from  " + cbm_modelcd.Text + dtp_from.Value.ToString("yyyyMM") + "data" + @" ld
                                             where 1 = 1
                                             and lot = '" + "_" + dtp_from.Value.ToString("yyyyMMdd") + @"'
                                             group by inspect,serno,lot
                                            order by serno
                				 ) b
                		 )";
                pgsqlconnection_NewDB con = new pgsqlconnection_NewDB();
                con.sqlDataAdapterFillDatatable(sqlgetpcblist, ref dt2);
                gc_barcodepcb.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {

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

        }

        bool checkcondition()
        {
            if ( cbm_modelcd.Text == "")
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Mã Lỗi: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btn_enter_Click(object sender, EventArgs e)
        {
            if (checkcondition())
            {
                try
                {
                    getassylist();
                    getlistpcb();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }
            }
            
        }
        private void gv_barcodepcb_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(gv_barcodepcb.GetRowCellValue(e.RowHandle, "result"));
                //int result = ok_ng;
                if (result > 0 && gv_barcodepcb.RowCount > 0)
                {
                    e.Appearance.BackColor = Color.Red;

                    //if đỏ bên này thì cho NG hết
                }
                else
                {
                    e.Appearance.BackColor = Color.LightGreen;

                    // if xanh bên này thì cho OK hết
                }

                e.HighPriority = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

    }
}