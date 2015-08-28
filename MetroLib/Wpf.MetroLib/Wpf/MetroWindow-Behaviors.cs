
// InputDialog.xaml problem:
namespace Metro.Wpf.Styles { }

namespace MahApps.Metro.Controls
{
    using System.Windows;
    using Helper = Interaction.Helper;

    // MetroWindow_Behaviors

    public partial class MetroWindow
    {
        public static readonly DependencyProperty BehaviorsProperty
             = DependencyProperty.Register("Behaviors", typeof(Helper.MetroBehaviors), typeof(MetroWindow), new PropertyMetadata(null));

        public Helper.MetroBehaviors Behaviors
        {
            get { return (Helper.MetroBehaviors)GetValue(BehaviorsProperty); }
            set { SetValue(BehaviorsProperty, value); }
        }
    }
}
