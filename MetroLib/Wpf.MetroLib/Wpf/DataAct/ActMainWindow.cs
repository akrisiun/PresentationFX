using System;
using System.Collections.Generic;
using System.IO;

namespace Metro.Wpf.DataAct
{
    // Metro.Wpf.DataAct.ActMainWindow 
    public abstract class ActMainWindow : DataWindow, ITabWindow
    {
        static ActMainWindow()
        {
            if (!File.Exists("System.Windows.Interactivity.dll")
                && File.Exists("System.Windows.Interact4cl.dll"))
                File.Copy("System.Windows.Interact4cl.dll", "System.Windows.Interactivity.dll");
        }
        public static ActMainWindow Active { get; protected set; }

        #region Frame properties

        public abstract DataTabControl Frame { get; } //  { return this.frame; } }

        public IList<IPageModel> Pages { get; protected set; }

        public abstract IPageModel PageActive { get; set; } 
                        // get { return this.frame.SelectedIndex <= 0 ? null 
                        // : Pages[this.frame.SelectedIndex - 1]; } }

        #endregion

        public override void AfterRendered() { Shown(); }
        public abstract void Shown();

        // sntxdb
        // public Segment Db { get; protected set; }

    }
}
