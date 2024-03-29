﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;

namespace AOI_PQM
{
    public partial class AoIMainForm : Form
    {
        public AoIMainForm()
        {
            InitializeComponent();
        }
        string folderlog = @"C:\PQM_AOI\";
        string logconfig = @"C:\PQM_AOI\configuration.txt";
        string logerror = @"C:\PQM_AOI\log.txt";
        string pqmformat = @"C:\PQM_AOI\pqmformat.txt";
        DataTable dt;
        DataTable dtout;
        //list convert data
        string barcode; //serno
        string lot;
        string model;
        string site;
        string factory;
        string line;
        string process;
        string inspect;
        string date;
        string time;
        string data;
        string judge;
        string status;
        string remark;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private void AoIMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(folderlog);
                if (!exists) System.IO.Directory.CreateDirectory(folderlog);
                getmodel(cbm_model);
                readlogfileconfig(logconfig);
                lbl_timer.Text = nud_timer.Value.ToString();
                timer_auto.Interval = 1000;// int.Parse(nud_timer.Value.ToString());

                //xoa log loi
                exists = System.IO.File.Exists(logerror);
                if (exists) System.IO.File.Delete(logerror);
                txt_logerror.Text = "";
                btn_autoget_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Folder cấu hình không thể khởi tạo", "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void getmodel(ComboBox combo)
        {
            try
            {
                string sql = "select " + postgreSQLconnection.connectstring(1);// "select schema_name from information_schema.schemata";
                postgreSQLconnection con = new postgreSQLconnection();
                con.getComboBoxData(sql, ref combo);
            }
            catch (Exception ex)
            {
                writelogfile(" Getting model DB error", ex.ToString(), logerror);
            }
        }
        private void btn_browserout_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_browserout.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
        private void btn_reload_Click(object sender, EventArgs e)
        {
            AoIMainForm_Load(sender, e);
        }
        private void readlogfileconfig(string logfileconfigtxt)
        {
            try
            {
                bool exists = System.IO.File.Exists(logfileconfigtxt);
                if (!exists) return;
                string[] datarow = File.ReadAllLines(logfileconfigtxt);
                txt_browserout.Text = datarow[0];
                nud_timer.Value = int.Parse(datarow[1]);
                nud_DBday.Value = int.Parse(datarow[2]);
                nud_ServerDay.Value = int.Parse(datarow[3]);
                cbm_model.Text = datarow[4].ToString();
            }
            catch (Exception ex)
            {
                writelogfile(" Reading config file error", ex.ToString(), logerror);
            }
        }
        private void writelogfile(string header, string contents, string linklogfile)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Error: " + header);
                sb.Append("\n");
                sb.Append("Detail: " + contents);
                sb.Append("\n");
                sb.Append("DateTime: " + DateTime.Now.ToString("yyyyMMdd HHmmss"));
                sb.Append("\n");
                sb.Append("--------------------------------------------------------");
                sb.Append("\n");
                File.AppendAllText(linklogfile, sb.ToString());
                sb.Clear();
            }
            catch
            {
            }
        }

        private void btn_manualget_Click(object sender, EventArgs e)
        {
            writelogfileconfig(logconfig); //save lại config đường dẫn
            readPQMformat(pqmformat); // đọc giá trị PQM format
            CheckExistsFolder(txt_browserout.Text);  // tạo forder fptout
            CheckDBandExportFile(txt_browserout.Text); //conver và chuyển file đi,
            readlogfile(logerror);
        }
        void CheckDBandExportFile(string pathfolderout)
        {
            //get all model.
            //schecmas:LS16-PD-TOP
            //table: boardbarcode aoi_board 
            //on : pcbstarttime = starttime
            // columns out: barcode.boardbarcode ==? "": barcode.boardbarcode

            if (checkcondition())
            {
                try
                {

                  
                    dt = new DataTable();
                    maincontrol.DataSource = null;
                    maincontrol.Refresh();
                    StringBuilder sql = new StringBuilder();
                    //sql.Append(@"select  a.id, a.boardbarcode, a.pcbstarttime, COALESCE(sum( b.result),0) as resultno from ( ");
                    //sql.Append(@" select id, boardbarcode, pcbstarttime from  """ + cbm_model.Text + @""".aoi_board where 1=1 ");
                    //sql.Append(@" and pcbstarttime >= NOW() - interval '" + nud_DBday.Value + "day' ");
                    //sql.Append(@" and id not in ");
                    //sql.Append(@" (select distinct(board_id) from public.barcodeupload where 1=1 ");
                    //sql.Append(@" and datetimeup >= NOW() - interval '" + nud_ServerDay.Value + "day' )) a");
                    //sql.Append(@" left join   """ + cbm_model.Text + @""".aoi_component b ");
                    //sql.Append(@" on a.pcbstarttime = b.pcbstarttime where 1=1 ");
                    //sql.Append(@"  group by a.boardbarcode, a.pcbstarttime , a.id order by a.pcbstarttime desc ");
                    sql.Append(@" select boardindex , pcbbarcode ,pcbstarttime , result  from """ + cbm_model.Text + @""".aoi_panel ");
                    sql.Append(@" where 1=1  and pcbstarttime >=  NOW() - interval '" + nud_DBday.Value + "day' ");
                    sql.Append(@" and boardindex not in  (select distinct(board_id) from public.barcodeupload ");
                    sql.Append(@" where 1=1  and datetimeup >=  NOW() - interval '" + nud_ServerDay.Value + "day' )");
                    postgreSQLconnection con = new postgreSQLconnection();
                    con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                    maincontrol.DataSource = dt;
                    maincontrol.Refresh();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[0] != null)
                        {
                            barcode = row[1].ToString(); //khi chinh thức sửa lại 1. thử nghiệm là 0
                            lot = "_" + DateTime.Now.ToString("yyyyMMdd");
                            date = Convert.ToDateTime(row[2]).ToString("yyyy/MM/dd");
                            time = Convert.ToDateTime(row[2]).ToString("HH:mm:ss");
                            model = cbm_model.Text;
                            judge = row[3].ToString() == "1" ? "1" : "0";
                            data = row[3].ToString();
                            //insert barcode to localDB
                            string sqlinsert = @"INSERT INTO public.barcodeupload(board_id, barcode_cd,pcbstarttime,resultno,datetimeup)  
                            VALUES('" + row[0].ToString() + "','" + barcode + "','" + Convert.ToDateTime(row[2]).ToString("yyyyMMdd HH:mm:ss") + "'," + judge + ",now())";
                            con.sqlExecuteScalarString_Autosystem(sqlinsert);
                            writePQMformat(pathfolderout + "\\AOI_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");
                        }
                    }
                }
                catch (Exception ex)
                {
                    writelogfile(" Convert File Error", ex.ToString(), logerror);
                }
            }
        }

        bool checkcondition()
        {
            if (txt_browserout.Text == "" || nud_DBday.Value < 1 || nud_timer.Value < 10 || nud_ServerDay.Value < 1 || cbm_model.Text == "") return false;
            return true;
        }
        private void writelogfileconfig(string linklogfileconfig)
        {
            try
            {
                bool exists = System.IO.File.Exists(linklogfileconfig);
                if (exists)
                    System.IO.File.Delete(linklogfileconfig);

                StringBuilder sb = new StringBuilder();
                sb.Append(txt_browserout.Text);
                sb.Append("\n");
                sb.Append(nud_timer.Value);
                sb.Append("\n");
                sb.Append(nud_DBday.Value);
                sb.Append("\n");
                sb.Append(nud_ServerDay.Value);
                sb.Append("\n");
                sb.Append(cbm_model.Text);
                File.AppendAllText(linklogfileconfig, sb.ToString());
                sb.Clear();
            }
            catch (Exception ex)
            {
                writelogfile(" Writing config file error", ex.ToString(), logerror);
            }
        }
        private void readPQMformat(string filePQMformat)
        {
            try
            {
                bool exists = System.IO.File.Exists(filePQMformat);
                if (!exists) return;
                string[] datarow = File.ReadAllLines(filePQMformat);
                site = datarow[3];
                factory = datarow[4];
                line = datarow[5];
                process = datarow[6];
                inspect = datarow[7];
                status = datarow[12];
                remark = datarow[13];
            }
            catch (Exception ex)
            {
                writelogfile(" Reading PQM format file Error", ex.ToString(), logerror);
            }
        }
        void CheckExistsFolder(string linkfolder_)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(linkfolder_);
                if (!exists)
                    System.IO.Directory.CreateDirectory(linkfolder_);
            }
            catch (Exception ex)
            {
                writelogfile(" Create Folder  Error", ex.ToString(), logerror);
            }
        }
        private void readlogfile(string logfiletxt)
        {
            try
            {
                bool exists = System.IO.File.Exists(logfiletxt);
                if (!exists) return;
                string[] datarow = File.ReadAllLines(logfiletxt);
                txt_logerror.Text = datarow[0];
                //foreach (string s in datarow)
                //{
                //    txt_logerror.Text += s;
                //    txt_logerror.Text += "\n";
                //}
            }
            catch
            {
            }
        }
        private void writePQMformat(string filePQMformat)
        {
            try
            {
                bool exists = System.IO.File.Exists(filePQMformat);
                //if (exists)
                //    System.IO.File.Delete(filePQMformat);

                StringBuilder sb = new StringBuilder();
                sb.Append(@"""" + barcode + @"""" + ",");
                sb.Append(@"""" + lot + @"""" + ",");
                sb.Append(@"""" + model + @"""" + ",");
                sb.Append(site + ",");
                sb.Append(factory + ",");
                sb.Append(line + ",");
                sb.Append(process + ",");
                sb.Append(inspect + ",");
                sb.Append(@"""" + date + @"""" + ",");
                sb.Append(@"""" + time + @"""" + ",");
                sb.Append(@"""" + data + @"""" + ",");
                sb.Append(@"""" + judge + @"""" + ",");
                sb.Append(status + ",");
                sb.Append(remark);
                sb.Append("\n");
                File.AppendAllText(filePQMformat, sb.ToString());
                sb.Clear();
            }
            catch (Exception ex)
            {
                writelogfile(" Writing PQM format file Error", ex.ToString(), logerror);
            }
        }

        private void btn_autoget_Click(object sender, EventArgs e)
        {
            if (btn_autoget.Text == "AutoRun")
            {
                lbl_timer.Text = nud_timer.Value.ToString();
                btn_manualget_Click(sender, e);
                timer_auto.Enabled = true;
                btn_autoget.Text = "Running";
                btn_autoget.BackColor = Color.Green;
                cbm_model.Enabled = false;
            }
            else
            {
                timer_auto.Enabled = false;
                btn_autoget.Text = "AutoRun";
                cbm_model.Enabled = true;
                btn_autoget.BackColor = Color.Yellow;
            }
        }

        private void timer_auto_Tick(object sender, EventArgs e)
        {
            lbl_timer.Text = (int.Parse(lbl_timer.Text) - 1).ToString();
            lbl_status.Text = "Waiting upload";
            lbl_status.BackColor = Color.Yellow;
            if (lbl_timer.Text == "-1")
            {
                lbl_status.BackColor = Color.Green;
                btn_manualget_Click(sender, e);
                Thread.Sleep(2000);
                lbl_timer.Text = nud_timer.Value.ToString();
                lbl_status.Text = "Upload Data";

            }
        }
    }
}
