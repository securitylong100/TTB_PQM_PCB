using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout.Modes;
using IFM.Class;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Interfaces;
using System;
using System.Windows.Forms;
using IFM.DataAccess.Models.NIDEC;
using IFM.DataAccess.Models;


namespace IFM.Common.OnGrid
{
   

    public class OnGrid_CQRS
    {
        public static int ID_ = 0;
        public static IDkCommand command_;
        public void MouseRight(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.MenuType == GridMenuType.Row)
            {
                int rowHandle = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();
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
                    if (ID_ > 0)
                    {
                        ClsSession.App.DbServices.Execute(command_);
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
