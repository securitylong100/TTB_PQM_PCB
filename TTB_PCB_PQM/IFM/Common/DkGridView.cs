using DevExpress.XtraGrid.Views.Grid;
using IFM.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IFM.Common
{
    public abstract class DkGridView<T> where T : class
    {
        private readonly GridView _gvData;
        protected readonly IDkDispatcher Dispatcher;

        public List<T> LstModifired { get; }
        public DataState RowState { get; set; }
        public BindingList<T> Datasource { get; set; }

        public event EventHandler<int> AfterAddRow;
        public event EventHandler<int> AfterEditRow;
        public event EventHandler<int> BeforeAddRow;
        public event EventHandler<int> BeforeEditRow;
        public event EventHandler<int> RowDeleted;

        public DkGridView(GridView gridView, IDkDispatcher dispatcher)
        {
            _gvData = gridView;
            Dispatcher = dispatcher;
            RowState = DataState.None;
            LstModifired = new List<T>();
            _gvData.OptionsBehavior.EditingMode = GridEditingMode.EditForm;
            _gvData.EditFormHidden += (obj, e) =>
            {
                if (e.Result == EditFormResult.Update)
                {
                    LstModifired.Add((T)_gvData.GetRow(e.RowHandle));
                    switch (RowState)
                    {
                        case DataState.New:
                            AfterAddRow?.Invoke(this, e.RowHandle);
                            break;
                        case DataState.Edit:
                            AfterEditRow?.Invoke(this, e.RowHandle);
                            break;
                        case DataState.None:
                        default:
                            break;
                    }
                }
                RowState = DataState.None;
                _gvData.OptionsBehavior.Editable = false;
                _gvData.OptionsBehavior.ReadOnly = true;
            };
            _gvData.InitNewRow += (obj, e) =>
            {
                RowState = DataState.New;
                _gvData.FocusedRowHandle = e.RowHandle;
                _gvData.OptionsBehavior.Editable = true;
                _gvData.OptionsBehavior.ReadOnly = false;
                BeforeAddRow?.Invoke(this, _gvData.FocusedRowHandle);
                _gvData.ShowEditForm();
            };
        }

        public void Add()
        {
            _gvData.AddNewRow();
        }

        public void Edit()
        {
            RowState = DataState.Edit;
            _gvData.OptionsBehavior.Editable = true;
            _gvData.OptionsBehavior.ReadOnly = false;
            _gvData.ShowEditForm();
            BeforeEditRow?.Invoke(this, _gvData.FocusedRowHandle);
        }

        public void Delete()
        {
            RowState = DataState.Delete;
            LstModifired.Add((T)_gvData.GetRow(_gvData.FocusedRowHandle));
            RowDeleted.Invoke(this, _gvData.FocusedRowHandle);
        }

        public virtual void UpdateDB(IDkCommand command)
        {
            Dispatcher.Execute(command);
        }

        public virtual void RefreshData(IDkQuery<IEnumerable<T>> query)
        {
            var items = Dispatcher.Query(query).ToList();
            if (items != null)
            {
                Datasource = new BindingList<T>(items);
                _gvData.GridControl.DataSource = Datasource;
                _gvData.BestFitColumns();
            }
        }

        public enum DataState
        {
            None = 0,
            New = 1,
            Edit = 2,
            Delete = 3
        }
    }
}
