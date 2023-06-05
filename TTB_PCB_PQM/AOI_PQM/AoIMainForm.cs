using System;
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
        private void AoIMainForm_Load(object sender, EventArgs e)
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
                nud_ServerDay.Value = int.Parse(datarow[2]);
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

        private void btn_reload_Click(object sender, EventArgs e)
        {
            AoIMainForm_Load(sender, e);
        }
    }
}
