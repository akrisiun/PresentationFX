using Metro.Wpf.DataAct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Metro.Bind
{
    public interface IPageModelChanged<T> : IPageModel where T : class, IChangedNotify
    {
        IAppTools Toolbar { get; }

        ObservableList<T> ListData { get; }

        void Activate();
    }

    public abstract class PageModel<T> : IPageModelChanged<T>, IRaiseItemChangedEvents, IDisposable
            where T : class, IChangedNotify
    {
        public DataTabItem @this { get; set; }

        #region Implement 

        DataTabItem IPageModel.Page { get { return @this; } }

        public abstract DataActGrid TableGrid { get; }
        // {[DebuggerStepThrough] get { return panel.grd1; } }

        public abstract IAppTools Toolbar { get; }
        // {[DebuggerStepThrough] get { return panel.toolbar; } }
        //public <X> panel { get; set; }

        public ObservableList<T> ListData { get; set; }
        public bool RaisesItemChangedEvents { get { return ListData.RaiseListChangedEvents; } }

        #endregion

        public abstract void Reload();
        public abstract void Dispose();

        public void Activate() { if (ListData == null) Reload(); }

    }
}
