using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Windows.Controls;
using System.Windows.Data;

namespace Metro.Wpf.DataAct
{
    public static class SourceConvert
    {
        // from List/IList
        public static IEnumerable ToDataSource<T>(this DataActGrid grid,
                  IEnumerable<T> list, ExpandoObject firstObj) 
                  where T : class
        {
            Metro.Wpf.Guard.CheckNotNull(grid);

            // Metro.Wpf.GridDataSource
            // from List/IList
            ExpandoObject first = firstObj;
            if (first == null)
            {
                IEnumerator<T> numer = list.GetEnumerator();
                IEnumerator numerGeneric = numer as IEnumerator;
                try
                {
                    numerGeneric.Reset();
                }
                catch (Exception) { numerGeneric = null; }

                numer.MoveNext();

                // first one
                T  first1 = numer.Current;
                // first = Metro.Reflection.ExpandoConvert.Muttable(first1);

                if (numerGeneric != null)
                    numer.Reset();
                if (numer is IDisposable)
                    (numer as IDisposable).Dispose();
            }

            // columns bind
            ObservableCollection<DataGridColumn> columns = grid.Columns;

            if (first != null)
            {
                columns.Clear();
                foreach (var key in Keys(first))
                {
                    var item = new DataGridTextColumn()
                    {
                        Header = key,
                        Binding = new Binding(key)
                    };
                    columns.Add(item);
                }
            }
            if (columns.Count == 0)
                return null; // failure

            // ItemsControl part
            list.GetEnumerator(); // no Reset
            IEnumerable result = list as IEnumerable;

            grid.ItemsSource = result;
            grid.IsReadOnly = true;
            return result;
        }

        static ICollection<string> Keys(this ExpandoObject obj)
        {
            return (obj as IDictionary<string, object>).Keys;
        }

    }

}
