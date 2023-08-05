using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Models;
using IFM.DataAccess.Models.SYS;
using System;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Windows.Forms;
using IFM.Class;
using System.Data;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace IFM.Views.NIDEC.PQM
{
    public partial class View_PQM_Viewer : RibbonForm
    {
        DataTable dt;

        public View_PQM_Viewer()
        {
            InitializeComponent();

        }

        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }
        void BbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiLoad_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiExportCSV_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        //****************************************************************************************************************//
        //                                            LOAD COMBOBOX MODEL                                                 //
        //****************************************************************************************************************//
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                string sql = @"select distinct model from procinsplink order by model asc";
                pgsqlconnection_NewDB con = new pgsqlconnection_NewDB();
                con.getComboBoxData(sql, ref cmbModel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }
        //****************************************************************************************************************//
        //                                            LOAD INSPECT TREEVIEW                                               //
        //****************************************************************************************************************//
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                StringBuilder sqltreeview = new StringBuilder();
                sqltreeview.Append("select process ,inspect , inspectname from  procinsplink   where 1=1");
                sqltreeview.Append(" and model = '" + cmbModel.Text + "' ");
                sqltreeview.Append(@"order by process asc");
                //get to dt
                pgsqlconnection_NewDB con = new pgsqlconnection_NewDB();
                con.sqlDataAdapterFillDatatable(sqltreeview.ToString(), ref dt);
                if (dt.Rows.Count < 1) return;
                BindTreeView(dt, trInspect);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void BindTreeView(DataTable dataTable, TreeView tv)
        {
            try
            {
                int i = 0;
                tv.Nodes.Clear();
                while (i < dataTable.Rows.Count)
                {
                    DataRow row = dataTable.Rows[i];
                    //Get the department
                    string department = row.Field<string>(0) ?? "";
                    // Add department Node
                    TreeNode departmentNode = tv.Nodes.Add(department);
                    while (i < dataTable.Rows.Count && row.Field<string>(0) == department)
                    {
                        // Get the Name
                        string name = (row.Field<string>(1) + ": " + row.Field<string>(2)) ?? "";
                        //Add name to department Node
                        departmentNode.Nodes.Add(name);
                        while (i < dataTable.Rows.Count && row.Field<string>(0) == department && name == row.Field<string>(1) + ": " + row.Field<string>(2))
                        {
                            if (++i < dataTable.Rows.Count)
                                row = dataTable.Rows[i];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btn_gettreeview_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count < 1) return;
            BindTreeView(dt, trInspect);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = "";
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofCSV = new OpenFileDialog();
            ofCSV.Title = "LOAD SERIAL NUMBER FROM CSV FILE";
            ofCSV.Filter = "csv file(*.csv)|*.csv|text file(*.txt)|*.txt|All file(*.*)|*.*";
            if (ofCSV.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = ofCSV.FileName;
            }

        }
    }
}