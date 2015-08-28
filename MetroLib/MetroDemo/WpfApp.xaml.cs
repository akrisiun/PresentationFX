using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MetroDemo
{
   
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class WpfApp : System.Windows.ApplicationX, IComponentConnector
    {
        static WpfApp()
        {
            // App entry point for debugger
        }

        //internal MetroDemo.WpfApp App;
        //private bool _contentLoaded;

        public WpfApp()
        {
            // InitializeComponent();
            
            this.StartupUri = new System.Uri("Wpf.MainWindow.xaml", System.UriKind.Relative);
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfMetro;component/wpfapp.xaml", System.UriKind.Relative);
            System.Windows.ApplicationX.LoadComponent(this, resourceLocater);


            //var testWindow = new MetroWindow()
            //{
            //    Owner = null, // this,
            //    WindowStartupLocation = WindowStartupLocation.CenterOwner,
            //    Title = "Another Test...2",
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
            //testWindow.EnableDWMDropShadow = true;
            //testWindow.Show();

        }

        //void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        //{
        //    switch (connectionId)
        //    {
        //        case 1:
        //            this.App = ((MetroDemo.WpfApp)(target));
        //            return;
        //    }
        //    this._contentLoaded = true;
        //}


        /// <summary>
        /// Application Entry Point.
        /// </summary>
        //[System.Diagnostics.DebuggerNonUserCodeAttribute()]
        //[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.STAThreadAttribute()]
        public static void Main()
        {
            var app = new WpfApp();
            // app.InitializeComponent();
            app.Run();
        }

    }
}
