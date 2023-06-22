using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using IFM.Common;
using IFM.DataAccess.CQRS.Commands;
using IFM.DataAccess.CQRS.Queries;
using IFM.DataAccess.Models;
using IFM.DataAccess.Models.SYS;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using System.Drawing;

namespace IFM.Views.SYS
{
    public partial class view_sys_assign : RibbonForm
    {
        private readonly DkGridView<m_assignment> _gridData;
        private readonly SystemGetViewsQuery _refreshQuery = new SystemGetViewsQuery();

        public view_sys_assign()
        {
            InitializeComponent();
            _gridData = new AssignmentGridView(gv_data);
            _gridData.AfterAddRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_assignment;
                item.enum_status = ModelStatus.FakeAdd;
                gv_data.RefreshRow(e);
            };
            _gridData.AfterEditRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_assignment;
                item.enum_status = ModelStatus.FakeEdit;
                gv_data.RefreshRow(e);
            };
            _gridData.RowDeleted += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_assignment;
                item.enum_status = ModelStatus.FakeDelete;
                gv_data.RefreshRow(e);
            };
            gridcontrolview();
            IFM.Common.OnGrid.Functions fn = new Common.OnGrid.Functions();
            fn.getcombox(gv_data, gc_data);
        }
        private void gridcontrolview()
        {
            gv_data.CustomDrawCell += Gv_data_CustomDrawCell;
        }
        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var item = gv_data.GetRow(e.RowHandle) as m_assignment;
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
                    _gridData.UpdateDB(new SystemUpdateViewsCommand(_gridData.LstModifired.ToArray()));
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

        private void BbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_data.ShowRibbonPrintPreview();
        }
    }

    internal class AssignmentGridView : DkGridView<m_assignment>
    {
        public AssignmentGridView(GridView gridView) : base(gridView, ClsSession.App.DbServices)
        {
        }
    }
}