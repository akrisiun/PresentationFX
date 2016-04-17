using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace MetroConsole
{
    public static class Class 
    {
        static Class() { LoadAsm(); }
        public static void LoadAsm()
        {
            var bin = System.AppDomain.CurrentDomain.BaseDirectory;
            Assembly asm = null;
            string keyToken = "31BF3856AD364E35";
            try
            {
                // http://blogs.msdn.com/b/keithmg/archive/2012/03/20/strong-name-validation-failed-exception-from-hresult-0x8013141a.aspx
                // Quick fix use C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\x64\sn.exe -Vr <dll>
                //    d:\Beta\Wpf\PresentationFX\lib\PresentationFramework.dll
                // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\StrongName\Verification\PresentationFramework,31BF3856AD364E35
                // PresentationFramework,31BF3856AD364E35

                // Strong name validation failed. (Exception from HRESULT: 0x8013141A) TOKEN uppercase!!!
                asm = Assembly.Load("PresentationFramework, Version=4.0.0.1, Culture=neutral, PublicKeyToken=" + keyToken); // 31BF3856AD364E35");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

//        <configuration>
//  <runtime>
//    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
//      <dependentAssembly>
//        <assemblyIdentity name="PresentationFramework" publicKeyToken="31BF3856AD364E35" culture="neutral"/>
//        <bindingRedirect oldVersion="0.0.0.0-4.0.0.1" newVersion="4.0.0.1"/>
//      </dependentAssembly>
//    </assemblyBinding>
//  </runtime>
//</configuration>


        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Hello world");
            System.Windows.ApplicationX.Check();

            var token2 = System.Presentation_BuildInfo.WCP_PUBLIC_KEY_TOKEN;
            var app = new MetroDemo.WpfApp();

            // app.MainWindow = new MetroDemo.MainWindow();
            app.Show();
            app.Run();
        }
    }
}