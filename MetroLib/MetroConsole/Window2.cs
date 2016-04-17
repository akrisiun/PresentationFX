using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MetroDemo
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window, IComponentConnector
    {
        Button _button1;
        Button _button2;
        bool _contentLoaded;

        public Window2()
        {
            InitializeComponent();
            if (!_contentLoaded)
                return;

            //_button1.Click += (s, e) =>
            //{
            //    try
            //    {
            //        var w = new MetroDemo.MainWindow();
            //        w.Show();
            //    }
            //    catch (Exception ex) { Console.WriteLine(ex.Message); }
            //};
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

        public void InitializeComponent()
        {
            _contentLoaded = false;
            System.Uri resourceLocater = new System.Uri("/MetroConsole;component/window2.xaml", System.UriKind.Relative);
            System.Windows.Application.LoadComponent(this, resourceLocater);
        }

        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this._button1 = target as Button;
                    return;
                case 2:
                    this._button2 = target as Button;
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
