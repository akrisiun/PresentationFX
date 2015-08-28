using MahApps.Metro.Controls;

namespace Metro.Wpf.DataAct
{
    public class DataTabControl : MetroTabControl
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.Items.Count == 0) return;

            var first = this.Items[0] as MetroTabItem;
            first.IsFirst = true;
        }
    }
}
