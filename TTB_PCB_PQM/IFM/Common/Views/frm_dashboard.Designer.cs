namespace IFM.Common.Views
{
    partial class frm_dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dashboard));
            this.rbc_top = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.cbo_skins = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinDropDownButtonItem = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.btnNavigation = new DevExpress.XtraBars.BarButtonItem();
            this.bsiVersion = new DevExpress.XtraBars.BarStaticItem();
            this.rb_home_page = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupNavigation = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rb_status = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.mng_panels = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.pnl_sidebar = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.accc_sidebar = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accg_sidebar = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.mng_documents = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bsiUserName = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.rbc_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mng_panels)).BeginInit();
            this.pnl_sidebar.SuspendLayout();
            this.dockPanel_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accc_sidebar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mng_documents)).BeginInit();
            this.SuspendLayout();
            // 
            // rbc_top
            // 
            this.rbc_top.CaptionBarItemLinks.Add(this.cbo_skins);
            this.rbc_top.ExpandCollapseItem.Id = 0;
            this.rbc_top.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.cbo_skins,
            this.rbc_top.ExpandCollapseItem,
            this.rbc_top.SearchEditItem,
            this.skinRibbonGalleryBarItem,
            this.skinDropDownButtonItem,
            this.btnNavigation,
            this.bsiVersion,
            this.bsiUserName});
            this.rbc_top.Location = new System.Drawing.Point(0, 0);
            this.rbc_top.MaxItemId = 54;
            this.rbc_top.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.rbc_top.Name = "rbc_top";
            this.rbc_top.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rb_home_page});
            this.rbc_top.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.rbc_top.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.rbc_top.Size = new System.Drawing.Size(782, 79);
            this.rbc_top.StatusBar = this.rb_status;
            this.rbc_top.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // cbo_skins
            // 
            this.cbo_skins.Id = 48;
            this.cbo_skins.Name = "cbo_skins";
            // 
            // skinRibbonGalleryBarItem
            // 
            this.skinRibbonGalleryBarItem.Id = 14;
            this.skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // skinDropDownButtonItem
            // 
            this.skinDropDownButtonItem.Id = 46;
            this.skinDropDownButtonItem.Name = "skinDropDownButtonItem";
            // 
            // btnNavigation
            // 
            this.btnNavigation.Caption = "Navigation";
            this.btnNavigation.Id = 49;
            this.btnNavigation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNavigation.ImageOptions.Image")));
            this.btnNavigation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNavigation.ImageOptions.LargeImage")));
            this.btnNavigation.Name = "btnNavigation";
            this.btnNavigation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnNavigation_ItemClick);
            // 
            // bsiVersion
            // 
            this.bsiVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiVersion.Caption = "Version";
            this.bsiVersion.Id = 50;
            this.bsiVersion.Name = "bsiVersion";
            // 
            // rb_home_page
            // 
            this.rb_home_page.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupNavigation,
            this.ribbonPageGroup1});
            this.rb_home_page.Name = "rb_home_page";
            this.rb_home_page.Text = "Home";
            // 
            // ribbonPageGroupNavigation
            // 
            this.ribbonPageGroupNavigation.ItemLinks.Add(this.btnNavigation);
            this.ribbonPageGroupNavigation.Name = "ribbonPageGroupNavigation";
            this.ribbonPageGroupNavigation.Text = "Module";
            // 
            // rb_status
            // 
            this.rb_status.ItemLinks.Add(this.bsiVersion);
            this.rb_status.Location = new System.Drawing.Point(0, 450);
            this.rb_status.Name = "rb_status";
            this.rb_status.Ribbon = this.rbc_top;
            this.rb_status.Size = new System.Drawing.Size(782, 31);
            // 
            // mng_panels
            // 
            this.mng_panels.Form = this;
            this.mng_panels.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.pnl_sidebar});
            this.mng_panels.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // pnl_sidebar
            // 
            this.pnl_sidebar.Controls.Add(this.dockPanel_Container);
            this.pnl_sidebar.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.pnl_sidebar.ID = new System.Guid("a045df26-1503-4d9a-99c1-a531310af22b");
            this.pnl_sidebar.Location = new System.Drawing.Point(0, 79);
            this.pnl_sidebar.Name = "pnl_sidebar";
            this.pnl_sidebar.OriginalSize = new System.Drawing.Size(200, 200);
            this.pnl_sidebar.Size = new System.Drawing.Size(200, 371);
            this.pnl_sidebar.Text = "Navigation";
            // 
            // dockPanel_Container
            // 
            this.dockPanel_Container.Controls.Add(this.accc_sidebar);
            this.dockPanel_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel_Container.Name = "dockPanel_Container";
            this.dockPanel_Container.Size = new System.Drawing.Size(191, 344);
            this.dockPanel_Container.TabIndex = 0;
            // 
            // accc_sidebar
            // 
            this.accc_sidebar.AllowItemSelection = true;
            this.accc_sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accc_sidebar.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accg_sidebar});
            this.accc_sidebar.Location = new System.Drawing.Point(0, 0);
            this.accc_sidebar.Name = "accc_sidebar";
            this.accc_sidebar.Size = new System.Drawing.Size(191, 344);
            this.accc_sidebar.TabIndex = 0;
            this.accc_sidebar.SelectedElementChanged += new DevExpress.XtraBars.Navigation.SelectedElementChangedEventHandler(this.AccordionControl_SelectedElementChanged);
            // 
            // accg_sidebar
            // 
            this.accg_sidebar.Expanded = true;
            this.accg_sidebar.HeaderVisible = false;
            this.accg_sidebar.Name = "accg_sidebar";
            this.accg_sidebar.Text = "Main";
            // 
            // mng_documents
            // 
            this.mng_documents.MdiParent = this;
            this.mng_documents.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.mng_documents.View = this.tabbedView;
            this.mng_documents.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView});
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far;
            this.ribbonPageGroup1.ItemLinks.Add(this.bsiUserName);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // bsiUserName
            // 
            this.bsiUserName.Caption = "Username";
            this.bsiUserName.Id = 52;
            this.bsiUserName.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bsiUserName.ImageOptions.Image")));
            this.bsiUserName.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bsiUserName.ImageOptions.LargeImage")));
            this.bsiUserName.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsiUserName.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Blue;
            this.bsiUserName.ItemAppearance.Normal.Options.UseFont = true;
            this.bsiUserName.ItemAppearance.Normal.Options.UseForeColor = true;
            this.bsiUserName.Name = "bsiUserName";
            this.bsiUserName.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // frm_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImageStore = global::IFM.Properties.Resources.ifm_horizontal;
            this.ClientSize = new System.Drawing.Size(782, 481);
            this.Controls.Add(this.pnl_sidebar);
            this.Controls.Add(this.rb_status);
            this.Controls.Add(this.rbc_top);
            this.IconOptions.Image = global::IFM.Properties.Resources.ifm_vertical;
            this.IsMdiContainer = true;
            this.Name = "frm_dashboard";
            this.Ribbon = this.rbc_top;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.rb_status;
            this.Text = "IFM Technology Solutions Company Limited";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.rbc_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mng_panels)).EndInit();
            this.pnl_sidebar.ResumeLayout(false);
            this.dockPanel_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accc_sidebar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mng_documents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl rbc_top;
        private DevExpress.XtraBars.Ribbon.RibbonPage rb_home_page;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar rb_status;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.Docking.DockManager mng_panels;
        private DevExpress.XtraBars.Docking.DockPanel pnl_sidebar;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_Container;
        private DevExpress.XtraBars.Navigation.AccordionControl accc_sidebar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupNavigation;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accg_sidebar;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView;
        private DevExpress.XtraBars.Docking2010.DocumentManager mng_documents;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem;
        private DevExpress.XtraBars.SkinDropDownButtonItem cbo_skins;
        private DevExpress.XtraBars.BarButtonItem btnNavigation;
        private DevExpress.XtraBars.BarStaticItem bsiVersion;
        private DevExpress.XtraBars.BarStaticItem bsiUserName;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}