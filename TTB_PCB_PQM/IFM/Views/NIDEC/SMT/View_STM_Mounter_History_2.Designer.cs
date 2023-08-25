namespace IFM.Views.NIDEC.SMT
{
    partial class View_STM_Mounter_History_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_STM_Mounter_History_2));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
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
            this.gv_datamaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.model_cd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.item_list = new DevExpress.XtraGrid.Columns.GridColumn();
            this.create_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_datamaster = new DevExpress.XtraGrid.GridControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pn_background = new System.Windows.Forms.Panel();
            this.txt_lotno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbm_modelcd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_enter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gc_datahistory = new DevExpress.XtraGrid.GridControl();
            this.gv_datahistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bbiSearch = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_datamaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_datamaster)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pn_background.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_datahistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_datahistory)).BeginInit();
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
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSearch);
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
            this.bbiSave,
            this.bbiSearch});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 23;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Size = new System.Drawing.Size(1006, 79);
            this.ribbonControl.StatusBar = this.bar_status;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bar_status
            // 
            this.bar_status.ItemLinks.Add(this.bsiRecordsCount);
            this.bar_status.Location = new System.Drawing.Point(0, 477);
            this.bar_status.Name = "bar_status";
            this.bar_status.Ribbon = this.ribbonControl;
            this.bar_status.Size = new System.Drawing.Size(1006, 31);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // gv_datamaster
            // 
            this.gv_datamaster.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gv_datamaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.model_cd,
            this.item_list,
            this.create_time});
            this.gv_datamaster.GridControl = this.gc_datamaster;
            this.gv_datamaster.Name = "gv_datamaster";
            this.gv_datamaster.OptionsBehavior.Editable = false;
            this.gv_datamaster.OptionsBehavior.ReadOnly = true;
            this.gv_datamaster.OptionsEditForm.EditFormColumnCount = 2;
            this.gv_datamaster.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gv_datamaster.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_datamaster_RowStyle);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "id";
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            // 
            // model_cd
            // 
            this.model_cd.Caption = "Model Code";
            this.model_cd.FieldName = "model_cd";
            this.model_cd.Name = "model_cd";
            this.model_cd.Visible = true;
            this.model_cd.VisibleIndex = 1;
            // 
            // item_list
            // 
            this.item_list.Caption = "Item List";
            this.item_list.FieldName = "item_list";
            this.item_list.Name = "item_list";
            this.item_list.Visible = true;
            this.item_list.VisibleIndex = 2;
            // 
            // create_time
            // 
            this.create_time.Caption = "Create Time";
            this.create_time.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.create_time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.create_time.FieldName = "create_time";
            this.create_time.Name = "create_time";
            this.create_time.Visible = true;
            this.create_time.VisibleIndex = 3;
            // 
            // gc_datamaster
            // 
            this.gc_datamaster.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gc_datamaster.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gc_datamaster.Location = new System.Drawing.Point(3, 3);
            this.gc_datamaster.MainView = this.gv_datamaster;
            this.gc_datamaster.MenuManager = this.ribbonControl;
            this.gc_datamaster.Name = "gc_datamaster";
            this.gc_datamaster.Size = new System.Drawing.Size(494, 295);
            this.gc_datamaster.TabIndex = 2;
            this.gc_datamaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_datamaster});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pn_background, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 398);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pn_background
            // 
            this.pn_background.BackColor = System.Drawing.Color.Silver;
            this.pn_background.Controls.Add(this.txt_lotno);
            this.pn_background.Controls.Add(this.label2);
            this.pn_background.Controls.Add(this.cbm_modelcd);
            this.pn_background.Controls.Add(this.label6);
            this.pn_background.Controls.Add(this.btn_enter);
            this.pn_background.Controls.Add(this.label4);
            this.pn_background.Controls.Add(this.label3);
            this.pn_background.Controls.Add(this.label1);
            this.pn_background.Controls.Add(this.dtp_to);
            this.pn_background.Controls.Add(this.dtp_from);
            this.pn_background.Controls.Add(this.txt_barcode);
            this.pn_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_background.Location = new System.Drawing.Point(3, 3);
            this.pn_background.Name = "pn_background";
            this.pn_background.Size = new System.Drawing.Size(1000, 85);
            this.pn_background.TabIndex = 3;
            // 
            // txt_lotno
            // 
            this.txt_lotno.Location = new System.Drawing.Point(459, 12);
            this.txt_lotno.Name = "txt_lotno";
            this.txt_lotno.ReadOnly = true;
            this.txt_lotno.Size = new System.Drawing.Size(100, 21);
            this.txt_lotno.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Lot No:";
            // 
            // cbm_modelcd
            // 
            this.cbm_modelcd.FormattingEnabled = true;
            this.cbm_modelcd.Location = new System.Drawing.Point(116, 52);
            this.cbm_modelcd.Name = "cbm_modelcd";
            this.cbm_modelcd.Size = new System.Drawing.Size(160, 21);
            this.cbm_modelcd.TabIndex = 21;
            this.cbm_modelcd.SelectedIndexChanged += new System.EventHandler(this.cbm_modelcd_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Model Code:";
            // 
            // btn_enter
            // 
            this.btn_enter.Location = new System.Drawing.Point(282, 52);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(60, 23);
            this.btn_enter.TabIndex = 10;
            this.btn_enter.Text = "Enter";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(744, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date to:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(744, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date from:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item Barcode:";
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(804, 51);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(146, 21);
            this.dtp_to.TabIndex = 3;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(804, 14);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(146, 21);
            this.dtp_from.TabIndex = 2;
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(116, 12);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(226, 21);
            this.txt_barcode.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gc_datahistory, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.gc_datamaster, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 94);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1000, 301);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // gc_datahistory
            // 
            this.gc_datahistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_datahistory.Location = new System.Drawing.Point(503, 3);
            this.gc_datahistory.MainView = this.gv_datahistory;
            this.gc_datahistory.MenuManager = this.ribbonControl;
            this.gc_datahistory.Name = "gc_datahistory";
            this.gc_datahistory.Size = new System.Drawing.Size(494, 295);
            this.gc_datahistory.TabIndex = 3;
            this.gc_datahistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_datahistory});
            // 
            // gv_datahistory
            // 
            this.gv_datahistory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gv_datahistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6});
            this.gv_datahistory.GridControl = this.gc_datahistory;
            this.gv_datahistory.Name = "gv_datahistory";
            this.gv_datahistory.OptionsBehavior.Editable = false;
            this.gv_datahistory.OptionsBehavior.ReadOnly = true;
            this.gv_datahistory.OptionsEditForm.EditFormColumnCount = 2;
            this.gv_datahistory.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Lot No";
            this.gridColumn2.FieldName = "lot_no";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Model Code";
            this.gridColumn3.FieldName = "model_cd";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Item List";
            this.gridColumn4.FieldName = "item_list";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Create Time";
            this.gridColumn6.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "create_time";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // bbiSearch
            // 
            this.bbiSearch.Caption = "Search";
            this.bbiSearch.Id = 22;
            this.bbiSearch.ImageOptions.Image = global::IFM.Properties.Resources.Load;
            this.bbiSearch.Name = "bbiSearch";
            this.bbiSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSearch_ItemClick);
            // 
            // View_STM_Mounter_History_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bar_status);
            this.Controls.Add(this.ribbonControl);
            this.Name = "View_STM_Mounter_History_2";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.bar_status;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_datamaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_datamaster)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pn_background.ResumeLayout(false);
            this.pn_background.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_datahistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_datahistory)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView gv_datamaster;
        private DevExpress.XtraGrid.GridControl gc_datamaster;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pn_background;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Button btn_enter;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn item_list;
        private DevExpress.XtraGrid.Columns.GridColumn create_time;
        private DevExpress.XtraGrid.Columns.GridColumn model_cd;
        private System.Windows.Forms.ComboBox cbm_modelcd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_lotno;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraGrid.GridControl gc_datahistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_datahistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraBars.BarButtonItem bbiSearch;
    }
}