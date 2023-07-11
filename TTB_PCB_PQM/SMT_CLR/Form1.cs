using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace SMT_CLR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string logerror = @"C:\PQM_CLR\log.txt";
        string folderBK = @"C:\PQM_CLR";
        string barcode = "";
        string tool_station = "";
        string tool_check = "";
        string creator = "";
        string create_time = "";
        private void btn_autoget_Click(object sender, EventArgs e)
        {

            if (btn_autoget.Text == "AutoRun")
            {
                ConvertandMoveFile(txt_browserin.Text, folderBK);
                lbl_timer.Text = nud_timer.Value.ToString();
                timer_auto.Enabled = true;
                btn_autoget.Text = "Running";
                btn_autoget.BackColor = Color.Green;
                txt_browserin.ReadOnly = true;
            }
            else
            {
                timer_auto.Enabled = false;
                btn_autoget.Text = "AutoRun";
                btn_autoget.BackColor = Color.Yellow;
                txt_browserin.ReadOnly = false;
            }
        }
        void ConvertandMoveFile(string pathfolderin, string pathfolderbackup)
        {
            System.IO.DirectoryInfo d = new DirectoryInfo(pathfolderin);
            FileInfo[] Files = d.GetFiles("*.csv");
            foreach (FileInfo file in Files)
            {
                try
                {
                    string[] datarow = File.ReadAllLines(pathfolderin + "\\" + file);
                    string[] arrListStr = datarow[0].ToString().Split(',');
                    barcode = arrListStr[0].ToString();
                    tool_station = arrListStr[1].ToString();
                    tool_check = arrListStr[2].ToString();
                    creator = arrListStr[3].ToString();
                    create_time = DateTime.Now.ToString("yyyyMMdd HHmmss");
                    pgsqlconnection con = new pgsqlconnection();
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO smt_m_tool_history
                                    (tool_cd , tool_station , tool_check ,creator,create_time )
                                    VALUES(");
                    sqlinsert.Append("'" + barcode + "',");
                    sqlinsert.Append("'" + tool_station + "',");
                    sqlinsert.Append("'" + tool_check + "',");
                    sqlinsert.Append("'" + creator + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteScalarString_Autosystem(sqlinsert.ToString());
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
        private void btn_browserin_Click(object sender, EventArgs e)
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

        private void timer_auto_Tick(object sender, EventArgs e)
        {
            readlogfile(logerror);
            lbl_timer.Text = (int.Parse(lbl_timer.Text) - 1).ToString();
            lbl_status.Text = "Waiting upload";
            lbl_status.BackColor = Color.Yellow;
            if (lbl_timer.Text == "0")
            {
                ConvertandMoveFile(txt_browserin.Text, folderBK);
                lbl_timer.Text = nud_timer.Value.ToString();
                lbl_status.Text = "Upload Data";
                lbl_status.BackColor = Color.Green;
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
            }
            catch
            {
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
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckExistsFolder(folderBK);
        }
    }
}
