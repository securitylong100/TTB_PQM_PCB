using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using IFM.Common;
using IFM.Common.OnGrid;

namespace IFM.Views.CRM
{
    public partial class view_CRM_01_004 : Form
    {

        public view_CRM_01_004()
        {
            InitializeComponent();
        }
        DataTable dt;
        readonly string sqlusername = "select user_name, user_cd from m_user WHERE  user_status  =1   order by user_cd";
        readonly string sqldelete = "delete from t_get_money where 1=1  and ";
        readonly string sqlproject = "select distinct(project_name) from m_project order by project_name";


        private void view_CRM_01_004_Load(object sender, EventArgs e)
        {
            GetCombox();
            LoadData(false);
        }
        void GetCombox()
        {
            try
            {
                dt = new DataTable();
                Class.mysqlconnection con = new Class.mysqlconnection();
                con.sqlDataAdapterFillDatatable(sqlusername, ref dt);
                if (dt.Rows.Count == 0) return;
                var x = (from r in dt.AsEnumerable()
                         select r["user_cd"]).Distinct().ToList();
                foreach (var x1 in x)
                { cbm_usercd_get.Items.Add(x1); }
                var y = (from r in dt.AsEnumerable()
                         select r["user_name"]).Distinct().ToList();
                foreach (var y1 in y)
                {
                    cbm_username_get.Items.Add(y1);
                    cbm_user_app.Items.Add(y1);
                }
                cbm_username_get.SelectedItem = ClsSession.App.UserName;
                cbm_user_app.Text = "Lê Thanh Long"; //fixed
                con.getComboBoxData(sqlproject, ref cbm_project_name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void cbm_username_get_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class.mysqlconnection con = new Class.mysqlconnection();
            cbm_usercd_get.Text = con.sqlExecuteScalarString("select distinct user_cd from m_user where user_name = '" + cbm_username_get.SelectedItem + "'");
            LoadData(false);
        }
        private void cbm_usercd_get_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class.mysqlconnection con = new Class.mysqlconnection();
            cbm_username_get.Text = con.sqlExecuteScalarString("select distinct user_name from m_user where user_cd = '" + cbm_usercd_get.SelectedItem + "'");
            LoadData(false);
        }
        private void chb_user_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_user.Checked == true)
            {
                cbm_username_get.Enabled = false;
                cbm_usercd_get.Enabled = false;
            }
            else
            {
                cbm_username_get.Enabled = true;
                cbm_usercd_get.Enabled = true;
            }
            LoadData(false);
        }
        private void rdb_checking_CheckedChanged(object sender, EventArgs e)
        {
            LoadData(false);
            //code rule in here
            if (rdb_checking.Checked == true)
            {

                gv_main.Columns[6].OptionsColumn.ReadOnly = false;
            }
            else
            {
                gv_main.Columns[6].OptionsColumn.ReadOnly = true;
            }
        }

        private void rdb_checked_CheckedChanged(object sender, EventArgs e)
        {
            LoadData(false);
        }

