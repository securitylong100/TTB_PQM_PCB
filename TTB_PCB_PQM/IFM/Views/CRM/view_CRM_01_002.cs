using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common;
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
    public partial class view_CRM_01_002 : Form
    {

        public view_CRM_01_002()
        {
            InitializeComponent();
        }
        DataTable dt;
        readonly string sqlusername = "select user_name, user_cd from m_user  order by user_cd";
        readonly string sqldelete = "delete from m_salary where 1=1  and ";
        private void view_CRM_01_002_Load(object sender, EventArgs e)
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
                { cbm_usercd.Items.Add(x1); }
                var y = (from r in dt.AsEnumerable()
                         select r["user_name"]).Distinct().ToList();
                foreach (var y1 in y)
                { cbm_username.Items.Add(y1); }
                cbm_username.SelectedItem = ClsSession.App.UserName;
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
                sqlload.Append("select * from m_salary where 1=1 ");
                if (chb_user.Checked == false)
                {
                    sqlload.Append(" and  user_name = '" + cbm_username.SelectedItem + "' ");
                }
                sqlload.Append(" order by user_name desc");
                con.sqlDataAdapterFillDatatable(sqlload.ToString(), ref dt);
                gc_main.DataSource = dt;
                //add combobox
                GetComboxIntoGrid(cbm_username, "user_name");
                //add togo switch
                //var riToggleSwitch = new RepositoryItemToggleSwitch();
                //riToggleSwitch.OffText = "0";
                //riToggleSwitch.OnText = "1";
                //riToggleSwitch.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
                //gc_main.RepositoryItems.Add(riToggleSwitch);
                //gv_main.Columns["money_insurance"].ColumnEdit = riToggleSwitch;

                //add check box
                var richeckbox = new RepositoryItemCheckEdit
                {
                    ValueChecked = "True"
                };
                gc_main.RepositoryItems.Add(richeckbox);
                gv_main.Columns["money_insurance"].ColumnEdit = richeckbox;
                lbl_rowscount.Text = "Rows Count: " + gv_main.RowCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void chb_user_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_user.Checked == true)
            {
                cbm_username.Enabled = false;
                cbm_usercd.Enabled = false;
            }
            else
            {
                cbm_username.Enabled = true;
                cbm_usercd.Enabled = true;
            }
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
        private void cbm_usercd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class.mysqlconnection con = new Class.mysqlconnection();
            cbm_username.Text = con.sqlExecuteScalarString("select distinct user_name from m_user where user_cd = '" + cbm_usercd.SelectedItem + "'");
            LoadData(false);
        }
        private void cbm_username_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class.mysqlconnection con = new Class.mysqlconnection();
            cbm_usercd.Text = con.sqlExecuteScalarString("select distinct user_cd from m_user where user_name = '" + cbm_username.SelectedItem + "'");
            LoadData(false);
        }
        bool checkcondition()
        {
            if (cbm_username.SelectedItem == null || cbm_usercd.SelectedItem == null || calc_Basicsalary.Text == "0" || calc_Basicsalary.Text == "")
            {
                MessageBox.Show("Chưa chọn đầy đủ Thông Tin", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            LoadData(false);
            try
            {
                if (checkcondition())
                {
                    DataRow row = dt.NewRow();
                    row["user_name"] = cbm_username.Text;
                    row["basicsalary_month"] = calc_Basicsalary.Text;
                    row["bonussalary"] = calc_bonussalary.Text;
                    row["money_insurance"] = chb_insurance.Checked == true ? "True" : "False";
                    row["u_update"] = "";
                    row["d_update"] = DateTime.Now;
                    row["u_create"] = ClsSession.App.UserName;
                    row["d_create"] = DateTime.Now;
                    dt.Rows.Add(row);
                    savedb();
                    // LoadData(false);
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
            if (dt.Rows.Count == 0) return;
            Class.mysqlconnection con = new Class.mysqlconnection();
            //Functions function = new Functions();
            foreach (DataRow rowdt in dt.Rows)
            {
                if (rowdt["ID"].ToString() == "")
                {
                    StringBuilder sqlinsert = new StringBuilder();
                    sqlinsert.Append(@"INSERT INTO m_salary
                                    (user_name, basicsalary_month, bonussalary, money_insurance, u_update, d_update, u_create, d_create)
                                    VALUES("
                                    );

                    sqlinsert.Append("'" + rowdt["user_name"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["basicsalary_month"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["bonussalary"].ToString() + "',");
                    sqlinsert.Append("'" + rowdt["money_insurance"].ToString() + "',");
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
                    sqlupdate.Append(@"UPDATE m_salary set ");
                    sqlupdate.Append("user_name = '" + rowdt["user_name"].ToString() + "',");
                    sqlupdate.Append("basicsalary_month = '" + rowdt["basicsalary_month"].ToString() + "',");
                    sqlupdate.Append("bonussalary = '" + rowdt["bonussalary"].ToString() + "',");
                    sqlupdate.Append("money_insurance = '" + rowdt["money_insurance"].ToString() + "',");
                    sqlupdate.Append("u_update = '" + ClsSession.App.UserName + "',");
                    sqlupdate.Append("d_update = CURRENT_TIMESTAMP");
                    sqlupdate.Append(" where 1=1 and ID = " + rowdt["ID"].ToString() + "");
                    con.sqlExecuteScalarString(sqlupdate.ToString());
                }
            }
            MessageBox.Show("Action Successful", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData(false);
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
            DeleteRow CallDeleteRow = new DeleteRow();
            CallDeleteRow.keydownDelete(sender, e, sqldelete);
            //   LoadData(false);
        }
        private void gv_main_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            DeleteRow CallDeleteRow = new DeleteRow();
            CallDeleteRow.MouseRight(sender, e, sqldelete);
            // LoadData(false);
        }
    }
}
