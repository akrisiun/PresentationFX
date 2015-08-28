using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Metro.Bind
{
    public abstract class BindObservable<T> : ObservableCollection<T> where T : class
    {

        public void SetChanged(string propertyName)
        {
            PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
            this.OnPropertyChanged(args);
        }

        //  Occurs when a property value changes.
        // protected event PropertyChangedEventHandler PropertyChanged;

    }

    // http://www.wpfmentor.com/2008/12/observable-collections-independent-of.html
    // ExtendedCollectionViewSource

    public class BindCollectionViewSource : CollectionViewSource
    {
        private BindingListAdapter mAdapter;

        static BindCollectionViewSource()
        {
            CollectionViewSource.SourceProperty.OverrideMetadata(
                typeof(BindCollectionViewSource),
                new FrameworkPropertyMetadata(null, CoerceSource));
        }

        // This class should be kept internal as the Coerce is a little dodgy.   
        // Consumers of this class could reasonably expect the Source property  
        // to return the same instance that was set to it.  

        private static object CoerceSource(DependencyObject d, object baseValue)
        {
            BindCollectionViewSource cvs = (BindCollectionViewSource)d;
            if (cvs.mAdapter != null)
            {
                cvs.mAdapter.Dispose();
                cvs.mAdapter = null;
            }
            
            IBindingList bindingList = baseValue as IBindingList;
            
            //if (bindingList != null)
            //{
            //    cvs.mAdapter = new BindingListAdapter(bindingList);
            //    return cvs.mAdapter;
            //}

            return baseValue;
        }
    }

}

/*
 * 
 * 
 * 
 * 
https://social.msdn.microsoft.com/Forums/vstudio/en-US/d3d6b7ec-71f9-4011-afc5-0bf3956e6d78/wpf-forum-faqs-updated-for-wpf-4?forum=wpf#x__Toc265507378

?*

    1.2 How to get the cell content from Datagrid

DataGrid is one kind of ItemsControl, so it has the Items property and the ItemContainer that wraps the item.It is different with DataGridView in Windows Forms, the DataGridRow is an item in the Items collection and the cell is wrapped in a DataGridCellsPresenter structure; so we cannot get the cell content like DataGridView.Rows.Cells.However, In WPF we can access to the element in the control through VisualTree, of cause can access the DataGridRow and the DataGridCellsPresenter in the DataGrid via VisualTree; and get the cell instance in the DataGridCellsPresenter.

DataGridRow rowContainer = (DataGridRow)dataGrid1.ItemContainerGenerator.ContainerFromIndex(rowIndex);
DataGridCellsPresenter presenter = GetVisualChild(rowContainer);
DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);

// ...

public static T GetVisualChild<T>(Visual parent) where T : Visual
{
    T child = default(T);
    int numVisuals = VisualTreeHelper.GetChildrenCount(parent);

    for (int i = 0; i < numVisuals; i++)
    {
        Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
        child = v as T;

        if (child == null)
            child = GetVisualChild(v);
        else
            break;
    }

    return child;
}
*/
