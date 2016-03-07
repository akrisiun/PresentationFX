using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MetroDemo
{
    public class Startup
    {
        [System.STAThreadAttribute()]
        public static void Main()
        {
            LoadDll();
            Run();
        }

        public static void LoadDll()
        {
            try
            {
                var asm = Assembly.Load("PresentationFramework, Version=4.0.0.1, Culture=neutral, PublicKeyToken=31BF3856AD364E35");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static void Run()
        {
            // Warning	1	Found conflicts between different versions of the same dependent assembly. 
            // Please set the "AutoGenerateBindingRedirects" property to true in the project file.
            // <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
            var token2 = System.Presentation_BuildInfo.WCP_PUBLIC_KEY_TOKEN;

            var app = new WpfApp();
            app.Run(app.MainWindow);
        }
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class WpfApp : System.Windows.ApplicationX, IComponentConnector
    {
        static WpfApp()
        {
        }

        //internal MetroDemo.WpfApp App;
        //private bool _contentLoaded;

        public WpfApp()
        {
            // InitializeComponent();

            // this.StartupUri = new System.Uri("Wpf.MainWindow.xaml", System.UriKind.Relative);
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfMetro;component/wpfapp.xaml", System.UriKind.Relative);
            System.Windows.ApplicationX.LoadComponent(this, resourceLocater);


            this.MainWindow = new Window2();
            // this.MainWindow = new MainWindow();

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

        public void Show()
        {
            this.MainWindow.Show();
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

    }
}
