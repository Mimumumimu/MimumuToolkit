using MimumuToolkit.CustomControls;
using MimumuToolkit.Utilities;

namespace MimumuToolkit.Dialogs
{
    public partial class NotificationDialog : CustomForm
    {
        public NotificationDialog()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            SaveFormLocation();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }

            return;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point initialLocation = new(this.Location.X, this.Location.Y);
            FormUtil.DragWindow(this);
            if (initialLocation.X == this.Location.X &&
                initialLocation.Y == this.Location.Y)
            {
                Close();
            }
        }
    }
}
