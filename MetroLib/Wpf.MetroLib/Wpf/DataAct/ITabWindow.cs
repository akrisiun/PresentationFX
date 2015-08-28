using System;
using System.Collections.Generic;

namespace Metro.Wpf.DataAct
{
    public interface ITabWindow
    {
        DataTabControl Frame { get; }
        IList<IPageModel> Pages { get; }

        IPageModel PageActive { get; set; }

        void Shown();
    }

}
