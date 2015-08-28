using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Metro.Bind
{
    public abstract class BindList : IBindingList
    {
        public abstract object this[int index] { get; set; }

        public bool AllowEdit { get { return true; } }
        public bool AllowNew { get { return true; } }
        public bool AllowRemove { get { return false; } } 

        public abstract int Count { get; }

        public abstract bool IsFixedSize { get; }
        public abstract bool IsReadOnly { get; }
        public abstract bool IsSorted { get; }
        public abstract bool IsSynchronized { get; }

        public abstract ListSortDirection SortDirection { get; }
        public abstract PropertyDescriptor SortProperty { get; }

        public bool SupportsChangeNotification { get { return true; } }

        public abstract bool SupportsSearching { get; }
        public abstract bool SupportsSorting { get; }
        public abstract object SyncRoot { get; }

        public abstract event ListChangedEventHandler ListChanged;

        public abstract int Add(object value);
        public abstract void AddIndex(PropertyDescriptor property);
        public abstract object AddNew();
        public abstract void ApplySort(PropertyDescriptor property, ListSortDirection direction);
        public abstract void Clear();
        public abstract bool Contains(object value);
        public abstract void CopyTo(Array array, int index);
        public abstract int Find(PropertyDescriptor property, object key);

        public abstract IEnumerator GetEnumerator();
        public abstract int IndexOf(object value);
        public abstract void Insert(int index, object value);
        public abstract void Remove(object value);
        public abstract void RemoveAt(int index);
        public abstract void RemoveIndex(PropertyDescriptor property);
        public abstract void RemoveSort();
    }
}
