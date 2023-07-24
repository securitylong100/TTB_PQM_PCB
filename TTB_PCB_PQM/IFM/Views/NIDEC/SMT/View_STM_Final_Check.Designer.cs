namespace IFM.Views.NIDEC.SMT
{
    partial class View_STM_Final_Check
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_STM_Final_Check));
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pn_background = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_exportlink = new System.Windows.Forms.TextBox();
            this.rd_NG = new System.Windows.Forms.RadioButton();
            this.rd_ok = new System.Windows.Forms.RadioButton();
            this.cbm_modelcd = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nm_row = new System.Windows.Forms.NumericUpDown();
            this.nm_column = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_enter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.tlp_showdata = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gc_data = new DevExpress.XtraGrid.GridControl();
            this.gv_data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.site = new DevExpress.XtraGrid.Columns.GridColumn();
            this.factory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.model = new DevExpress.XtraGrid.Columns.GridColumn();
            this.serno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.process = new DevExpress.XtraGrid.Columns.GridColumn();
            this.result_ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.inspectdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Timer_colorchange = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pn_background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_column)).BeginInit();
            this.tlp_showdata.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.bbiRefresh.Caption = "Refresh Layout";
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
            this.ribbonControl.Size = new System.Drawing.Size(1147, 79);
            this.ribbonControl.StatusBar = this.bar_status;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bar_status
            // 
            this.bar_status.ItemLinks.Add(this.bsiRecordsCount);
            this.bar_status.Location = new System.Drawing.Point(0, 572);
            this.bar_status.Name = "bar_status";
            this.bar_status.Ribbon = this.ribbonControl;
            this.bar_status.Size = new System.Drawing.Size(1147, 31);
            // 
            // bsiRecordsCount
            // 
            this.bsiRecordsCount.Caption = "RECORDS : 0";
            this.bsiRecordsCount.Id = 15;
            this.bsiRecordsCount.Name = "bsiRecordsCount";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pn_background, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlp_showdata, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1147, 493);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pn_background
            // 
            this.pn_background.BackColor = System.Drawing.Color.Silver;
            this.pn_background.Controls.Add(this.label7);
            this.pn_background.Controls.Add(this.txt_exportlink);
            this.pn_background.Controls.Add(this.rd_NG);
            this.pn_background.Controls.Add(this.rd_ok);
            this.pn_background.Controls.Add(this.cbm_modelcd);
            this.pn_background.Controls.Add(this.label6);
            this.pn_background.Controls.Add(this.nm_row);
            this.pn_background.Controls.Add(this.nm_column);
            this.pn_background.Controls.Add(this.label5);
            this.pn_background.Controls.Add(this.label2);
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
            this.pn_background.Size = new System.Drawing.Size(1141, 85);
            this.pn_background.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(458, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Link export:";
            // 
            // txt_exportlink
            // 
            this.txt_exportlink.Location = new System.Drawing.Point(549, 51);
            this.txt_exportlink.Name = "txt_exportlink";
            this.txt_exportlink.ReadOnly = true;
            this.txt_exportlink.Size = new System.Drawing.Size(262, 21);
            this.txt_exportlink.TabIndex = 21;
            this.txt_exportlink.Text = "\\\\192.168.193.1\\ftpin\\SMT\\PQM_SPI";
            // 
            // rd_NG
            // 
            this.rd_NG.AutoSize = true;
            this.rd_NG.Location = new System.Drawing.Point(527, 17);
            this.rd_NG.Name = "rd_NG";
            this.rd_NG.Size = new System.Drawing.Size(59, 17);
            this.rd_NG.TabIndex = 20;
            this.rd_NG.TabStop = true;
            this.rd_NG.Text = "NG ALL";
            this.rd_NG.UseVisualStyleBackColor = true;
            this.rd_NG.CheckedChanged += new System.EventHandler(this.rd_NG_CheckedChanged);
            // 
            // rd_ok
            // 
            this.rd_ok.AutoSize = true;
            this.rd_ok.Location = new System.Drawing.Point(456, 17);
            this.rd_ok.Name = "rd_ok";
            this.rd_ok.Size = new System.Drawing.Size(59, 17);
            this.rd_ok.TabIndex = 19;
            this.rd_ok.TabStop = true;
            this.rd_ok.Text = "OK ALL";
            this.rd_ok.UseVisualStyleBackColor = true;
            this.rd_ok.CheckedChanged += new System.EventHandler(this.rd_ok_CheckedChanged);
            // 
            // cbm_modelcd
            // 
            this.cbm_modelcd.FormattingEnabled = true;
            this.cbm_modelcd.Location = new System.Drawing.Point(98, 53);
            this.cbm_modelcd.Name = "cbm_modelcd";
            this.cbm_modelcd.Size = new System.Drawing.Size(211, 21);
            this.cbm_modelcd.TabIndex = 18;
            this.cbm_modelcd.SelectedIndexChanged += new System.EventHandler(this.cbm_modelcd_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Model Code:";
            // 
            // nm_row
            // 
            this.nm_row.Location = new System.Drawing.Point(776, 17);
            this.nm_row.Name = "nm_row";
            this.nm_row.Size = new System.Drawing.Size(35, 21);
            this.nm_row.TabIndex = 16;
            this.nm_row.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // nm_column
            // 
            this.nm_column.Location = new System.Drawing.Point(666, 16);
            this.nm_column.Name = "nm_column";
            this.nm_column.Size = new System.Drawing.Size(35, 21);
            this.nm_column.TabIndex = 15;
            this.nm_column.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(722, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Rows No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Columns No:";
            // 
            // btn_enter
            // 
            this.btn_enter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_enter.Location = new System.Drawing.Point(336, 13);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(81, 25);
            this.btn_enter.TabIndex = 10;
            this.btn_enter.Text = "Enter";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(850, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date to:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(850, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date from:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Barcode:";
            // 
            // dtp_to
            // 
            this.dtp_to.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to.Location = new System.Drawing.Point(910, 45);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(146, 21);
            this.dtp_to.TabIndex = 3;
            // 
            // dtp_from
            // 
            this.dtp_from.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from.Location = new System.Drawing.Point(910, 8);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(146, 21);
            this.dtp_from.TabIndex = 2;
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(98, 15);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(211, 21);
            this.txt_barcode.TabIndex = 1;
            // 
            // tlp_showdata
            // 
            this.tlp_showdata.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlp_showdata.ColumnCount = 2;
            this.tlp_showdata.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlp_showdata.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlp_showdata.Controls.Add(this.panel1, 0, 0);
            this.tlp_showdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_showdata.Location = new System.Drawing.Point(3, 94);
            this.tlp_showdata.Name = "tlp_showdata";
            this.tlp_showdata.RowCount = 1;
            this.tlp_showdata.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_showdata.Size = new System.Drawing.Size(1141, 396);
            this.tlp_showdata.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 384);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gc_data, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 384);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // gc_data
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.gc_data, 3);
            this.gc_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_data.Location = new System.Drawing.Point(3, 3);
            this.gc_data.MainView = this.gv_data;
            this.gc_data.MenuManager = this.ribbonControl;
            this.gc_data.Name = "gc_data";
            this.gc_data.Size = new System.Drawing.Size(780, 114);
            this.gc_data.TabIndex = 3;
            this.gc_data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_data});
            // 
            // gv_data
            // 
            this.gv_data.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gv_data.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.site,
            this.factory,
            this.model,
            this.serno,
            this.process,
            this.result_,
            this.inspectdate});
            this.gv_data.GridControl = this.gc_data;
            this.gv_data.Name = "gv_data";
            this.gv_data.OptionsBehavior.Editable = false;
            this.gv_data.OptionsBehavior.ReadOnly = true;
            this.gv_data.OptionsEditForm.EditFormColumnCount = 2;
            this.gv_data.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gv_data.OptionsView.ShowFooter = true;
            this.gv_data.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_data_RowStyle);
            // 
            // site
            // 
            this.site.Caption = "Site";
            this.site.FieldName = "site";
            this.site.Name = "site";
            this.site.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "site", "SUM={0:0.##}")});
            this.site.Visible = true;
            this.site.VisibleIndex = 0;
            // 
            // factory
            // 
            this.factory.Caption = "Factory";
            this.factory.FieldName = "factory";
            this.factory.Name = "factory";
            this.factory.Visible = true;
            this.factory.VisibleIndex = 1;
            // 
            // model
            // 
            this.model.Caption = "Model";
            this.model.FieldName = "model";
            this.model.Name = "model";
            this.model.Visible = true;
            this.model.VisibleIndex = 2;
            // 
            // serno
            // 
            this.serno.Caption = "Serno";
            this.serno.FieldName = "serno";
            this.serno.Name = "serno";
            this.serno.Visible = true;
            this.serno.VisibleIndex = 3;
            // 
            // process
            // 
            this.process.Caption = "Process";
            this.process.FieldName = "process";
            this.process.Name = "process";
            this.process.Visible = true;
            this.process.VisibleIndex = 4;
            // 
            // result_
            // 
            this.result_.Caption = "Result";
            this.result_.FieldName = "result_";
            this.result_.Name = "result_";
            this.result_.Visible = true;
            this.result_.VisibleIndex = 5;
            // 
            // inspectdate
            // 
            this.inspectdate.Caption = "Inspectdate";
            this.inspectdate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.inspectdate.FieldName = "inspectdate";
            this.inspectdate.Name = "inspectdate";
            this.inspectdate.Visible = true;
            this.inspectdate.VisibleIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(96, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(594, 244);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Timer_colorchange
            // 
            this.Timer_colorchange.Interval = 4000;
            this.Timer_colorchange.Tick += new System.EventHandler(this.Timer_colorchange_Tick);
            // 
            // View_STM_Final_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.bar_status);
            this.Controls.Add(this.ribbonControl);
            this.Name = "View_STM_Final_Check";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.bar_status;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pn_background.ResumeLayout(false);
            this.pn_background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nm_column)).EndInit();
            this.tlp_showdata.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pn_background;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlp_showdata;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nm_row;
        private System.Windows.Forms.NumericUpDown nm_column;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gc_data;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_data;
        private System.Windows.Forms.ComboBox cbm_modelcd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rd_NG;
        private System.Windows.Forms.RadioButton rd_ok;
        private DevExpress.XtraGrid.Columns.GridColumn site;
        private DevExpress.XtraGrid.Columns.GridColumn factory;
        private DevExpress.XtraGrid.Columns.GridColumn serno;
        private DevExpress.XtraGrid.Columns.GridColumn process;
        private DevExpress.XtraGrid.Columns.GridColumn result_;
        private DevExpress.XtraGrid.Columns.GridColumn inspectdate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer Timer_colorchange;
        private DevExpress.XtraGrid.Columns.GridColumn model;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_exportlink;
    }
}