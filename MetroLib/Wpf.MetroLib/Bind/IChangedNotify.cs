using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Metro.Bind
{
    public interface IChangedNotify : INotifyPropertyChanged {
        bool Changed { get; set; }
        bool[] isChanged { get; set; }
    }

    public interface IChangedNotify<T> : INotifyPropertyChanged where T : class
    {
        T Record { get; set; }
    }

    public interface IBindingList<T> : IEnumerator<T>, INotifyCollectionChanged, INotifyPropertyChanged {}

    
    public abstract class ChangedNotify<T> : IChangedNotify<T>, IChangedNotify where T : class
    { 
        public abstract bool[] isChanged { get; set; }
        public virtual bool Changed { get { return isChanged[0]; } set { isChanged[0] = value; OnPropertyChanged("Changed"); } } 

        public abstract T Record { get; set; }

        protected abstract void OnPropertyChanged(string property);
        public abstract event PropertyChangedEventHandler PropertyChanged;
    }

    //public abstract class IBindingList<T> : IBindingList where T : class, IChangedNotify

    //public abstract class BindingListAdapter : IDisposable, INotifyPropertyChanged, INotifyCollectionChanged // IList, 
    //{
    //    private readonly IBindingList mBindingList;
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    public event NotifyCollectionChangedEventHandler CollectionChanged;

    //    public BindingListAdapter(IBindingList bindingList)
    //    {
    //        mBindingList = bindingList;
    //        mBindingList.ListChanged += mBindingList_ListChanged;
    //    }

    //    public abstract void Dispose();

    //    private void mBindingList_ListChanged(object sender, ListChangedEventArgs e)
    //    {
    //        //ExtendedListChangedEventArgs ee = (ExtendedListChangedEventArgs)e;
    //        //if (e.ListChangedType == ListChangedType.ItemAdded)
    //        //{}
    //    }

    //    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    //    {
    //        var handler = PropertyChanged;
    //        if (handler != null) handler(this, e);
    //    }

    //    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    //    {
    //        var handler = CollectionChanged;
    //        if (handler != null) handler(this, e);
    //    }

    //    public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    //    {
    //        //This will get called when the property of an object inside the collection changes
    //    }

    //}

    //class ExtendedListChangedEventArgs : ListChangedEventArgs  
    //{  
    //    public object Item { get; private set; }  
  
    //    public ExtendedListChangedEventArgs(ListChangedType listChangedType, object item,   
    //        int newIndex) : base(listChangedType, newIndex)  
    //    {  
    //        Item = item;  
    //    }  
  
    //    public ExtendedListChangedEventArgs(ListChangedType listChangedType, object item,   
    //        int newIndex, int oldIndex) : base(listChangedType, newIndex, oldIndex)  
    //    {  
    //        Item = item;  
    //    }  
    //}  

}

/*
    // http://huydinhpham.blogspot.com/2009/09/wpf-memory-leaks.html
    // The Fix/Work around:
    public class UserCollection : ObservableCollection<User>

    public class SomeEntity : INotifyPropertyChanged
    {
        // Entity properties
        UserCollection Users { get; set; }
    }
 
    // forward collection change events from underlying collection to our listeners.
    INotifyCollectionChanged incc = collection as INotifyCollectionChanged;
    if (incc != null)
    {
        // BindingListCollectionView already listens to IBindingList.ListChanged;
        // Don't double-subscribe (bug 452474, 607512)
        IBindingList ibl;
        if (!(this is BindingListCollectionView) ||
            ((ibl = collection as IBindingList) != null && !ibl.SupportsChangeNotification))
        {
            incc.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
        }
        SetFlag(CollectionViewFlags.IsDynamic, true);
    }
 
 * http://blogs.msdn.com/b/vinsibal/archive/2008/10/01/overview-of-the-editing-features-in-the-wpf-datagrid.aspx
    Working with editing commands
    Default commands have been added to the DataGrid to support editing.  These commands and their default input bindings are:
    ·         BeginEditCommand (F2)
    ·         CancelEditCommand (Esc)
    ·         CommitEditCommand (Enter)
    ·         DeleteCommand (Delete)
 
 * Code: 
CommandManager.RegisterClassCommandBinding(type, command binding);

The Fix/Work around:
this.CommandBindings.Add(command binding);
 * 
 * 
 
 public sealed class BindingListCollectionView : CollectionView, IComparer, IEditableCollectionView,
    ICollectionViewLiveShaping, IItemProperties
 
 * Window.Resources>  
        <CollectionViewSource x:Key="cvs" Source="{Binding}">  
            <CollectionViewSource.SortDescriptions>  
                <compModel:SortDescription Direction="Descending"/>  
            </CollectionViewSource.SortDescriptions>  
        </CollectionViewSource>  
    </Window.Resources>  
    <StackPanel>  
        <Button Content="Add" Click="ButtonAdd_Click"/>  
        <ListBox ItemsSource="{Binding Source={StaticResource cvs}}"/>  
    </StackPanel>
*/