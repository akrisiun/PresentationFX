using System.Windows;
using System.Windows.Controls;

namespace Metro.Wpf.DataAct
{
    public class DataTextBoxFS : TextBox, IFrameworkInputElement, IInputElement
    {
        public static readonly DependencyProperty IsFirstFocusProperty = Dependancy.RegisterDependency<bool>("IsFirstFocus", typeof(DataTextBoxFS));

        bool notFocused = true;
        public bool IsFirstFocus { get { return notFocused; } set { notFocused = value; } }

        public string TextOrigin { get { return notFocused ? string.Empty : this.Text; }
            set
            {
                this.Text = value;
                if (notFocused)
                    IsFirstFocus = false;
            }
        }

        public DataTextBoxFS() : base()
        {
            if (IsFirstFocus && this.Foreground == SystemColors.ControlDarkDarkBrush)
                this.Foreground = SystemColors.GrayTextBrush;
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (IsFirstFocus)
                this.StartEdit();
            IsFirstFocus = false;
        }

        public virtual void StartEdit()
        {
            this.Text = "";
            if (this.Foreground == SystemColors.GrayTextBrush
                || (this.Foreground as System.Windows.Media.SolidColorBrush).Color.ToString().Contains("808080")) // .Equals(0xFF808080))
                this.Foreground = SystemColors.WindowTextBrush; // .ControlDarkDarkBrush;
        }

    }
}
