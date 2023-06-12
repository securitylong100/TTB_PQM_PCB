using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using IFM.DataAccess.Models.SYS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace IFM.Common.Views
{
    public partial class frm_dashboard : RibbonForm
    {
        private IList<m_assignment> _assignments;

        public frm_dashboard()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bsiVersion.Caption = $"[ver{ClsSession.App.Version}]";
            bsiUserName.Caption = ClsSession.App.UserName;
            _assignments = ClsSession.App.GetViews();
            foreach (var item in ClsSession.App.UserRoles)
            {
                var assignment = _assignments.FirstOrDefault(x => x.assign_code == item.assign_code);
                if (assignment != null)
                {
                    var acce = new AccordionControlElement
                    {
                        Style = ElementStyle.Item,
                        Tag = assignment.assign_view,
                        Text = ClsSession.App.UserLang == "en"
                            ? assignment.assign_name
                            : assignment.assign_name_vn,
                    };
                    LoadElements(acce, assignment.parent_code);
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = MessageBox.Show("Are you sure you want to exit?", "Caution",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes;
            base.OnClosing(e);
        }

        private void LoadElements(AccordionControlElement item, string parent_code)
        {
            if (string.IsNullOrWhiteSpace(parent_code))
            {
                accg_sidebar.Elements.Add(item);
                return;
            }
            var accg = FindElement(accg_sidebar.Elements, parent_code);
            if (accg != null)
            {
                accg.Elements.Add(item);
                return;
            }
            var parent = _assignments.FirstOrDefault(x => x.assign_code == parent_code);
            if (parent != null)
            {
                accg = new AccordionControlElement()
                {
                    Tag = parent.assign_code,
                    Style = ElementStyle.Group,
                    Text = ClsSession.App.UserLang == "en"
                        ? parent.assign_name
                        : parent.assign_name_vn,
                };
                accg.Elements.Add(item);
                LoadElements(accg, parent.parent_code);
            }
        }

        private AccordionControlElement FindElement(AccordionControlElementCollection elements, string tag)
        {
            foreach (var element in elements)
            {
                if (tag == element.Tag?.ToString())
                {
                    return element;
                }
                if (element.Elements != null && element.Elements.Count > 0)
                {
                    var item = FindElement(element.Elements, tag);
                    if (item != null)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private void BtnNavigation_ItemClick(object sender, ItemClickEventArgs e)
        {
            pnl_sidebar.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
        }

        private void AccordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            try
            {
                if (e.Element == null) return;
                ClsSession.App.SplashScreen.ShowWaitForm();
                Assembly assembly = Assembly.GetExecutingAssembly();
                var viewType = assembly.GetTypes().FirstOrDefault(x => x.Name == e.Element.Tag?.ToString());
                if (viewType == null) return;
                var view = Activator.CreateInstance(viewType) as Form;
                view.Text = e.Element.Text;
                tabbedView.AddDocument(view);
                tabbedView.ActivateDocument(view);
            }
            finally
            {
                accc_sidebar.SelectedElement = null;
                if (ClsSession.App.SplashScreen.IsSplashFormVisible)
                {
                    ClsSession.App.SplashScreen.CloseWaitForm();
                }
            }
        }
    }
}