using DevExpress.XtraWaitForm;
using System;

namespace IFM.Views
{
    public partial class frm_wait : WaitForm
    {
        public frm_wait()
        {
            InitializeComponent();
            this.pnl_processing.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.pnl_processing.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.pnl_processing.Description = description;
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