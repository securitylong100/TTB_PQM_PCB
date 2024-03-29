﻿using DevExpress.XtraBars;
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
using System.IO;

namespace IFM.Views.NIDEC.PQM
{

    public partial class View_PQM_Viewer : RibbonForm
    {
        DataTable dt;
        string sernolist;
        string inspectlist;
        List<string> tem_inspectlist = new List<string>();
        public View_PQM_Viewer()
        {
            InitializeComponent();

        }

        void BbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_data.ShowRibbonPrintPreview();
        }
        private void bbiSearch_ItemClick(object sender, ItemClickEventArgs e)
        {

            GetSernoList();
            GetInspectList();
            GetDataTable();

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
        //****************************************************************************************************************//
        //                                            LOAD TXT BARCODE                                                    //
        //****************************************************************************************************************//
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            try
            {
                txtURL.Text = "";
                txtBarcode.Text = "";
                OpenFileDialog ofCSV = new OpenFileDialog();
                ofCSV.Title = "LOAD SERIAL NUMBER FROM CSV FILE";
                ofCSV.Filter = "csv file(*.csv)|*.csv|text file(*.txt)|*.txt|All file(*.*)|*.*";
                if (ofCSV.ShowDialog() == DialogResult.OK)
                {
                    txtURL.Text = ofCSV.FileName;
                }
                if (txtURL.Text == "") return;
                var sernolist = (from r in ConvertCSVtoDataTable(txtURL.Text).AsEnumerable()
                                 select r[0]).Distinct().ToList();
                foreach (var serno_cd in sernolist)
                {
                    txtBarcode.AppendText(serno_cd.ToString() + "\r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {

            DataTable dtcsv = new DataTable();
            try
            {
                using (StreamReader sr = new StreamReader(strFilePath))
                {
                    string[] headers = sr.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dtcsv.Columns.Add(header);
                    }
                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        DataRow dr = dtcsv.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i];
                        }
                        dtcsv.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            return dtcsv;
        }
        //****************************************************************************************************************//
        //                                            GET TABLE GRIDCONTROL                                                  //
        //****************************************************************************************************************//
        private void GetSernoList()
        {
            try
            {
                sernolist = "";
                if (txtBarcode.Lines.Length > 0)
                {
                    sernolist = sernolist + "'" + txtBarcode.Lines[0] + "'";
                    foreach (string s in txtBarcode.Lines)
                        if (s != "")
                            sernolist = sernolist + ",'" + s + "'";
                    bsiRecordsCount.Caption = txtBarcode.Lines.Count().ToString() + " rows";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void SelectedNode(TreeNodeCollection Root)
        {
            try
            {
                foreach (TreeNode node in Root)
                {
                    if (node.Checked)
                    {
                        if (node.Text.Contains(":") == true)
                        {
                            tem_inspectlist.Add("'" + node.Text.Substring(0, node.Text.IndexOf(":")) + "'");
                        }
                        else
                        {
                            tem_inspectlist.Add("'" + node.Text + "'");
                        }

                    }
                    if (node.Nodes.Count > 0)
                        SelectedNode(node.Nodes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }

        private void GetInspectList()
        {
            try
            {
                inspectlist = "";
                tem_inspectlist = new List<string>();
                SelectedNode(trInspect.Nodes);
                tem_inspectlist = tem_inspectlist.Distinct().ToList();
                foreach (string i in tem_inspectlist)
                {
                    if (tem_inspectlist.IndexOf(i) == 0)
                    {
                        inspectlist = inspectlist + i;
                    }
                    else
                    {
                        inspectlist = inspectlist + "," + i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void GetDataTable()
        {
            try
            {
                gc_data.Refresh();
                gc_data.DataSource = null;
                gv_data.Columns.Clear();
                string tablename = cmbModel.Text + dtDatef.Value.ToString("yyyyMM");
                dt = new DataTable();
                DataTable pivot = new DataTable();
                DataTable InspectDataTable = new DataTable();
                DataTable SernoDataTable = new DataTable();
                StringBuilder SQLInspectDataTable = new StringBuilder();
                StringBuilder SQLSernoDataTable = new StringBuilder();
                //pivot.Clear();
                //dt.Clear();

                //SQLInspectDataTable
                SQLInspectDataTable.Append(" select serno, inspectdate, inspect, inspectdata, judge ");
                SQLInspectDataTable.Append("from " + tablename + "data where 1 = 1");
                SQLInspectDataTable.Append(" and inspect in (" + inspectlist.ToString() + ")");
                SQLInspectDataTable.Append("");
                if (txtBarcode.Text != "")
                {
                    if (rad_lot.Checked == true)
                        SQLInspectDataTable.Append(@"and lot in ("+ sernolist + @") 
                                                    and inspectdate in
                                                    (
                                                    select b.date_ from
                                                    (select inspect, lot, max(inspectdate) as date_, inspect from "+ tablename + @"data 
                                                    where inspect in (" + inspectlist.ToString() + @")
                                                    and lot in ("+ sernolist + @")
                                                     group by inspect, lot
                                                    ) b
                                                    ) ");
                    else
                        SQLInspectDataTable.Append(@"and serno in (" + sernolist + @") 
                                                    and inspectdate in
                                                    (
                                                    select b.date_ from
                                                    (select inspect, serno, max(inspectdate) as date_, inspect from " + tablename + @"data 
                                                    where inspect in (" + inspectlist.ToString() + @")
                                                    and serno in (" + sernolist + @")
                                                     group by inspect, serno
                                                    ) b
                                                    ) ");
                }
                else
                {
                    SQLInspectDataTable.Append(" and inspectdate >= '" + dtDatef.Value.ToString("yyyy-MM-dd HH:mm:ss")
                        + "' and inspectdate <= '" + dtDatef.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                }
                SQLInspectDataTable.Append(" order by inspect asc, inspectdate asc");

                //SQLInspectDataTable.Append("select serno, inspectdate, inspect, inspectdata, judge from "
                //+ tablename + "data where inspect in (" + inspectlist.ToString() + ")");
                //if (txtBarcode.Text != "")
                //{
                //    if (rad_lot.Checked == true)
                //        SQLInspectDataTable.Append(" and lot in (" + sernolist + ")");
                //    else
                //        SQLInspectDataTable.Append(" and serno in (" + sernolist + ")");
                //}
                //else
                //{
                //    SQLInspectDataTable.Append(" and inspectdate >= '" + dtDatef.Value.ToString("yyyy-MM-dd HH:mm:ss")
                //        + "' and inspectdate <= '" + dtDatef.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                //}
                //SQLInspectDataTable.Append(" order by inspect asc, inspectdate asc");

                pgsqlconnection_NewDB con = new pgsqlconnection_NewDB();
                con.sqlDataAdapterFillDatatable(SQLInspectDataTable.ToString(), ref InspectDataTable);

                //SQLSernoDataTable
                SQLSernoDataTable.Append("select serno, lot, model, site, factory, line, process, inspectdate, tjudge from "
                    + tablename + " where 1=1");
                if (sernolist.Length > 0)
                {
                    if (rad_lot.Checked == true)
                        SQLSernoDataTable.Append("  and lot in (" + sernolist + ")");
                    else
                        SQLSernoDataTable.Append(" and serno in (" + sernolist + ")");
                }
                else
                {
                    SQLSernoDataTable.Append(" and inspectdate >=  '" + dtDatef.Value.ToString("yyyy-MM-dd HH:mm:ss")
                        + "' and inspectdate <= '" + dtDatef.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                }
                //if (!string.IsNullOrEmpty(InVo.Process))
                //{
                //    SQLSernoDataTable.Append(" and process ='" + InVo.Process + "'");
                //}
                SQLSernoDataTable.Append("order by inspectdate asc");
                con.sqlDataAdapterFillDatatable(SQLSernoDataTable.ToString(), ref SernoDataTable);
                pivot = LinQ_Class.Pivot(InspectDataTable, InspectDataTable.Columns["inspect"]
                       , InspectDataTable.Columns["inspectdata"], InspectDataTable.Columns["judge"]);
                dt = LinQ_Class.Joined(SernoDataTable, pivot);
                gc_data.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
    }

}
