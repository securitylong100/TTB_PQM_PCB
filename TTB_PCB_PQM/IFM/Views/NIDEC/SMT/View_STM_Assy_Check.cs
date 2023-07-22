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
using System.IO;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Assy_Check : RibbonForm
    {
        DataTable dt;
        string barcode; //serno
        string lot;
        string modelPQM;
        string sitePQM;
        string factoryPQM;
        string line;
        string processPQM;
        string inspect;
        string date;
        string time;
        string data;
        string judge;
        string status;
        string remark;
        // string linkexport = @"\\193.168.193.1\fptin\SMT\PQM_SPI";
        string linkexport = @"C:\PQM";
        string pqmformat = @"C:\PQM\pqmformat.txt";
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
            try
            {

                dt = new DataTable();
                pgsqlconnection con = new pgsqlconnection();
                string sql = @"select id, assy_code, model_cd  ,creator, create_time  from smt_m_assy_code                            
                            where create_time <= '" + dtp_to.Value + @"'
                            and create_time >='" + dtp_from.Value + @"'                          
                            order by id desc limit 100";
                con.sqlDataAdapterFillDatatable(sql, ref dt);
                gc_data.DataSource = dt;
                string sql_model = "select distinct (model_cd) from smt_m_model order by model_cd ";
                con.getComboBoxData(sql_model, ref cbm_modelcd);
                txt_exportlink.Text = linkexport;
                readPQMformat(pqmformat);
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
            if (txt_barcode.Text.Length < 5 || cbm_modelcd.Text == "")
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
                    pgsqlconnection con = new pgsqlconnection();
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO smt_m_assy_code
                                    ( assy_code , model_cd , creator ,create_time )
                                    VALUES("
                                     );
                    sqlinsert.Append("'" + txt_barcode.Text + "',");
                    sqlinsert.Append("'" + cbm_modelcd.Text + "',");
                    sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteNonQuery_auto(sqlinsert.ToString());
                   // exportfile(true);
                }
                catch (Exception ex)
                {                
                    MessageBox.Show("Lỗi kết nối" + ex.Message.ToString(), "Lỗi 01", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txt_barcode.Text = "";
            OnLoad(e);
        }
        private void writePQMformat(string filePQM)
        {
            try
            {
                //  writePQMformat(pathfolderout + "\\SPI_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");
                //bool exists = System.IO.File.Exists(filePQMformat);
                ////if (exists)
                ////    System.IO.File.Delete(filePQMformat);

                StringBuilder sb = new StringBuilder();
                sb.Append(@"""" + barcode + @"""" + ",");
                sb.Append(@"""" + lot + @"""" + ",");
                sb.Append(@"""" + modelPQM + @"""" + ",");
                sb.Append(sitePQM + ",");
                sb.Append(factoryPQM + ",");
                sb.Append(line + ",");
                sb.Append(processPQM + ",");
                sb.Append(inspect + ",");
                sb.Append(@"""" + date + @"""" + ",");
                sb.Append(@"""" + time + @"""" + ",");
                sb.Append(@"""" + data + @"""" + ",");
                sb.Append(@"""" + judge + @"""" + ",");
                sb.Append(status + ",");
                sb.Append(remark);
                sb.Append("\n");
                File.AppendAllText(filePQM, sb.ToString());
                sb.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file" + ex.Message.ToString(), "Lỗi 02", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void readPQMformat(string filePQMformat)
        {
            try
            {
                bool exists = System.IO.File.Exists(filePQMformat);
                if (!exists) return;
                string[] datarow = File.ReadAllLines(filePQMformat);
                sitePQM = datarow[3];
                factoryPQM = datarow[4];
                line = datarow[5];
                processPQM = datarow[6];
                inspect = datarow[7];
                status = datarow[12];
                remark = datarow[13];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file" + ex.Message.ToString(), "Lỗi 02", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void exportfile(bool statusPQM)
        {
            modelPQM = cbm_modelcd.Text;
            barcode = txt_barcode.Text;
            lot = "_" + DateTime.Now.ToString("yyyyMMdd");
            date = DateTime.Now.ToString("yyyy/MM/dd");
            time = DateTime.Now.ToString("HH:mm:ss");
            judge = statusPQM == true ? "1" : "0";
            data = judge;
            writePQMformat(txt_exportlink.Text + "\\Assy" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");
        }
    }
}