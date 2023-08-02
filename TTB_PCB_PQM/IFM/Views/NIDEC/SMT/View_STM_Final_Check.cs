using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Threading;
using System.IO;
using IFM.Common;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Final_Check : RibbonForm
    {
        DataTable dt;
        string model_;
        string datetimeCur_;
        string datetimePrevious_;
        string barcode_;
        bool layout = true;
        int ok_ng = 0;
        //list convert data
        bool statusPQM;
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
     
         string linkexport = @"\\192.168.193.1\ftpin\SMT\PQM_SPI";
        //string linkexport = @"C:\PQM";
        string pqmformat = @"C:\PQM\pqmformat.txt";
        TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();

        public View_STM_Final_Check()
        {
            InitializeComponent();
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
                txt_exportlink.Text = linkexport;
                readPQMformat(pqmformat);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void getsizelayout()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void createdynamiclayout()
        {
            try
            {
                dynamicTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                dynamicTableLayoutPanel.BackColor = Color.White;
                dynamicTableLayoutPanel.Location = new System.Drawing.Point(603, 6);
                dynamicTableLayoutPanel.Name = "TableLayoutPanel1";
                dynamicTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                dynamicTableLayoutPanel.Size = new System.Drawing.Size(189, 138);
                dynamicTableLayoutPanel.TabIndex = 0;
                dynamicTableLayoutPanel.ColumnCount = int.Parse(nm_column.Value.ToString());
                dynamicTableLayoutPanel.RowCount = int.Parse(nm_row.Value.ToString());
                for (int i = 0; i < int.Parse(nm_row.Value.ToString()); i++)
                {
                    dynamicTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                }
                int k = 0;
                for (int i = 0; i < int.Parse(nm_column.Value.ToString()); i++)
                {
                    dynamicTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                    for (int j = 0; j < int.Parse(nm_row.Value.ToString()); j++)
                    {
                        dynamicTableLayoutPanel.Controls.Add(buttonlayout("btn_layout" + k.ToString()), i, j);
                        k = k + 1;
                    }
                }
                tlp_showdata.Controls.Add(dynamicTableLayoutPanel, 1, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            layout = false;
        }
        // void createDymanicButton(string name)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result">cái này là giá trị ban đầu (nếu có load từ db)</param>
        /// <returns></returns>
        public System.Windows.Forms.Button buttonlayout(string name, string result = "NA")
        {
            System.Windows.Forms.Button btn_layout = new System.Windows.Forms.Button();
            btn_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            btn_layout.Location = new System.Drawing.Point(3, 3);
            btn_layout.Name = name.ToString();
            btn_layout.Size = new System.Drawing.Size(45, 45);
            btn_layout.TabIndex = 0;
            btn_layout.Text = result;
            btn_layout.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_layout.Image = global::IFM.Properties.Resources.Waiting;
            btn_layout.UseVisualStyleBackColor = true;
            btn_layout.Click += new System.EventHandler(btn_layout_Click);
            return btn_layout;
        }
        private void btn_layout_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button btn_layout = sender as System.Windows.Forms.Button;
                if (btn_layout.Text == "NG")
                {
                    btn_layout.Image = global::IFM.Properties.Resources.OK;
                    btn_layout.Text = "OK";
                }
                else
                {
                    btn_layout.Image = global::IFM.Properties.Resources.NG;
                    btn_layout.Text = "NG";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void cbm_modelcd_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            savedataonlayout();
        }
        void savedataonlayout()
        {
            statusPQM = false;
            try
            {
                List<object> lstItems = new List<object>();
                foreach (var control in dynamicTableLayoutPanel.Controls)
                {
                    if (control is System.Windows.Forms.Button btn)
                    {
                        /// Cái này là nạp từng phàn tử của layout vào list để lưu theo tọa độ
                        //lstItems.Add(new
                        //{
                        //    Barcode = barcode_,
                        //    X = dynamicTableLayoutPanel.GetColumn(btn),
                        //    Y = dynamicTableLayoutPanel.GetRow(btn),
                        //    Result = btn.Text
                        //});
                        pgsqlconnection con = new pgsqlconnection();
                        StringBuilder sqlinsert = new StringBuilder();
                        sqlinsert.Append(@"INSERT INTO smt_m_app_history
                                    (barcode , x_layout , y_layout ,barcode_status, creator ,create_time )
                                    VALUES(");
                        sqlinsert.Append("'" + barcode_ + "',");
                        sqlinsert.Append("'" + dynamicTableLayoutPanel.GetColumn(btn) + "',");
                        sqlinsert.Append("'" + dynamicTableLayoutPanel.GetRow(btn) + "',");
                        sqlinsert.Append("'" + btn.Text + "',");
                        sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                        sqlinsert.Append("CURRENT_TIMESTAMP");
                        sqlinsert.Append(")");
                        con.sqlExecuteNonQuery_auto(sqlinsert.ToString());
                        if (btn.Text == "NG") statusPQM = true;
                    }
                }
                modelPQM = cbm_modelcd.Text;
                barcode = barcode_;
                lot = "_" + DateTime.Now.ToString("yyyyMMdd");
                date = DateTime.Now.ToString("yyyy/MM/dd");
                time = DateTime.Now.ToString("HH:mm:ss");
                judge = statusPQM == true ? "1" : "0";
                data = judge;
                writePQMformat(txt_exportlink.Text + "\\Final" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");
                MessageBox.Show("Save successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cbm_modelcd.Text != "" && layout == true)
            {
                getsizelayout();
                createdynamiclayout();
            }

        }
        private void btn_enter_Click(object sender, EventArgs e)
        {
            try
            {
                ok_ng = 0;
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
                    barcode_ = txt_barcode.Text;
                    txt_barcode.Text = "";
                    if (gv_data.RowCount > 0)
                    {
                        gv_data.Columns["result_"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        ok_ng = int.Parse(gv_data.Columns["result_"].SummaryItem.SummaryValue.ToString());
                    }
                    else
                    {
                        ok_ng = 0;
                    }

                    if (ok_ng == 0 && gv_data.RowCount < 1)
                    {
                        pictureBox1.Image = global::IFM.Properties.Resources.NG_LB;
                        rd_NG_CheckedChanged(sender, e);
                        IFM.Common.function soundAL = new function();
                        soundAL.soundAlarm();
                        MessageBox.Show("Sản Phẩm Barcode không tồn tại", "Lỗi 02", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
                    }
                    else if (ok_ng >= 1 && gv_data.RowCount >= 2)
                    {
                        pictureBox1.Image = global::IFM.Properties.Resources.NG_LB;
                        rd_NG_CheckedChanged(sender, e);
                        IFM.Common.function soundAL = new function();
                        soundAL.soundAlarm();
                        MessageBox.Show("Sản Phẩm có 1 công đoạn trước đó NG", "Lỗi 03", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
                    }

                    else if (gv_data.RowCount == 1)
                    {
                        pictureBox1.Image = global::IFM.Properties.Resources.NG_LB;
                        rd_NG_CheckedChanged(sender, e);
                        IFM.Common.function soundAL = new function();
                        soundAL.soundAlarm();
                        MessageBox.Show("Sản Phẩm có 1 công đoạn trước đó chưa được test", "Lỗi 04", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
                    }
                    else if (ok_ng == 0 && gv_data.RowCount >= 2)
                    {
                        rd_ok_CheckedChanged(sender, e);
                        pictureBox1.Image = global::IFM.Properties.Resources.OK_LB;
                        System.Media.SystemSounds.Hand.Play();
                        savedataonlayout();
                        Timer_colorchange.Enabled = true;

                    }
                    else
                    {
                        pictureBox1.Image = global::IFM.Properties.Resources.NG_LB;
                        rd_NG_CheckedChanged(sender, e);
                        IFM.Common.function soundAL = new function();
                        soundAL.soundAlarm();
                        MessageBox.Show("Chưa xác nhận lỗi", "Lỗi 99", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            //  
        }
        private void Timer_colorchange_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
            Timer_colorchange.Enabled = false;
        }
        void getPQM(string table)
        {
            try
            {
                dt = new DataTable();

                //string sqlgetPQM = @"select a.site ,a.factory ,a.serno ,a.process , max(a.result) as result,max(a.inspectdate) as inspectdate  from 
                //                    (
                //                    select l.site , l.factory ,l.serno, l.process, sum(CAST(ld.judge AS INTEGER)) as result  ,max(ld.inspectdate) as inspectdate  from " + table + @" l 
                //                    left join " + table + @"data ld 
                //                    on l.serno  = ld.serno 
                //                    where 1=1
                //                    and l.inspectdate  = ld.inspectdate 
                //                    and l.serno = '" + txt_barcode.Text + @"'
                //                    group  by l.site , l.factory ,l.serno ,l.process , l.inspectdate
                //                    )a 
                //                    group  by a.site ,a.factory ,a.serno ,a.process order by max(a.result) asc";
                string sqlgetPQM = @" select a.site as site , a.factory as factory,a.model as model,a.serno as serno, a.process as process, a.result as result_, a.inspectdate as inspectdate from (
                                 select l.site , l.factory,l.model,l.serno, l.process, sum(CAST(ld.judge AS INTEGER)) as result  ,max(ld.inspectdate) as inspectdate  from " + table + @" l 
                                 left join " + table + @"data ld 
                                on l.serno  = ld.serno 
                                 where 1=1
                                and l.inspectdate  = ld.inspectdate 
                                 and l.serno = '" + txt_barcode.Text + @"'
                                 group  by l.site , l.factory ,l.serno ,l.process , l.inspectdate,l.model
                                 ) a where a.inspectdate in 
                                 (
                                 select b.date_  from 
                                 (
                                 select max(inspectdate) as date_, inspect  from  " + table + @"data ld 
                                where ld.serno = '" + txt_barcode.Text + @"'
                                group  by inspect ) b
                                ) order by a.inspectdate , a.result";
                pgsqlconnection_NewDB conPQM = new pgsqlconnection_NewDB();
                conPQM.sqlDataAdapterFillDatatableAuto(sqlgetPQM, ref dt);
                gc_data.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        bool checkcondition()
        {
            if (txt_barcode.Text.Length < 5 || cbm_modelcd.Text == "")
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Lỗi 01", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void gv_data_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                int result = Convert.ToInt32(gv_data.GetRowCellValue(e.RowHandle, "result_"));
                //int result = ok_ng;
                if (result > 0 && gv_data.RowCount > 0)
                {
                    e.Appearance.BackColor = Color.Red;

                    //if đỏ bên này thì cho NG hết
                }
                else if (result == 0 && gv_data.RowCount > 0)
                {
                    e.Appearance.BackColor = Color.LightGreen;

                    // if xanh bên này thì cho OK hết
                }
                else
                {
                    // e.Appearance.BackColor = Color.White;
                    foreach (var control in dynamicTableLayoutPanel.Controls)
                    {
                        if (control is System.Windows.Forms.Button btn)
                        {
                            btn.Image = global::IFM.Properties.Resources.Waiting;
                            btn.Text = "NA";
                        }
                    }
                }
                e.HighPriority = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void rd_ok_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var control in dynamicTableLayoutPanel.Controls)
                {
                    if (control is System.Windows.Forms.Button btn)
                    {
                        btn.Image = global::IFM.Properties.Resources.OK;
                        btn.Text = "OK";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }

        private void rd_NG_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var control in dynamicTableLayoutPanel.Controls)
                {
                    if (control is System.Windows.Forms.Button btn)
                    {
                        btn.Image = global::IFM.Properties.Resources.NG;
                        btn.Text = "NG";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
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
                MessageBox.Show("Lỗi xuất file" + ex.Message.ToString(), "Lỗi 05", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Lỗi xuất file" + ex.Message.ToString(), "Lỗi 06", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}