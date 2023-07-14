using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.CQRS.Queries.NIDEC.SMT;
using IFM.DataAccess.Models;
using IFM.DataAccess.Models.SYS;
using IFM.DataAccess.Models.NIDEC;
using System;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Windows.Forms;
using IFM.Common.OnGrid;
namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Tool_Master : RibbonForm
    {
        private readonly DkGridView<m_smt_tool> _gridData;
        private readonly SMTTool_GetMasterQuery _refreshQuery = new SMTTool_GetMasterQuery();


        public View_STM_Tool_Master()
        {
            InitializeComponent();
            _gridData = new UserRolesGridViewT(gv_data);
            _gridData.AfterAddRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_smt_tool;
                item.enum_status = ModelStatus.FakeAdd;
                gv_data.RefreshRow(e);
            };
            _gridData.AfterEditRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_smt_tool;
                item.enum_status = ModelStatus.FakeEdit;
                gv_data.RefreshRow(e);
            };
            _gridData.RowDeleted += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_smt_tool;
                item.enum_status = ModelStatus.FakeDelete;
                gv_data.RefreshRow(e);
            };
            gridcontrolview();
            gv_data.CustomDrawCell += Gv_data_CustomDrawCell;
            Functions fn = new Functions();
            fn.getcombox(gv_data, gc_data);
        }
        private void gridcontrolview()
        {
            RepositoryItemComboBox riComboBox;
       
            var model_code = ClsSession.App.DbServices.Query(new SMTToolGetDistinctModelQuery());
            riComboBox = new RepositoryItemComboBox();
            foreach (var model_ in model_code)
            {
                riComboBox.Items.Add(model_.model_cd);
            }
            gc_data.RepositoryItems.Add(riComboBox);
            gv_data.Columns["model_cd"].ColumnEdit = riComboBox;

        }
        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                var item = gv_data.GetRow(e.RowHandle) as m_smt_tool;
                if (item.enum_status >= 0)
                {
                    switch (item.enum_status)
                    {
                        case ModelStatus.New:
                        case ModelStatus.Modified:
                        case ModelStatus.Deleted:
                            break;
                        case ModelStatus.FakeAdd:
                            e.Appearance.BackColor = Color.Green;
                            break;
                        case ModelStatus.FakeEdit:
                            e.Appearance.BackColor = Color.Yellow;
                            break;
                        case ModelStatus.FakeDelete:
                            e.Appearance.BackColor = Color.Red;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        void BbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_data.ShowRibbonPrintPreview();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _gridData.RefreshData(_refreshQuery);
        }
        private void BbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.Add();
        }
        private void BbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.Edit();
        }
        private void BbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (var item in _gridData.LstModifired)
                {
                    if (item.enum_status >= 0)
                    {
                        switch (item.enum_status)
                        {
                            case ModelStatus.FakeAdd:
                                item.enum_status = ModelStatus.New;
                                break;
                            case ModelStatus.FakeEdit:
                                item.enum_status = ModelStatus.Modified;
                                break;
                            case ModelStatus.FakeDelete:
                                item.enum_status = ModelStatus.Deleted;
                                break;
                            case ModelStatus.New:
                            case ModelStatus.Modified:
                            case ModelStatus.Deleted:
                            default:
                                break;
                        }
                    }
                    if (string.IsNullOrWhiteSpace(item.creator))
                    {
                        item.creator = ClsSession.App.UserName;
                    }
                    item.updater = ClsSession.App.UserName;
                }
                DialogResult dialogResult = MessageBox.Show("Are you sure to change the data ?", "Save Data", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _gridData.UpdateDB(new SMTTool_UpdateMasterCommand(_gridData.LstModifired.ToArray()));
                }
                else if (dialogResult == DialogResult.No)
                {
                }
                _gridData.RefreshData(_refreshQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
        }
        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.Delete();
        }
        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.RefreshData(_refreshQuery);
        }
        private void gv_data_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            OnGrid_CQRS.ID_ = (int)view.GetRowCellValue(view.FocusedRowHandle, "ID");
            OnGrid_CQRS.command_ = new SMTTool_DeleteMasterCommand(OnGrid_CQRS.ID_);
            OnGrid_CQRS CallDeleteRow = new OnGrid_CQRS();
            CallDeleteRow.MouseRight(sender, e);
            _gridData.RefreshData(_refreshQuery);
        }
        internal class UserRolesGridViewT : DkGridView<m_smt_tool>
        {
            public UserRolesGridViewT(GridView gridView) : base(gridView, ClsSession.App.DbServices)
            {
            }
        }
    }
}