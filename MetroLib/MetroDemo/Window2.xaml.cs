using System;
using System.Windows;
using System.Windows.Controls;

namespace MetroDemo
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            // InitializeComponent();

            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfMetro;component/window2.xaml", System.UriKind.Relative);
            System.Windows.Application.LoadComponent(this, resourceLocater);
        }
    }
}
