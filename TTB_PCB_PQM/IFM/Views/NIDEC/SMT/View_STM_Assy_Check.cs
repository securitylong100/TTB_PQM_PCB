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
    public partial class View_STM_Assy_Check : RibbonForm
    {
        DataTable dt;
       
        public View_STM_Assy_Check()
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

        private void btn_enter_Click(object sender, EventArgs e)
        {
        }
    }
}