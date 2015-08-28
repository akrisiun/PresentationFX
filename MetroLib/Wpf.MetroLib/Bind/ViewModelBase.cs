using Metro.Wpf.DataAct;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Metro.Bind
{
    /*
        StackPanel>
        <ItemsControl ItemsSource = "{Binding Strings}" />
        < Button Click="Button_Click">Add</Button>
    </S

        http://stackoverflow.com/questions/28529527/binding-list-to-itemscontrol-how-to-refresh
        Change List<string> to ObservableCollection<string> (msdn).

    public ObservableCollection<string> _strings = new ObservableCollection<string>();
        public ObservableCollection<string> Strings
        {
            get { return _strings; }
            set
            {
                if (_strings == value) return;
                _strings = value;
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Strings"));
            }
        }
    */

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

        public static bool isDesignTime
        {
            get { return DesignerProperties.GetIsInDesignMode(new DependencyObject()); }
        }
    }


    public class DelegateCommand : ICommand
    {
        Predicate<object> canExecute;
        Action<object> execute;

        public DelegateCommand(Predicate<object> _canexecute = null, Action<object> _execute = null)
        {
            canExecute = _canexecute;
            execute = _execute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        #pragma warning disable 67
        public event EventHandler CanExecuteChanged;
        #pragma warning restore 67

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }

    public abstract class ViewModelBase<T> : ViewModelBase, // , IEnumerator<RecordNotify<T>>,
                IEnumerator, IEnumerable where T : class // INotifyPropertyChanged
    {
        public ViewModelBase(IEnumerable<T> source)
        {
            // Truly observable
               // TrulySource = new Truly(source);
        }

        public abstract void BindData(DataActGrid grid, ExpandoObject first);

        public static ICollection<string> Keys(ExpandoObject obj)
        {
            return (obj as IDictionary<string, object>).Keys;
        }

        //public class Truly : TrulyObservableCollection<RecordNotify<T>>
        //{
        //    public static IEnumerable<RecordNotify<T>> Wrap(IEnumerable<T> source)
        //    {
        //        foreach (T item in source)
        //        {
        //            yield return new RecordNotify<T> { Target = item };
        //        }
        //    }
        //    public Truly(IEnumerable<T> source) : base(Wrap(source)) { }
        //}

        //private Truly _source;
        //public Truly TrulySource
        //{
        //    get { return _source; }
        //    set
        //    {
        //        _source = value;
        //        RaisePropertyChangedEvent("TrulySource");
        //    }
        //}

        //protected IEnumerator<RecordNotify<T>> numerator;
        protected IEnumerator<T> numerator;
        public void Dispose() { } // numerator = null; }

        //public RecordNotify<T> Current { get { return numerator == null ? null : numerator.Current; } }

        public IEnumerator GetEnumerator() { Reset(); return numerator; }
        object IEnumerator.Current { get { return numerator.Current; } }

        public void Reset() {} // numerator = _source.GetEnumerator(); }
        public bool MoveNext() { return numerator.MoveNext(); }

    }

}
