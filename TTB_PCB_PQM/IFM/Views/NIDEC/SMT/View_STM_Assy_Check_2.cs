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
using IFM.Common.OnGrid;
using System.Runtime.InteropServices;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Assy_Check_2 : RibbonForm
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
        //string linkexport = @"\\192.168.193.1\fptin\SMT\PQM_SPI";
         string linkexport = @"C:\PQM";
        string pqmformat = @"C:\PQM\pqmformat.txt";

     
        public View_STM_Assy_Check_2()
        {
            InitializeComponent();
            AcceptButton = btn_enter;
            dtp_from.Value = DateTime.Now.AddDays(-2);
            dtp_to.Value = DateTime.Now.AddDays(+1);
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
                readPQMformat(pqmformat);
                dt = new DataTable();
                pgsqlconnection con = new pgsqlconnection();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"select id as ID, assy_code, model_cd  ,creator, create_time,pcb_code  from smt_m_assy_code                           
                            where 1=1 ");
                if (cbm_modelcd.Text != "")
                {
                    sql.Append(" and model_cd ='" + cbm_modelcd.Text + @"' ");
                }
                if (txt_pcbbarcode.Text != "")
                {
                    sql.Append(" and pcb_code ='" + txt_pcbbarcode.Text + @"' ");
                }
                sql.Append("  order by pcb_code, id desc limit 200");
                con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                gc_data.DataSource = dt;
                if (cbm_modelcd.Text != "" && txt_pcbbarcode.Text != "")
                {
                    txt_counter.Text = gv_data.RowCount.ToString();
                }
                else
                {
                    txt_counter.Text = "0";
                }

                string sql_model = "select distinct (model_cd) from smt_m_model order by model_cd ";
                con.getComboBoxData(sql_model, ref cbm_modelcd);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            txt_pcbbarcode.Text = "";
        }
        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                dt = new DataTable();
                pgsqlconnection con = new pgsqlconnection();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"select id as ID, assy_code, model_cd  ,creator, create_time,pcb_code  from smt_m_assy_code                           
                            where 1=1 ");
                if (cbm_modelcd.Text != "")
                {
                    sql.Append(" and model_cd ='" + cbm_modelcd.Text + @"' ");
                }
                if (txt_pcbbarcode.Text != "")
                {
                    sql.Append(" and pcb_code ='" + txt_pcbbarcode.Text + @"' ");
                }
                sql.Append(" and create_time >= '" + dtp_from.Value + "' ");
                sql.Append(" and create_time <= '" + dtp_to.Value + "' ");
                sql.Append("  order by pcb_code, id desc limit 200");
                con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                gc_data.DataSource = dt;
                if (cbm_modelcd.Text != "" && txt_pcbbarcode.Text != "")
                {
                    txt_counter.Text = gv_data.RowCount.ToString();
                }
                else
                {
                    txt_counter.Text = "0";
                }

                string sql_model = "select distinct (model_cd) from smt_m_model order by model_cd ";
                con.getComboBoxData(sql_model, ref cbm_modelcd);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                
                string id_ = gv_data.GetRowCellValue(gv_data.FocusedRowHandle, "id").ToString();
                string sqldelete = "delete from smt_m_assy_code where 1=1  and ID = '" + id_ + "'";
                pgsqlconnection con = new pgsqlconnection();
                con.sqlExecuteNonQuery(sqldelete);
                OnLoad(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message.ToString(), "Lỗi 01", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            OnLoad(e);
        }
        

        bool checkcondition()
        {
            if (txt_barcode.Text.Length < 7 || txt_pcbbarcode.Text.Length < 5 || cbm_modelcd.Text == "")
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Mã Lỗi: 101", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txt_barcode.Text.Substring(5, 1) != "J")
            {
                MessageBox.Show("Barcode của Housing không đúng với định dạng", "Mã Lỗi: 106", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            pgsqlconnection con = new pgsqlconnection();
            string maxpcbsub = "select model_columns* model_rows  as total from smt_m_model  where model_cd = '" + cbm_modelcd.Text + @"' limit 1";
            if (gv_data.RowCount >= int.Parse(con.sqlExecuteScalarString(maxpcbsub)))
            {
                MessageBox.Show("Barcode PCB Con  Đang lớn hơn Số Master layout Quy Định", "Mã Lỗi: 104", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_pcbbarcode.Text = "";
                txt_pcbbarcode.Focus();
                return false;
            }

            // cbm_modelcd.Text + DateTime.Now.AddMonths(-1).ToString("yyyyMMdd")
            string result_ = result(cbm_modelcd.Text + DateTime.Now.ToString("yyyyMM"));
            if (result_ == "")
                result_ = result(cbm_modelcd.Text + DateTime.Now.AddMonths(-1).ToString("yyyyMM"));
            if (result_ == "")
            {
                MessageBox.Show("Barcode PCB Không Có Thông Tin Tại Công Đoạn Cắt", "Mã Lỗi: 102", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (result_ == "1")
            {
                MessageBox.Show("Barcode PCB Bị NG ở Công Đoạn Cắt", "Mã Lỗi: 103", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(sernodualicate()) > 0)
            {
                MessageBox.Show("Barcode Housing Đã Được Test Trước Đó", "Mã Lỗi: 105", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (result_ == "0")
            {
                //return ok, exit condition
                return true;
            }
            return true;
        }
        string sernodualicate()
        {
            string result_ = "1";
            try
            {
                pgsqlconnection con = new pgsqlconnection();
                string sql = "select count(*) from smt_m_assy_code where 1=1 and assy_code = '" + txt_barcode.Text + "'";
                result_ = con.sqlExecuteScalarString_Autosystem(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            return result_;

        }
        string result(string table)
        {
            string result_ = "";
            try
            {
                string sql = @"select judge  from " + table + @"data where 
                            inspectdate =
                            (
                            select max(inspectdate) from " + table + @"data   
                            where 1 = 1
                            and serno = '" + txt_pcbbarcode.Text + @"'
                            and inspect = 'SMTCUT'
                            )
                            and serno = '" + txt_pcbbarcode.Text + @"'
                            and inspect = 'SMTCUT'";
                pgsqlconnection_NewDB con = new pgsqlconnection_NewDB();
                result_ = con.sqlExecuteScalarString_Autosystem(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            return result_;
        }
        private void btn_enter_Click(object sender, EventArgs e)
        {
            OnLoad(e);
            if (checkcondition())
            {
                try
                {
                    pgsqlconnection con = new pgsqlconnection();
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO smt_m_assy_code
                                    ( assy_code ,pcb_code, model_cd , creator ,create_time )
                                    VALUES("
                                     );
                    sqlinsert.Append("'" + txt_barcode.Text + "',");
                    sqlinsert.Append("'" + txt_pcbbarcode.Text + "',");
                    sqlinsert.Append("'" + cbm_modelcd.Text + "',");
                    sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteNonQuery_auto(sqlinsert.ToString());
                     exportfile(true);
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
             writePQMformat(txt_exportlink.Text + "\\housingassy" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");
        }
       

      
    }
}