using System.Windows;

namespace MahApps.Metro.Controls
{
    // MetroTabControl - Header

    //public partial class MetroTabControl
    //{

    public partial class  MetroTabItem
    {
        // HeaderedContentControl : System.Windows.Controls.ContentControl

        public static readonly DependencyProperty IsActiveProperty = Dependancy.RegisterDependency<bool>("IsActive", typeof(MetroTabItem));
        public bool IsActive { get { return this.GetProperty<bool>(IsActiveProperty); } set { SetValue(IsActiveProperty, value); } }

        public static readonly DependencyProperty IsFirstProperty = Dependancy.RegisterDependency<bool>("IsFirst", typeof(MetroTabItem));
        public bool IsFirst { get { return this.GetProperty<bool>(IsFirstProperty); } set { SetValue(IsFirstProperty, value); } }

        protected override void OnSelected(RoutedEventArgs e)
        {
            if (closeButton != null && CloseButtonEnabled)
                closeButton.Visibility = Visibility.Visible;

            base.OnSelected(e);
            IsActive = true;
        }

        protected override void OnUnselected(RoutedEventArgs e)
        {
            if (closeButton != null && CloseButtonEnabled)
                closeButton.Visibility = Visibility.Hidden;

            base.OnUnselected(e);
            IsActive = false;
        }

    }
}
