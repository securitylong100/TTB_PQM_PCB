using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common.OnGrid;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFM.Views.CRM
{
    public partial class view_CRM_01_001 : Form
    {

        public view_CRM_01_001()
        {
            InitializeComponent();
        }
        //long updated
        DataTable dt;
        readonly string sqluser = @"select distinct(user_name) from m_user where user_status ='1'
                            and user_role >= (select user_role from m_user where user_name = '" + ClsSession.App.UserName + "')";
        readonly string sqlApp = "select distinct(user_name) from m_user where user_comments = 'IFM' order by user_name";
        readonly string sqlproject = "select distinct(project_name) from m_project where 1=1 and project_status  =1 order by project_name";
        readonly string sqlprocess = "select distinct(process_name) from m_process order by process_name";
        readonly string sqldelete = "delete from t_TimeKeeping where 1=1 and status_keeping = 'No' and ";
        readonly string sqlmission = "select distinct (item_money) from m_money_sub where  item_money  like '%:%' order by item_money";
        string valueBeforeEditing = "";
        private void frm_customer_Load(object sender, EventArgs e)
        {
            GetCombox();
            LoadData(false);
            //set duplicate
            dt.PrimaryKey = new DataColumn[] { dt.Columns["No_TimeKeeping"] };
            dt.Columns["user_name"].AllowDBNull = false;
        }
        void GetCombox()
        {
            try
            {
                Class.mysqlconnection con = new Class.mysqlconnection();
                con.getComboBoxData(sqlApp, ref cbm_UserApproval);
                con.getComboBoxData(sqluser, ref cbm_username);
                con.getComboBoxData(sqlproject, ref cbm_project);
                con.getComboBoxData(sqlprocess, ref cbm_process);
                con.getComboBoxData(sqlmission, ref cbm_type_mission);
                cbm_username.Items.Add(ClsSession.App.UserName);
                cbm_username.Text = ClsSession.App.UserName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void chb_enable_combox_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_enable_combox.Checked == true)
                cbm_username.Enabled = false;
            else
                cbm_username.Enabled = true;
            LoadData(false);
        }
        private void chb_showall_CheckedChanged(object sender, EventArgs e)
        {
            LoadData(false);
        }
        private void rdb_add_CheckedChanged(object sender, EventArgs e)
        {
            LoadData(false);
        }
        private void rdb_check_CheckedChanged(object sender, EventArgs e)
        {
            LoadData(false);
            //code rule in here
            if (rdb_checking.Checked == true)
            {

                gv_main.Columns[11].OptionsColumn.ReadOnly = false;
            }
            else
            {
                gv_main.Columns[11].OptionsColumn.ReadOnly = true;
            }
        }
        private void cbm_username_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(false);
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
                sqlload.Append("select * from t_TimeKeeping where 1=1 ");
                sqlload.Append(" and (startdate_keeping) > NOW() - INTERVAL 60 DAY");

                //đa checked
                if (rdb_checked.Checked == true && chb_enable_combox.Checked == false)
                {
                    sqlload.Append(" and  status_keeping = 'Yes' ");
                    sqlload.Append(" and user_name = '" + cbm_username.SelectedItem + "'");
                }
                else if (rdb_checked.Checked == true && chb_enable_combox.Checked == true)
                {
                    sqlload.Append(" and  status_keeping = 'Yes' ");
                    sqlload.Append(" and ( user_name = '" + ClsSession.App.UserName + "'  ");
                    sqlload.Append(" or user_name_App = '" + ClsSession.App.UserName + "' ) ");
                }

                //add new
                if (rdb_add.Checked == true && chb_enable_combox.Checked == false)
                {
                    sqlload.Append(" and  status_keeping = 'No' ");
                    sqlload.Append(" and user_name = '" + cbm_username.SelectedItem + "'");
                }
                else if (rdb_add.Checked == true && chb_enable_combox.Checked == true)
                {
                    sqlload.Append(" and  status_keeping = 'No' ");
                    sqlload.Append(" and  user_name = '" + ClsSession.App.UserName + "'  ");

                }

                //chuẩn bị check
                if (rdb_checking.Checked == true && chb_enable_combox.Checked == false)
                {
                    sqlload.Append(" and  status_keeping = 'No' ");
                    sqlload.Append(" and user_name_App = '" + ClsSession.App.UserName + "'");
                    sqlload.Append(" and user_name = '" + cbm_username.SelectedItem + "'");
                }
                else if (rdb_checking.Checked == true && chb_enable_combox.Checked == true)
                {
                    sqlload.Append(" and  status_keeping = 'No' ");
                    sqlload.Append(" and user_name_App = '" + ClsSession.App.UserName + "'");

                }

                sqlload.Append(" order by No_TimeKeeping desc");
                con.sqlDataAdapterFillDatatable(sqlload.ToString(), ref dt);

                gc_main.DataSource = dt;
                GetComboxIntoGrid(cbm_username, "user_name");
                GetComboxIntoGrid(cbm_UserApproval, "user_name_App");
                GetComboxIntoGrid(cbm_project, "project_name");
                GetComboxIntoGrid(cbm_process, "process_name");
                GetComboxIntoGrid(cbm_type_keeping, "type_keeping");
                GetComboxIntoGrid(cbm_startday, "startdate_keeping");
                GetComboxIntoGrid(cbm_endday, "enddate_keeping");
                GetComboxIntoGrid(cbm_type_mission, "type_mission");

                gv_main.Columns["status_keeping"].ColumnEdit = new RepositoryItemComboBox
                {
                    Items = { "No", "Yes" }
                };
                gv_main.Columns["have_lunch"].ColumnEdit = new RepositoryItemComboBox
                {
                    Items = { 0, 1,2,3 }
                };

                //var richeckbox = new RepositoryItemCheckEdit();
                //richeckbox.ValueChecked = "True";
                //gc_main.RepositoryItems.Add(richeckbox);
                //gv_main.Columns["have_lunch"].ColumnEdit = richeckbox;

                //gv_main.Columns["have_lunch"].ColumnEdit = new RepositoryItemComboBox
                //{
                //    Items = { "No", "Yes" }
                //};

                lbl_rowscount.Text = "Rows Count: " + gv_main.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        DateTime ConCat(System.Windows.Forms.ComboBox cbm_datetime)
        {
            DateTime datetime = DateTime.Now;
            try
            {

                string strdatetime = dtp_date.Value.ToString("yyyyMMdd") + " " + cbm_datetime.Text + ":00";
                datetime = DateTime.ParseExact(strdatetime, "yyyyMMdd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                return datetime;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
                return datetime;
            }
        }
        double TotalKeeping(System.Windows.Forms.ComboBox cbm)
        {
            double result = 0;
            try
            {

                string tem1 = cbm.Text.Replace("3", "5");
                string tem2 = tem1.Replace(":", ".");
                result = Convert.ToDouble(tem2);
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
                return result;
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            LoadData(false);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            rdb_add.Checked = true;
            try
            {
                LoadData(false);
                int KeepingNo_Grid = 1;
                if (dt.Rows.Count > 0) KeepingNo_Grid = (int.Parse(dt.AsEnumerable().Max(row => row["No_TimeKeeping"]).ToString()) + 1);
                string sqlgetNoTimeKeeping = "select MAX(No_TimeKeeping)+1 as ID from t_TimeKeeping where 1=1 ";
                Class.mysqlconnection con = new Class.mysqlconnection();
                int KeepingNo_DB = con.sqlExecuteScalarString(sqlgetNoTimeKeeping) == "" ? 1 : int.Parse(con.sqlExecuteScalarString(sqlgetNoTimeKeeping));

                if (checkcondition())
                {
                    DataRow row = dt.NewRow();
                    row["No_TimeKeeping"] = KeepingNo_Grid > KeepingNo_DB ? KeepingNo_Grid : KeepingNo_DB;
                    row["user_name"] = cbm_username.Text;//ClsVariables.App.UserName;
                    row["startdate_keeping"] = ConCat(cbm_startday);
                    row["enddate_keeping"] = ConCat(cbm_endday);
                    row["total_keeping"] = TotalKeeping(cbm_endday) - TotalKeeping(cbm_startday);
                    row["type_keeping"] = cbm_type_keeping.Text;
                    row["project_name"] = cbm_project.Text;
                    row["process_name"] = cbm_process.Text;
                    row["user_name_App"] = cbm_UserApproval.Text;
                    row["status_keeping"] = "No";
                    row["details_keeping"] = txt_detailsjob.Text;
                    row["have_lunch"] = nud_havelunch.Value;
                    row["type_mission"] = cbm_type_mission.Text;
                    row["user_comments"] = "new";
                    row["u_update"] = "";
                    row["d_update"] = DateTime.Now;
                    row["u_create"] = ClsSession.App.UserName;
                    row["d_create"] = DateTime.Now;
                    dt.Rows.Add(row);
                    savedb();
                    //  LoadData(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            // LoadData(false);
            savedb();
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
                if (rowdt["ID"].ToString() == "")//&& rowdt["No_TimeKeeping"].ToString() != "")
                {
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO t_TimeKeeping
                                    (No_TimeKeeping, user_name, startdate_keeping, enddate_keeping,
                                    total_keeping, type_keeping, project_name, process_name, user_name_App,have_lunch,type_mission,
                                    status_keeping, details_keeping, user_comments, u_update, d_update, u_create, d_create)
                                    VALUES("
                                    );

                    sqlinsert.Append("'" + rowdt["No_TimeKeeping"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["user_name"].ToString() + "',");
                    sqlinsert.Append("'" + function.ConvertDate(rowdt["startdate_keeping"].ToString()) + "',");
                    sqlinsert.Append("'" + function.ConvertDate(rowdt["enddate_keeping"].ToString()) + "',");
                    sqlinsert.Append("'" + rowdt["total_keeping"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["type_keeping"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["project_name"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["process_name"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["user_name_App"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["have_lunch"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["type_mission"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["status_keeping"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["details_keeping"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["user_comments"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["u_update"].ToString() + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP,");
                    sqlinsert.Append("'" + ClsSession.App.UserName + "',");
                    sqlinsert.Append("CURRENT_TIMESTAMP");
                    sqlinsert.Append(")");
                    con.sqlExecuteScalarString(sqlinsert.ToString());

                }
                else
                {
                    StringBuilder sqlupdate = new StringBuilder();
                    sqlupdate.Append(@"UPDATE t_TimeKeeping set ");
                    sqlupdate.Append("user_name = '" + rowdt["user_name"].ToString() + "',");
                    sqlupdate.Append("startdate_keeping = '" + function.ConvertDate(rowdt["startdate_keeping"].ToString()) + "',");
                    sqlupdate.Append("enddate_keeping = '" + function.ConvertDate(rowdt["enddate_keeping"].ToString()) + "',");
                    sqlupdate.Append("total_keeping = '" + rowdt["total_keeping"].ToString() + "',");
                    sqlupdate.Append("type_keeping = '" + rowdt["type_keeping"].ToString() + "',");
                    sqlupdate.Append("project_name = '" + rowdt["project_name"].ToString() + "',");
                    sqlupdate.Append("process_name = '" + rowdt["process_name"].ToString() + "',");
                    sqlupdate.Append("user_name_App = '" + rowdt["user_name_App"].ToString() + "',");
                    sqlupdate.Append("have_lunch = '" + rowdt["have_lunch"].ToString() + "',");
                    sqlupdate.Append("type_mission = '" + rowdt["type_mission"].ToString() + "',");
                    sqlupdate.Append("status_keeping = '" + rowdt["status_keeping"].ToString() + "',");
                    sqlupdate.Append("details_keeping = '" + rowdt["details_keeping"].ToString() + "',");
                    sqlupdate.Append("user_comments = '" + rowdt["user_comments"].ToString() + "',");
                    sqlupdate.Append("u_update = '" + ClsSession.App.UserName + "',");
                    sqlupdate.Append("d_update = CURRENT_TIMESTAMP");
                    sqlupdate.Append(" where 1=1 and ID = " + rowdt["ID"].ToString() + "");
                    con.sqlExecuteScalarString(sqlupdate.ToString());

                }
            }
            MessageBox.Show("Action Successful", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData(false);
        }
        bool checkcondition()
        {
            if (cbm_type_keeping.SelectedItem == null || cbm_username.SelectedItem == null || cbm_process.SelectedItem == null || cbm_project.SelectedItem == null || cbm_UserApproval.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txt_detailsjob.Text.Length < 15)
            {
                MessageBox.Show("Thông Tin Chi Tiết Công Phải Nhập Đầy Đủ", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(cbm_endday.Text.Substring(0, 2) + cbm_endday.Text.Substring(3, 2)) <= int.Parse(cbm_startday.Text.Substring(0, 2) + cbm_startday.Text.Substring(3, 2)))
            {
                MessageBox.Show("Giờ Kết Thúc phải lớn hơn giờ Bắt đầu", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
        private void gv_main_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                Functions function = new Functions();
                GridView view = sender as GridView;
                string header_ = view.FocusedColumn.FieldName.ToString();
                int keyValue = (int)view.GetRowCellValue(view.FocusedRowHandle, "No_TimeKeeping");
                string value = view.GetRowCellValue(view.FocusedRowHandle, header_).ToString();
                if (valueBeforeEditing != "")
                {
                    string valueAfterEdited = value.Substring(value.IndexOf(" ") + 1, value.Length - value.IndexOf(" ") - 1);
                    string[] arrListValueBefore = valueBeforeEditing.Split(' ');                   
                    dt.Select(string.Format("[No_TimeKeeping] = '{0}'", keyValue)).ToList<DataRow>().ForEach(r => { r[header_] = arrListValueBefore[0].ToString() + " " + valueAfterEdited; });
                    DateTime startdate = Convert.ToDateTime(view.GetRowCellValue(view.FocusedRowHandle, "startdate_keeping").ToString());
                    DateTime enddate = Convert.ToDateTime(view.GetRowCellValue(view.FocusedRowHandle, "enddate_keeping").ToString());
                    if(startdate >= enddate)
                    {
                        dt.Select(string.Format("[No_TimeKeeping] = '{0}'", keyValue)).ToList<DataRow>().ForEach(r => { r[header_] = valueBeforeEditing; });
                        MessageBox.Show("Giờ Kết Thúc không thể nhỏ hơn giờ Bắt Đầu", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    TimeSpan Time = enddate - startdate;
                    double TongSoNgay = Time.TotalHours;
                    dt.Select(string.Format("[No_TimeKeeping] = '{0}'", keyValue)).ToList<DataRow>().ForEach(r => { r["total_keeping"] = TongSoNgay.ToString(); });
                }
                else
                {
                    dt.Select(string.Format("[No_TimeKeeping] = '{0}'", keyValue)).ToList<DataRow>().ForEach(r => { r[header_] = value; });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void gv_main_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                string ID_ = gv_main.GetRowCellValue(e.RowHandle, "ID") == null ? "" : gv_main.GetRowCellValue(e.RowHandle, "ID").ToString();
                if (ID_ == "")
                {
                    e.Appearance.BackColor = Color.Yellow;
                }

                e.HighPriority = true;
            }
        }

        private void gv_main_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            valueBeforeEditing = "";
            GridView view = sender as GridView;
            string header_ = view.FocusedColumn.FieldName.ToString();
            if (header_ == "enddate_keeping" || header_ == "startdate_keeping")
            {
                _ = (int)view.GetRowCellValue(view.FocusedRowHandle, "No_TimeKeeping");
                valueBeforeEditing = view.EditingValue.ToString();
            }
        }
    }
}
