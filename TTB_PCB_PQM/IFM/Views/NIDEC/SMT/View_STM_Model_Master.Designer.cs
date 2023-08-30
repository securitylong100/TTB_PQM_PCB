﻿namespace IFM.Views.NIDEC.SMT
{
    partial class View_STM_Model_Master
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_STM_Model_Master));
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bar_status = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.bsiRecordsCount = new DevExpress.XtraBars.BarStaticItem();
            this.gv_data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.model_cd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.model_columns = new DevExpress.XtraGrid.Columns.GridColumn();
            this.model_rows = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_data = new DevExpress.XtraGrid.GridControl();
            this.active_status = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.MergeOrder = 0;
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiSave, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 20;
            this.bbiSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.Image")));
            this.bbiSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.LargeImage")));
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiSave_ItemClick);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiRefresh);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tasks";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "New";
            this.bbiNew.Id = 16;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.Name = "bbiNew";
            this.bbiNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiNew_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 17;
            this.bbiEdit.ImageOptions.ImageUri.Uri = "Edit";
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 18;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiDelete_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 19;
            this.bbiRefresh.ImageOptions.ImageUri.Uri = "Refresh";
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiRefresh_ItemClick);
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiPrintPreview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Print and Export";
            // 
            // bbiPrintPreview
            // 
            this.bbiPrintPreview.Caption = "Print Preview";
            this.bbiPrintPreview.Id = 14;
            this.bbiPrintPreview.ImageOptions.ImageUri.Uri = "Preview";
            this.bbiPrintPreview.Name = "bbiPrintPreview";
            this.bbiPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbiPrintPreview_ItemClick);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.bbiPrintPreview,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiRefresh,
            this.bbiSave});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 21;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(917, 79);
            this.ribbonControl.StatusBar = this.bar_status;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bar_status
            // 
            this.bar_status.ItemLinks.Add(this.bsiRecordsCount);
            this.bar_status.Location = new System.Drawing.Point(0, 447);
            this.bar_status.Name = "bar_status";
            this.bar_status.Ribbon = this.ribbonControl;
            this.bar_status.Size = new System.Drawing.Size(917, 31);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // gv_data
            // 
            this.gv_data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gv_data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.model_cd,
            this.model_columns,
            this.model_rows,
            this.active_status,
            this.create_time});
            this.gv_data.GridControl = this.gc_data;
            this.gv_data.Name = "gv_data";
            this.gv_data.OptionsEditForm.EditFormColumnCount = 2;
            this.gv_data.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gv_data.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_data_PopupMenuShowing);
            // 
            // id
            // 
            this.id.Caption = "ID";
            this.id.FieldName = "ID";
            this.id.Name = "id";
            this.id.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.id.Visible = true;
            this.id.VisibleIndex = 0;
            // 
            // model_cd
            // 
            this.model_cd.Caption = "Model Code";
            this.model_cd.FieldName = "model_cd";
            this.model_cd.Name = "model_cd";
            this.model_cd.Visible = true;
            this.model_cd.VisibleIndex = 1;
            // 
            // model_columns
            // 
            this.model_columns.Caption = "Model Columns";
            this.model_columns.FieldName = "model_columns";
            this.model_columns.Name = "model_columns";
            this.model_columns.Visible = true;
            this.model_columns.VisibleIndex = 2;
            // 
            // model_rows
            // 
            this.model_rows.Caption = "Model Rows";
            this.model_rows.FieldName = "model_rows";
            this.model_rows.Name = "model_rows";
            this.model_rows.Visible = true;
            this.model_rows.VisibleIndex = 3;
            // 
            // create_time
            // 
            this.create_time.Caption = "Create Time";
            this.create_time.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.create_time.FieldName = "create_time";
            this.create_time.Name = "create_time";
            this.create_time.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.create_time.Visible = true;
            this.create_time.VisibleIndex = 5;
            // 
            // gc_data
            // 
            this.gc_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_data.Location = new System.Drawing.Point(0, 79);
            this.gc_data.MainView = this.gv_data;
            this.gc_data.MenuManager = this.ribbonControl;
            this.gc_data.Name = "gc_data";
            this.gc_data.Size = new System.Drawing.Size(917, 368);
            this.gc_data.TabIndex = 2;
            this.gc_data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_data});
            // 
            // active_status
            // 
            this.active_status.Caption = "Active Status";
            this.active_status.FieldName = "active_status";
            this.active_status.Name = "active_status";
            this.active_status.Visible = true;
            this.active_status.VisibleIndex = 4;
            // 
            // View_STM_Model_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 478);
            this.Controls.Add(this.gc_data);
            this.Controls.Add(this.bar_status);
            this.Controls.Add(this.ribbonControl);
            this.Name = "View_STM_Model_Master";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.bar_status;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiPrintPreview;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar bar_status;
        private DevExpress.XtraBars.BarStaticItem bsiRecordsCount;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_data;
        private DevExpress.XtraGrid.GridControl gc_data;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn model_cd;
        private DevExpress.XtraGrid.Columns.GridColumn model_columns;
        private DevExpress.XtraGrid.Columns.GridColumn model_rows;
        private DevExpress.XtraGrid.Columns.GridColumn create_time;
        private DevExpress.XtraGrid.Columns.GridColumn active_status;
    }
}