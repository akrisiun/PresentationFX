using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Metro.Bind
{
    public class ObservableList<T> : ObservableCollection<T>, IBindingList<T>, IRaiseItemChangedEvents
    {
        public bool IsReadOnly { get; set; }
        public bool RaisesItemChangedEvents { get; set; }
        public bool RaiseListChangedEvents { get; set; }

        public T Current { get { return (T)numerator.Current; } }

        public IEnumerator<object> SourceList { get; set; }

        protected IEnumerator numerator;

        object IEnumerator.Current
        {
            get
            {
                return numerator.Current;
            }
        }

        public void Dispose() { }
        public bool MoveNext() { return numerator.MoveNext(); }
        public virtual void Reset() { numerator = this.GetEnumerator(); }
    }

}
