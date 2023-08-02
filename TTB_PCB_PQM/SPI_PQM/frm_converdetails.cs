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
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace SPI_PQM
{
    public partial class frm_converdetails : Form
    {
        public frm_converdetails()
        {
            InitializeComponent();
        }
        string folderBK = "";
        string folderlog = @"C:\PQM\";
        string logconfig = @"C:\PQM\configuration.txt";
        string logerror = @"C:\PQM\log.txt";
        string pqmformat = @"C:\PQM\pqmformat.txt";
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
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(folderlog);
                if (!exists) System.IO.Directory.CreateDirectory(folderlog);
                readlogfileconfig(logconfig);
                lbl_timer.Text = nud_timer.Value.ToString();
                timer_auto.Interval = 1000;// int.Parse(nud_timer.Value.ToString());

                //xoa log loi
                exists = System.IO.File.Exists(logerror);
                if (exists) System.IO.File.Delete(logerror);
                txt_logerror.Text = "";
            }
            catch
            {
                MessageBox.Show("Folder cấu hình không thể khởi tạo", "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_reload_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
        private void btn_browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txt_browserin.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
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
        private void btn_autoget_Click(object sender, EventArgs e)
        {
            if (btn_autoget.Text == "AutoRun")
            {
                lbl_timer.Text = nud_timer.Value.ToString();
                btn_manualget_Click(sender, e);
                timer_auto.Enabled = true;
                btn_autoget.Text = "Running";
                btn_autoget.BackColor = Color.Green;
            }
            else
            {
                timer_auto.Enabled = false;
                btn_autoget.Text = "AutoRun";
                btn_autoget.BackColor = Color.Yellow;
            }
        }
        private void timer_auto_Tick(object sender, EventArgs e)
        {
            lbl_timer.Text = (int.Parse(lbl_timer.Text) - 1).ToString();
            lbl_status.Text = "Waiting upload";
            lbl_status.BackColor = Color.Yellow;
            if (lbl_timer.Text == "0")
            {
                btn_manualget_Click(sender, e);
                lbl_timer.Text = nud_timer.Value.ToString();
                lbl_status.Text = "Upload Data";
                lbl_status.BackColor = Color.Green;
            }
        }
        private void btn_manualget_Click(object sender, EventArgs e)
        {
            writelogfileconfig(logconfig); //save lại config đường dẫn
            readPQMformat(pqmformat); // đọc giá trị PQM format
            folderBK = txt_browserin.Text + "\\Backup\\" + DateTime.Now.ToString("yyyyMMdd");
            CheckExistsFolder(folderBK);  // tạo forder cho ngày hiện tại
            CheckExistsFolder(txt_browserout.Text);  // tạo forder fptout
            ConvertandMoveFile(txt_browserin.Text, txt_browserout.Text, folderBK); //conver và chuyển file đi,
            readlogfile(logerror);

        }
        void ConvertandMoveFile(string pathfolderin, string pathfolderout, string pathfolderbackup)
        {

            DirectoryInfo d = new DirectoryInfo(pathfolderin);
            FileInfo[] Files = d.GetFiles("*.xlsx");
            dtout = new DataTable();
            foreach (FileInfo file in Files)
            {
                try
                {
                    //string[] arrListStr = file.ToString().Split('_');
                    //string model_ = "";
                    //if(arrListStr.Length>0)
                    //{
                    //    string sub = arrListStr[arrListStr.Length - 2];
                    //    int a = file.ToString().IndexOf(sub);
                    //    //for(int i = 1; i < arrListStr.Length-2;i++)
                    //    //{
                    //    //    model = arrListStr[i].ToString() + "_"+arrListStr[i+1].ToString();
                    //    //}                    
                    //}
                    int ps = file.ToString().IndexOf(DateTime.Now.ToString("yyyyMMdd"));
                    if (file.ToString().Length > 0)
                    {
                        model = file.ToString().Substring(0, file.ToString().Length - ps - 1);
                    }

                    dt = new DataTable();
                    // dt = ConvertCSVtoDataTable(pathfolderin + "\\" + file);
                    dt = ExcelDataToDataTable(pathfolderin + "\\" + file,0);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[0] != null)
                        {
                            barcode = row[2].ToString();
                            lot = "_" + DateTime.Now.ToString("yyyyMMdd");
                            date = Convert.ToDateTime(row[0]).ToString("yyyy/MM/dd");
                            time = Convert.ToDateTime(row[0]).ToString("HH:mm:ss");
                            judge = row[3].ToString() == "NG" ? "1" : "0";
                            data = judge;
                            writePQMformat(pathfolderout + "\\SPI_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv");
                        }
                    }
                    //xuất file csv 

                    if (File.Exists(pathfolderbackup + "\\" + file))
                    {
                        File.Delete(pathfolderbackup + "\\" + file);
                    }
                    File.Move(pathfolderin + "\\" + file, pathfolderbackup + "\\" + file);
                }
                catch (Exception ex)
                {
                    writelogfile(" Convert and Move File Error", ex.ToString(), logerror);
                }
            }

        }
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt2 = new DataTable();
            //try
            {
                using (StreamReader sr = new StreamReader(strFilePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dt2.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dt2.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dt2.Rows.Add(dr);
                    }
                }
                return dt2;
            }
        }
        public static DataTable ExcelDataToDataTable(string filePath, int sheetNo, bool hasHeader = true)
        {
            var dt = new DataTable();
            var fi = new FileInfo(filePath);
            // Check if the file exists
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var xlPackage = new ExcelPackage(fi);
            // get the first worksheet in the workbook
            var worksheet = xlPackage.Workbook.Worksheets[sheetNo];

            dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
            {
                c.FirstRowIsColumnNames = true;
            });

            return dt;
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
        private void readlogfileconfig(string logfileconfigtxt)
        {
            try
            {
                bool exists = System.IO.File.Exists(logfileconfigtxt);
                if (!exists) return;
                string[] datarow = File.ReadAllLines(logfileconfigtxt);
                txt_browserin.Text = datarow[0];
                txt_browserout.Text = datarow[1];
                nud_timer.Value = int.Parse(datarow[2]);
            }
            catch (Exception ex)
            {
                writelogfile(" Reading config file error", ex.ToString(), logerror);
            }
        }
        private void writelogfileconfig(string linklogfileconfig)
        {
            try
            {
                bool exists = System.IO.File.Exists(linklogfileconfig);
                if (exists)
                    System.IO.File.Delete(linklogfileconfig);

                StringBuilder sb = new StringBuilder();
                sb.Append(txt_browserin.Text);
                sb.Append("\n");
                sb.Append(txt_browserout.Text);
                sb.Append("\n");
                sb.Append(nud_timer.Value);
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


    }
}