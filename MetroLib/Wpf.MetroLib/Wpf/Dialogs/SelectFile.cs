using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.Wpf.Dialogs
{
    //this.cmdSelect.Click += (s, e) =>
    //     new Metro.Wpf.Dialogs.SelectFile.Instance.Dialog(SelectFile.Xml, (file) => {});

    public class SelectFile
    {
        #region FilterExt

        public class FilterExt
        {
            public string DefaultExt { get; set; }
            public string Filter { get; set; }

        }

        public static FilterExt Xml = new SelectFile.FilterExt
        {
            DefaultExt = ".xml",
            Filter = "Data X files (*.x*)|*.x*"
        };
        public static FilterExt Xlsx = new SelectFile.FilterExt
        {
            DefaultExt = ".xml",
            Filter = "Excel files (*.xls*)|*.xls*"
        };
        public static FilterExt Docx = new SelectFile.FilterExt
        {
            DefaultExt = ".xml",
            Filter = "Word files (*.doc*)|*.doc*;*.rtf;*.txt;*.md"
        };

        #endregion

        public static SelectFile Instance { get; protected set; }

        static SelectFile()
        {
            Instance = new SelectFile();
        }

        Microsoft.Win32.OpenFileDialog dlg;

        public void Dialog(FilterExt filter, Action<string> open)
        {
            if (dlg == null)
                dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = filter.DefaultExt; // ".xml";
            dlg.Filter = filter.Filter; // "Data X files (*.x*)|*.x*";
            
                //+ "|Xml Files (*.xml)|*.xml"
                //          + "|Excel files (*.xl*)|*.xl*"
                //          + "|Word files (*.docx,*.rtf)|*.doc*"
                //          + "|Sql Files (*.sql)|*.sql"; // |*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"; 

            var curdir = Environment.CurrentDirectory;
            if (!string.IsNullOrWhiteSpace(dlg.FileName))
                curdir = System.IO.Path.GetDirectoryName(dlg.FileName);

            dlg.InitialDirectory = curdir;
        
            bool? sel = dlg.ShowDialog();
            if (sel == null || !sel.Value)
                return;

            open(dlg.FileName);
        }

    }
}