        private void rdb_add_CheckedChanged(object sender, EventArgs e)
        {
            LoadData(false);
        }
        void LoadData(bool filterfull)
        {
            try
            {
                if (filterfull)
                {

                }
                dt = new DataTable();
                Class.mysqlconnection con = new Class.mysqlconnection();
                StringBuilder sqlload = new StringBuilder();
                sqlload.Append("select * from t_get_money where 1=1 ");
                sqlload.Append(" and (d_get) > NOW() - INTERVAL 100 DAY");

                //đa checked
                if (rdb_checked.Checked == true && chb_user.Checked == false)
                {
                    sqlload.Append(" and  status = 'Yes' ");
                    sqlload.Append(" and u_get = '" + cbm_username_get.SelectedItem + "'");
                }
                else if (rdb_checked.Checked == true && chb_user.Checked == true)
                {
                    sqlload.Append(" and  status = 'Yes' ");
                    sqlload.Append(" and ( u_get = '" + ClsSession.App.UserName + "'  ");
                    sqlload.Append(" or user_name_App = '" + ClsSession.App.UserName + "' ) ");
                }

                //add new
                if (rdb_add.Checked == true && chb_user.Checked == false)
                {
                    sqlload.Append(" and  status = 'No' ");
                    sqlload.Append(" and u_get = '" + cbm_username_get.SelectedItem + "'");
                }
                else if (rdb_add.Checked == true && chb_user.Checked == true)
                {
                    sqlload.Append(" and  status = 'No' ");
                    sqlload.Append(" and  u_get = '" + ClsSession.App.UserName + "'  ");
                }

                //chuẩn bị check
                if (rdb_checking.Checked == true && chb_user.Checked == false)
                {
                    sqlload.Append(" and  status = 'No' ");
                    sqlload.Append(" and user_name_App = '" + ClsSession.App.UserName + "'");
                    sqlload.Append(" and u_get = '" + cbm_username_get.SelectedItem + "'");
                }
                else if (rdb_checking.Checked == true && chb_user.Checked == true)
                {
                    sqlload.Append(" and  status = 'No' ");
                    sqlload.Append(" and user_name_App = '" + ClsSession.App.UserName + "'");

                }




                sqlload.Append(" order by u_get desc");
                con.sqlDataAdapterFillDatatable(sqlload.ToString(), ref dt);
                gc_main.DataSource = dt;
                //add combobox
                GetComboxIntoGrid(cbm_username_get, "u_get");
                GetComboxIntoGrid(cbm_type_content, "type_content");
                GetComboxIntoGrid(cbm_project_name, "project_name");
                GetComboxIntoGrid(cbm_user_app, "user_name_App");

                //add check box
                gv_main.Columns["status"].ColumnEdit = new RepositoryItemComboBox
                {
                    Items = { "No", "Yes" }
                };
                lbl_rowscount.Text = "Rows Count: " + gv_main.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void GetComboxIntoGrid(System.Windows.Forms.ComboBox cbm, string colHeader)
        {
            try
            {
                var arr = cbm.Items.Cast<Object>().Select(item => item.ToString()).ToArray();
                RepositoryItemComboBox riComboBox = new RepositoryItemComboBox();
                riComboBox.Items.AddRange(arr);
                gc_main.RepositoryItems.Add(riComboBox);
                gv_main.Columns[colHeader].ColumnEdit = riComboBox;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        bool checkcondition()
        {
            if (cbm_username_get.SelectedItem == null || cbm_user_app.SelectedItem == null || cbm_type_content.SelectedItem == null || cbm_project_name.SelectedItem == null || calc_money.Text == "0" || calc_money.Text == "")
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txt_contentdetails.Text.Length < 15)
            {
                MessageBox.Show("Nội Dung Chuyển Tiền Phải Hơn 15 Ký Tự!!!", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            LoadData(false);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            rdb_add.Checked = true;
            LoadData(false);
            try
            {
                if (checkcondition())
                {
                    DataRow row = dt.NewRow();

                    row["content"] = txt_contentdetails.Text;
                    row["money_value"] = calc_money.Value;
                    row["u_get"] = cbm_username_get.Text;
                    row["u_pay"] = ClsSession.App.UserName;
                    row["type_content"] = cbm_type_content.Text;
                    row["project_name"] = cbm_project_name.Text;
                    row["d_get"] = DateTime.Now;
                    row["status"] = "No";
                    row["user_name_App"] = cbm_user_app.Text;     
                    row["u_update"] = "";
                    row["d_update"] = DateTime.Now;
                    row["u_create"] = ClsSession.App.UserName;
                    row["d_create"] = DateTime.Now;
                    dt.Rows.Add(row);
                    savedb();
                    email();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void email()
        {
            String SendMailFrom = "info@ifmsolutionsvn.com";
            String SendMailTo = "ifm_sales@ifmsolutionsvn.com";
            String ccMail = "info@ifmsolutionsvn.com";
            String SendMailSubject = "PayGetMoney ";
            string htmlString = @"Dear All  
           
            Bạn " + ClsSession.App.UserName + @" Vừa Thực Hiện Thao Tác Ứng Chi Trước với Nội Dung như Sau:
            --------  
            1. Số Tiền Ứng: " + string.Format("{0:#,##0.00}", double.Parse(calc_money.Text)) + @"   VND;
            2. Ai Ứng Chi Trước: " + cbm_username_get.Text + @"
            3. Tên Dự Án: " + cbm_project_name.Text + @"
            4. Nội Dung Ứng Chi Trước: " + txt_contentdetails.Text + @"
            5. Người Duyệt: " + cbm_user_app.Text + @"
            6. Ngày Giờ Thao Tác:  " + DateTime.Now.ToString() + @"

            -------- 
             *** Chú ý: Đây là Email Tự Động, xin đừng trả lời email này!!!   
                                  
            Xin cảm ơn.
                  ---HR-IFM---
            IFM SOLUTIONS., Ltd 
            Mobile: +84 869 123 964| E-mail: info@ifmsolutionsvn.com
            Address: 30/11 Hoang Huu Nam, Long Thanh My, Thu Duc City, Ho Chi Minh City.
            Website: http://ifmsolutionsvn.com
                  ---Thank---";
            String SendMailBody = htmlString;
            try
            {
                SmtpClient SmtpServer = new SmtpClient("mail93156.maychuemail.com", 25)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                MailMessage email = new MailMessage
                {
                    // START
                    From = new MailAddress(SendMailFrom)
                };
                email.To.Add(SendMailTo);
                email.CC.Add(ccMail);
                email.Subject = SendMailSubject;
                email.Body = SendMailBody;
                //var attachment = new Attachment(@"E:\C#\Salary Monthly\" + filename);
                //email.Attachments.Add(attachment);
                //END
                SmtpServer.Timeout = 10000;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "longifm@123");
                SmtpServer.Send(email);

              //  MessageBox.Show("Sent Email", "Sending Email");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void savedb()
        {
            dt.AcceptChanges();
            if (rdb_checked.Checked == true)
            {
                MessageBox.Show("Not Successful, Pls select default radio check!!!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dt.Rows.Count == 0) return;
            Class.mysqlconnection con = new Class.mysqlconnection();
            Functions function = new Functions();
            foreach (DataRow rowdt in dt.Rows)
            {
                if (rowdt["ID"].ToString() == "")
                {
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO t_get_money
                                    (content, money_value, u_get, u_pay, type_content, project_name, d_get, status, 
                                        user_name_App, u_update, d_update, u_create, d_create)
                                    VALUES("
                                    );

                    sqlinsert.Append("'" + rowdt["content"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["money_value"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["u_get"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["u_pay"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["type_content"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["project_name"].ToString() + "',");
                    sqlinsert.Append("'" + function.ConvertDate(rowdt["d_get"].ToString()) + "',");
                    sqlinsert.Append("'" + rowdt["status"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["user_name_App"].ToString() + "',");

                    sqlinsert.Append("'" + rowdt["u_update"].ToString() + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP,");
                    sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteScalarString(sqlinsert.ToString());
                    //function.ConvertDate(rowdt["d_get"].ToString())
                }
                else
                {
                    StringBuilder sqlupdate = new StringBuilder();
                    sqlupdate.Append(@"UPDATE t_get_money set ");
                    sqlupdate.Append("content = '" + rowdt["content"].ToString() + "',");
                    sqlupdate.Append("money_value = '" + rowdt["money_value"].ToString() + "',");
                    sqlupdate.Append("u_get = '" + rowdt["u_get"].ToString() + "',");
                    sqlupdate.Append("u_pay = '" + rowdt["u_pay"].ToString() + "',");
                    sqlupdate.Append("type_content = '" + rowdt["type_content"].ToString() + "',");
                    sqlupdate.Append("project_name = '" + rowdt["project_name"].ToString() + "',");
                    sqlupdate.Append("d_get = '" + function.ConvertDate(rowdt["d_get"].ToString()) + "',");
                    sqlupdate.Append("status = '" + rowdt["status"].ToString() + "',");
                    sqlupdate.Append("user_name_App = '" + rowdt["user_name_App"].ToString() + "',");

                    sqlupdate.Append("u_update = '" + ClsSession.App.UserName + "',");
                    sqlupdate.Append("d_update = CURRENT_TIMESTAMP");
                    sqlupdate.Append(" where 1=1 and ID = " + rowdt["ID"].ToString() + "");
                    con.sqlExecuteScalarString(sqlupdate.ToString());
                }
            }
            MessageBox.Show("Action Successful", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData(false);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            savedb();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "output.xlsx";
                gc_main.ExportToXlsx(path);
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void gv_main_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int keyValue = (int)view.GetRowCellValue(view.FocusedRowHandle, "ID");
                string value_ = view.EditingValue.ToString();
                string header_ = view.FocusedColumn.FieldName.ToString();
                dt.Select(string.Format("[ID] = '{0}'", keyValue)).ToList<DataRow>().ForEach(r => { r[header_] = value_; });
                // dt_tem = dt; //only test
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void gv_main_KeyDown(object sender, KeyEventArgs e)
        {
            if (rdb_add.Checked == true)
            {
                DeleteRow CallDeleteRow = new DeleteRow();
                CallDeleteRow.keydownDelete(sender, e, sqldelete);
                // LoadData(false);
            }
        }
        private void gv_main_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (rdb_add.Checked == true)
            {
                DeleteRow CallDeleteRow = new DeleteRow();
                CallDeleteRow.MouseRight(sender, e, sqldelete);
                //  LoadData(false);
            }
        }

       
    }
}
