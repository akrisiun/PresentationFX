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

        Button _button1;
        Button _button2;

        public Window2()
        {
            // InitializeComponent();

            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfMetro;component/window2.xaml", System.UriKind.Relative);
            System.Windows.Application.LoadComponent(this, resourceLocater);

            _button1 = this.button1;
            _button2 = this.button2;

            _button1.Click += (s, e) =>
            {
                try
                {
                    var w = new MetroDemo.MainWindow();
                    w.Show();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            };
            _button2.Click += (s, e) =>
            {
                try
                {
                    var w = new MetroDemo.Window2();
                    w.Show();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            };


        }
    }
}
