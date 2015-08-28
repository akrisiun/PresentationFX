using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;

namespace MetroDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var testWindow = new MetroWindow()
            //{
            //    Owner = null, // this,
            //    WindowStartupLocation = WindowStartupLocation.CenterOwner,
            //    Title = "Another Test...",
            //    Width = 500,
            //    Height = 300
            //};

            //testWindow.Content =
            //    new TextBlock()
            //    {
            //        Text = "MetroWindow with a Glow",
            //        FontSize = 28,
            //        FontWeight = FontWeights.Light,
            //        VerticalAlignment = VerticalAlignment.Center,
            //        HorizontalAlignment = HorizontalAlignment.Center
            //    };
            //// use this to test the obsolete under the hood code
            //testWindow.EnableDWMDropShadow = true;
            //testWindow.Show();

        }

    }
}
