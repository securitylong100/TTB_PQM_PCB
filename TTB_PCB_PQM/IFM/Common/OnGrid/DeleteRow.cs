using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Class;
using System;
using System.Windows.Forms;
namespace IFM.Common.OnGrid
{
    public class DeleteRow
    {
        string sqldelete_ = "";
        //nhan phim delete
        public void keydownDelete(object sender, KeyEventArgs e, string sql)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Delete this row?", "Confirm operation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    GridView view = sender as GridView;
                    if (view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() != "")
                    {
                        //key delete ID
                        int keyValue = (int)view.GetRowCellValue(view.FocusedRowHandle, "ID");
                        view.DeleteRow(view.FocusedRowHandle);
                        //thuc hien delete ID
                        mysqlconnection con = new mysqlconnection();
                        con.sqlExecuteScalarString(sql + "ID = " + keyValue);
                    }
                    else
                    {
                        view.DeleteRow(view.FocusedRowHandle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        //chuot phai delete
        public void MouseRight(object sender, PopupMenuShowingEventArgs e, string sql)
        {
            GridView view = sender as GridView;
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();
                sqldelete_ = sql;
                e.Menu.Items.Add(CreateSubMenuRows(view, rowHandle));
            }
        }
        DXMenuItem CreateSubMenuRows(GridView view, int rowHandle)
        {
            DXSubMenuItem subMenu = new DXSubMenuItem("Rows");
            string deleteRowsCommandCaption;
            if (view.IsGroupRow(rowHandle))
                deleteRowsCommandCaption = "&Delete rows in this group";
            else
                deleteRowsCommandCaption = "&Delete this row";
            DXMenuItem menuItemDeleteRow = new DXMenuItem(deleteRowsCommandCaption, new EventHandler(OnDeleteRowClick))
            {
                Tag = new RowInfo(view, rowHandle),
                Enabled = view.IsDataRow(rowHandle) || view.IsGroupRow(rowHandle)
            };
            subMenu.Items.Add(menuItemDeleteRow);
            return subMenu;
        }
        void OnDeleteRowClick(object sender, EventArgs e)
        {
            DXMenuItem menuItem = sender as DXMenuItem;
            try
            {
                if (menuItem.Tag is RowInfo ri)
                {
                    string message = menuItem.Caption.Replace("&", "");
                    if (XtraMessageBox.Show(message + " ?", "Confirm operation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    //key delete
                    if (ri.View.GetRowCellValue(ri.View.FocusedRowHandle, "ID").ToString() != "")
                    {

                        int keyValue = (int)ri.View.GetRowCellValue(ri.View.FocusedRowHandle, "ID");
                        ri.View.DeleteRow(ri.RowHandle);
                        //thuc hien delete ID
                        mysqlconnection con = new mysqlconnection();
                        con.sqlExecuteScalarString(sqldelete_ + "ID = " + keyValue);
                    }
                    else
                    {
                        ri.View.DeleteRow(ri.RowHandle);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        class RowInfo
        {
            public RowInfo(GridView view, int rowHandle)
            {
                RowHandle = rowHandle;
                View = view;
            }
            public GridView View;
            public int RowHandle;
        }

    }
}
