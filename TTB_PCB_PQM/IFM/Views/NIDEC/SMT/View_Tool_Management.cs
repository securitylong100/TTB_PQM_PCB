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

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_Tool_Management : RibbonForm
    {
        private readonly DkGridView<m_user_role> _gridData;
        private readonly SystemGetUserRolesQuery _refreshQuery = new SystemGetUserRolesQuery();
      //  private readonly SystemGetDistinctUserQuery _getUser = new SystemGetDistinctUserQuery();

        public View_Tool_Management()
        {
            InitializeComponent();
            _gridData = new UserRolesGridView(gv_data);
            _gridData.AfterAddRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_user_role;
                item.enum_status = ModelStatus.FakeAdd;
                gv_data.RefreshRow(e);
            };
            _gridData.AfterEditRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_user_role;
                item.enum_status = ModelStatus.FakeEdit;
                gv_data.RefreshRow(e);
            };
            _gridData.RowDeleted += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_user_role;
                item.enum_status = ModelStatus.FakeDelete;
                gv_data.RefreshRow(e);
            };
            gridcontrolview();
            IFM.Common.OnGrid.Functions fn = new Common.OnGrid.Functions();
            fn.getcombox(gv_data, gc_data);
        }
        private void gridcontrolview()
        {
            RepositoryItemComboBox riComboBox;
            var users = ClsSession.App.DbServices.Query(new SystemGetDistinctUserQuery());
            var assign_code = ClsSession.App.DbServices.Query(new SystemGetDistinctViewsQuery());
            riComboBox = new RepositoryItemComboBox();
            foreach (var assign in assign_code)
            {
                riComboBox.Items.Add(assign.assign_code);
            }
            gc_data.RepositoryItems.Add(riComboBox);
            gv_data.Columns["assign_code"].ColumnEdit = riComboBox;

            riComboBox = new RepositoryItemComboBox();
            foreach (var user in users)
            {
                riComboBox.Items.Add(user.user_cd);
            }
            gc_data.RepositoryItems.Add(riComboBox);
            gv_data.Columns["user_cd"].ColumnEdit = riComboBox;

            gv_data.CustomDrawCell += Gv_data_CustomDrawCell;           
        }

        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var item = gv_data.GetRow(e.RowHandle) as m_user_role;
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
            foreach (var item in _gridData.LstModifired)
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
                if (string.IsNullOrWhiteSpace(item.creator))
                {
                    item.creator = ClsSession.App.UserName;
                }
                item.updater = ClsSession.App.UserName;
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure to change the data ?", "Save Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _gridData.UpdateDB(new SystemUpdateUserRolesCommand(_gridData.LstModifired.ToArray()));
            }
            else if (dialogResult == DialogResult.No)
            {              
            }
            _gridData.RefreshData(_refreshQuery);
        }

        private void BbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.Delete();
        }
        private void BbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.RefreshData(_refreshQuery);
        }
    }
  
    internal class UserRolesGridView : DkGridView<m_user_role>
    {
        public UserRolesGridView(GridView gridView) : base(gridView, ClsSession.App.DbServices)
        {
        }
    }
}