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
using System.Linq;
using System.IO.Ports;
using System.Threading;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Cutting : RibbonForm
    {
        DataTable dt;
        string model_;
        string datetimeCur_;
        string datetimePrevious_;
        string barcode_;
        bool cutting = false;
        bool layout = true;
        int timer_ = 0;
        TableLayoutPanel dynamicTableLayoutPanel = new TableLayoutPanel();

        public View_STM_Cutting()
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
                cmbSeriport.DataSource = SerialPort.GetPortNames();
                chk_cut.Checked = true;
                 timer_ = int.Parse(nud_timerdelay.Value.ToString());
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
                        dynamicTableLayoutPanel.Controls.Add(buttonlayout("btn_layout" + k.ToString(), "NA"), i, j);
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
        public System.Windows.Forms.Button buttonlayout(string name, string result)
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
            //  btn_layout.Click += new System.EventHandler(btn_layout_Click);
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
                if (checkcondition())
                {
                     timer_ = int.Parse(nud_timerdelay.Value.ToString());
                    model_ = cbm_modelcd.Text;
                    datetimeCur_ = DateTime.Now.ToString("yyyyMM");
                    datetimePrevious_ = DateTime.Now.AddMonths(-1).ToString("yyyyMM");
                    getPQM(model_ + datetimeCur_);
                    if (gv_data.RowCount < 1)
                    {
                        getPQM(model_ + datetimePrevious_);
                    }
                    barcode_ = txt_barcode.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
         
            if (cutting == true && gv_data.DataRowCount > 0)
            {
                pictureBox1.Image = global::IFM.Properties.Resources.OK_LB;
                timerdelay.Enabled = true;
                Thread.Sleep(500);
                System.Media.SystemSounds.Hand.Play();
            }
            else if (cutting == false && gv_data.DataRowCount > 0)
            {
                pictureBox1.Image = global::IFM.Properties.Resources.NG_LB;
                MessageBox.Show("Sản Phẩm có PCB bị NG", "Lỗi 03", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
            }    
            else 
            {
                pictureBox1.Image = global::IFM.Properties.Resources.NG_LB;
                MessageBox.Show("Sản Phẩm Barcode không tồn tại", "Lỗi 02", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
            }
            txt_barcode.Text = "";
        }
        void getPQM(string table)
        {
            cutting = true;
            try
            {
                dt = new DataTable();
               // gc_data.DataSource = null;
               // gv_data.Columns.Clear();
                string sqlgetPQM = @" select  a.site as site , a.factory as factory,a.serno as serno, a.process as process, a.result as result_, a.inspectdate as inspectdate  from (
                                     select l.site , l.factory ,l.serno, l.process, sum(CAST(ld.judge AS INTEGER)) as result  ,max(ld.inspectdate) as inspectdate  from " + table + @" l 
                                     left join " + table + @"data ld 
                                    on l.serno  = ld.serno 
                                     where 1=1
                                    and l.inspectdate  = ld.inspectdate 
                                     and l.serno = '" + txt_barcode.Text + @"'
                                     group  by l.site , l.factory ,l.serno ,l.process , l.inspectdate
                                     ) a where a.inspectdate in 
                                     (
                                     select b.date_  from 
                                     (
                                     select max(inspectdate) as date_, inspect  from  " + table + @"data ld 
                                    where ld.serno = '" + txt_barcode.Text + @"'
                                    group  by inspect ) b
                                    ) order by a.result asc";
                pgsqlconnection_NewDB conPQM = new pgsqlconnection_NewDB();
                conPQM.sqlDataAdapterFillDatatableAuto(sqlgetPQM, ref dt);
                gc_data.DataSource = dt;

                dt = new DataTable();
                string sqlget = @"select barcode, x_layout ,y_layout ,barcode_status from smt_m_app_history  where 1 = 1
                            and create_time >=
                            (
                            select max(create_time) from smt_m_app_history 
                            where 1 = 1
                            and x_layout = 0
                            and y_layout = 0
                            and barcode = '" + txt_barcode.Text + @"'
                             ) order by x_layout ,y_layout";
                pgsqlconnection con = new pgsqlconnection();
                con.sqlDataAdapterFillDatatable(sqlget, ref dt);
                if (dt.Rows.Count < 1) return;
                var x = (from r in dt.AsEnumerable()
                         select r["barcode_status"]).ToList();
                int i = 0;
                foreach (var control in dynamicTableLayoutPanel.Controls)
                {
                    if (control is System.Windows.Forms.Button btn)
                    {
                        btn.Text = x[i].ToString();
                        if (x[i].ToString() == "OK")
                        {
                            btn.Image = global::IFM.Properties.Resources.OK;
                        }
                        else
                        {
                            btn.Image = global::IFM.Properties.Resources.NG;
                            cutting = false;
                        }
                        i = i + 1;
                    }
                }

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

                if (result > 0)
                {
                    e.Appearance.BackColor = Color.Red;

                    //if đỏ bên này thì cho NG hết
                }
                else if (result == 0)
                {
                    e.Appearance.BackColor = Color.LightGreen;


                    // if xanh bên này thì cho OK hết
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



        private void btn_serial_Click(object sender, EventArgs e)
        {
            if (!serialCom.IsOpen && btn_serial.Text == "Connect Serial")
            {
                serialCom.PortName = cmbSeriport.Text;
                serialCom.Open();
                btn_serial.Text = "Connected Serial";
                cmbSeriport.Enabled = false;
                btn_serial.BackColor = Color.Green;
              
            }
            else
            {
                serialCom.Close();
                btn_serial.Text = "Connect Serial";
                cmbSeriport.Enabled = true;
                btn_serial.BackColor = Color.Silver;
            }
        }

        private void View_STM_Cutting_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialCom.Close();
        }

        private void btn_cut_Click(object sender, EventArgs e)
        {
            // cut(int.Parse(nud_timerdelay.Value.ToString()));
            if (cutting == true &&gv_data.DataRowCount >0) timerdelay.Enabled = true;
        }
        //bool cut(int sleeptime)
        //{
        //    if (btn_serial.Text == "Connected Serial" &&chk_cut.Checked == true)
        //    {
        //        serialCom.Write("a");//1on 5off
        //        Thread.Sleep(sleeptime*1000);
        //        serialCom.Write("b");//1on 5off
        //    }
        //    return false;
        //}

        private void timerdelay_Tick(object sender, EventArgs e)
        {
            //gia trị 5    
            if (btn_serial.Text == "Connected Serial" && chk_cut.Checked == true && timer_ == int.Parse(nud_timerdelay.Value.ToString()))
            {
                serialCom.Write("a");//1on 5off
                serialCom.Write("c");//1on 5off
                timer_ = int.Parse(nud_timerdelay.Value.ToString()) - 1;
            }
            else if(btn_serial.Text == "Connected Serial" && chk_cut.Checked == true && timer_ ==0)
            {
                pictureBox1.Image = global::IFM.Properties.Resources.Waiting_LB;
                serialCom.Write("b");//1on 5off
                serialCom.Write("d");//1on 5off
                timer_ = int.Parse(nud_timerdelay.Value.ToString());
                timerdelay.Enabled = false;
                foreach (var control in dynamicTableLayoutPanel.Controls)
                {
                    if (control is System.Windows.Forms.Button btn)
                    {
                        btn.Image = global::IFM.Properties.Resources.Waiting;
                        btn.Text = "NA";
                    }
                }
            }
            else
            {
                timer_ = timer_-1;
            }    

        }
    }
}