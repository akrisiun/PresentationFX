using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace MetroConsole
{
    public static class Class 
    {
        static Class()
        {
            // b03f5f7f11d50a3a
            var bin = System.AppDomain.CurrentDomain.BaseDirectory;
            //  bin + "\\

            Assembly asm = null;
            try
            {
                //  http://blogs.msdn.com/b/keithmg/archive/2012/03/20/strong-name-validation-failed-exception-from-hresult-0x8013141a.aspx
                //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\StrongName\Verification\*,58845dcd9090cc91]
                //[HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\StrongName\Verification\*,58845dcd9090cc91]

                //Quick fix use C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\x64\sn.exe -Vr <dll>
                //    d:\Beta\Owin\refsource\presentation\lib\PresentationFramework.dll

                //Verification entry added for assembly 'PresentationFramework,31BF3856AD364E35'
                //Press any key to continue . . .
    
                // var asm = Assembly.Load("PresentationFramework.dll"); // , Version=4.0.0.1, PublicKeyToken=b03f5f7f11d50a3a");
                // 31bf3856ad364e35

                //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\StrongName\Verification\PresentationFramework,31BF3856AD364E35
                //PresentationFramework,31BF3856AD364E35

                // Strong name validation failed. (Exception from HRESULT: 0x8013141A) TOKEN uppercase!!!
                asm = Assembly.Load("PresentationFramework, Version=4.0.0.1, Culture=neutral, PublicKeyToken=31BF3856AD364E35");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        [STAThread]
        public static void Main()
        {
            Console.WriteLine("Hello world");
            System.Windows.ApplicationX.Check();

            var app = new MetroDemo.WpfApp();

            // app.MainWindow = new MetroDemo.MainWindow();
            app.MainWindow = new MetroDemo.Window2();
            app.Run();
        }
    }
}