using System;
using MahApps.Metro.Controls;

namespace Metro.Wpf.DataAct
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : MetroWindow
    {
        static DataWindow() { }

        public DataWindow()
        {
            if (this.Behaviors == null) //  b.AssociatedObject == null)
                this.ToggleNoneWindowStyle(true);

            this.EnableDWMDropShadow = true;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            AfterRendered();
        }

        public virtual void AfterRendered() { }

    }
}
