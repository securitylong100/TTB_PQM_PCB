using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common.OnGrid;
using IFM.DataAccess.Extensions;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFM.Views.SYS
{
    public partial class view_SYS_01_001 : Form
    {

        public view_SYS_01_001()
        {
            InitializeComponent();
        }
        DataTable dt;
        readonly string sqlusername  = @"select user_name,user_cd from m_user where user_status ='1'
                            and user_role >= (select user_role from m_user where user_name = '" + ClsSession.App.UserName + "')";
        readonly string sqldelete = "delete from m_user where 1=1  and ";
        private void view_SYS_01_001_Load(object sender, EventArgs e)
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
                sqlload.Append("select * from m_user where 1=1 ");
                if (chb_user.Checked == false)
                {
                    sqlload.Append(" and  user_name = '" + cbm_username.SelectedItem + "' ");
                }
                sqlload.Append(" and user_role >= (select user_role from m_user where user_name = '" + ClsSession.App.UserName + "')");
                sqlload.Append(" order by user_name desc");
                con.sqlDataAdapterFillDatatable(sqlload.ToString(), ref dt);
                gc_main.DataSource = dt;
                //add combobox
                GetComboxIntoGrid(cbm_username, "user_name");

                //add check box
                var richeckbox = new RepositoryItemCheckEdit();
                //richeckbox.ValueChecked = "True";
                //gc_main.RepositoryItems.Add(richeckbox);
                //gv_main.Columns["money_insurance"].ColumnEdit = richeckbox;
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
        private void btn_Search_Click(object sender, EventArgs e)
        {
            LoadData(false);
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
                   

                }
                else
                {
                    int status_ = rowdt["user_status"].ToString() == "True" ? 1 : 0;
                    string pass_encryt = De_Encrypt.Encrypt(rowdt["user_pass"].ToString());
                    StringBuilder sqlupdate = new StringBuilder();
                    sqlupdate.Append(@"UPDATE m_user set ");
                    sqlupdate.Append("user_cd = '" + rowdt["user_cd"].ToString() + "',");
                    sqlupdate.Append("user_name = '" + rowdt["user_name"].ToString() + "',");
                    sqlupdate.Append("user_pass = '" + pass_encryt + "',");
                    sqlupdate.Append("user_status = '" + status_.ToString() + "',");
                    sqlupdate.Append("user_comments = '" + rowdt["user_comments"].ToString() + "',");
                    sqlupdate.Append("user_role = '" + rowdt["user_role"].ToString() + "',");
                    sqlupdate.Append("user_email = '" + rowdt["user_email"].ToString() + "',");
                    sqlupdate.Append("user_permision = '" + rowdt["user_permision"].ToString() + "'");
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
