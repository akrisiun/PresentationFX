
using System.Windows;
using Interaction.Helper;
using System.Windows.Interactivity;
using System.Collections.Generic;

namespace MahApps.Metro.Controls
{
    // parent: FreezableCollection<Behavior>, IAttachedObject 
    // wrap: MahApps.Metro.Behaviours.BorderlessWindowBehavior

    public class Bordless : MetroBehaviors, ICollection<Behavior>, IAttachedObject
    {
        public Bordless()
        {
            this.BorderlessWindowBehavior = true;
        }

        public override void Attach(DependencyObject dependencyObject)
        {
            // base.Attach(dependencyObject);

            var window = System.Windows.Application.Current.MainWindow;
            if (window is MetroWindow)
            {
                var metro = window as MetroWindow;
                if (metro != null && !metro.UseNoneWindowStyle)
                    metro.UseNoneWindowStyle = true;
            }
        }
    }
}
