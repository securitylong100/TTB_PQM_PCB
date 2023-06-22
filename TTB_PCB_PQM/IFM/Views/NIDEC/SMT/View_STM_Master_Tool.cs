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
using System.Drawing;
using DevExpress.XtraEditors.Repository;
//using IFM.Common.OnGrid;

namespace IFM.Views.NIDEC.SMT
{
    public partial class View_STM_Master_Tool : RibbonForm
    {
        private readonly DkGridView<m_user> _gridData;
        private readonly SystemGetUserQuery _refreshQuery = new SystemGetUserQuery();

        public View_STM_Master_Tool()
        {
            InitializeComponent();
            _gridData = new UserGridView(gv_data);
            _gridData.AfterAddRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_user;
                item.enum_status = ModelStatus.FakeAdd;
                gv_data.RefreshRow(e);
            };
            _gridData.AfterEditRow += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_user;
                item.enum_status = ModelStatus.FakeEdit;
                gv_data.RefreshRow(e);
            };
            _gridData.RowDeleted += (obj, e) =>
            {
                var item = gv_data.GetRow(e) as m_user;
                item.enum_status = ModelStatus.FakeDelete;
                gv_data.RefreshRow(e);
            };
            gridcontrolview();
            IFM.Common.OnGrid.Functions fn = new Common.OnGrid.Functions();
            fn.getcombox(gv_data, gc_data);
        }
        private void gridcontrolview()
        {
            RepositoryItemComboBox riComboBox = new RepositoryItemComboBox();
            riComboBox.Items.Add(IfmLanguage.En);
            riComboBox.Items.Add(IfmLanguage.Vi);
            gc_data.RepositoryItems.Add(riComboBox);
            gv_data.Columns["user_lang"].ColumnEdit = riComboBox;
            gv_data.CustomDrawCell += Gv_data_CustomDrawCell;
        }
        
        private void Gv_data_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var item = gv_data.GetRow(e.RowHandle) as m_user;
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
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _gridData.RefreshData(_refreshQuery);
        }
        internal class UserGridView : DkGridView<m_user>
        {
            public UserGridView(GridView gridView) : base(gridView, ClsSession.App.DbServices)
            {
            }
        }
        private void bbiSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
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
                    _gridData.UpdateDB(new SystemUpdateUserCommand(_gridData.LstModifired.ToArray()));
                }
                else if (dialogResult == DialogResult.No)
                { 
                }
                _gridData.RefreshData(_refreshQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void bbiNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.Add();
        }
        private void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gc_data.ShowRibbonPrintPreview();
        }
        private void bbiRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.OnLoad(e);
            _gridData.RefreshData(_refreshQuery);
        }
        private void bbiEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.Edit();
        }
        private void bbiDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            _gridData.Delete();

        }
    }
}