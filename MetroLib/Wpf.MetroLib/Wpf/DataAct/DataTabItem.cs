using MahApps.Metro.Controls;
using System;

namespace Metro.Wpf.DataAct
{
    public class DataTabItem : MetroTabItem
    {
        /*
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
        } */
        // protected override void OnRender(DrawingContext drawingContext)
    }

    public interface IPageModel : IDisposable
    {
        // DataTabItem IPageModel.Page
        DataTabItem Page { get; }
        void Reload();
    }

    public interface IPageModel<T> : IPageModel where T : class
    {

    }
}
