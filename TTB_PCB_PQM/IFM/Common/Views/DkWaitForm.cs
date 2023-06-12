using DevExpress.XtraWaitForm;
using System;

namespace IFM.Common.Views
{
    public partial class DkWaitForm : WaitForm
    {
        public DkWaitForm()
        {
            InitializeComponent();
            this.pnl_process.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.pnl_process.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.pnl_process.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}