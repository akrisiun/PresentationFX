using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Windows.Controls;
using System.Windows.Data;
using Metro.Bind;

namespace Metro.Wpf.DataAct
{
    public static class ToObservableBind
    {
        public static IEnumerable ToObservable<T>(this DataGrid grid,
               IBindingList<T> listData, ExpandoObject firstObj) where T : class
        {
            //if (grid is DataActGrid)
            //    return ToObservable<T>(grid as DataActGrid, listData as IBindingList, null, null, firstObj);

            return null;
        }

        public static void AddRangeFilter<T, TObj>(ObservableList<TObj> listData, IEnumerator<T> source, Func<T, TObj> item) where T : class
        {
            while (source.MoveNext())
            {
                var itemObj = item(source.Current);
                if (itemObj != null)
                    listData.Add(itemObj);
            }
        }

        public static IEnumerable ToObservable<T, TObj>(this DataActGrid grid,
                  ObservableList<TObj> listData,
                  IEnumerable<T> source,
                  Func<T, TObj> itemAdd,
                  ExpandoObject firstObj)
                  where T : class // , TObj : class // : INotifyPropertyChanged
        {
            Metro.Wpf.Guard.CheckNotNull(grid);
            Guard.CheckNotNull(listData);

            // Metro.Wpf.GridDataSource from List/IList
            object first = (object)firstObj ?? GetFirst<T>(source);

            // columns bind
            ObservableCollection<DataGridColumn> columns = grid.Columns;

            if (first != null)
            {
                var info = System.Globalization.DateTimeFormatInfo.CurrentInfo;
                string datetimeFormat = info.ShortDatePattern + " hh:mm"; // + info.ShortTimePattern;

                if (columns.Count > 2)
                    columns.Clear();

                foreach (var key in (first as IDictionary<string, object>).Keys)
                {
                    var value = (first as IDictionary<string, object>)[key];

                    var binding = new Binding("Record." + key);
                    if (key.IndexOf("time", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        binding.StringFormat = datetimeFormat;

                    var item = new DataGridTextColumn()
                    {
                        Header = value ?? key,
                        Binding = binding
                    };
                    columns.Add(item);
                }
            }
            if (columns.Count == 0)
                return null; // failure

            // no Reset
            IEnumerable result;
            using (var numerator = source.GetEnumerator())
                result =  WithFilter<T, TObj>(grid, listData, numerator, itemAdd);

            if (listData.IsReadOnly)
                grid.IsReadOnly = listData.IsReadOnly;

            return result;
        }

        public static IEnumerable WithFilter<T, TObj>(this DataActGrid grid,
                  ObservableList<TObj> listData,
                  IEnumerator<T> sourceNumerator,
                  Func<T, TObj> itemAdd)
                  where T : class // , TObj : class // : INotifyPropertyChanged
        {
            // ItemsControl part
            AddRangeFilter<T, TObj>(listData, sourceNumerator, itemAdd);

            var result = listData as IEnumerable;
            grid.ItemsSource = result;

            return result;
        }

        public static IEnumerable ToObservable<T>(this DataActGrid grid,
                  ObservableCollection<T> observable, ExpandoObject firstObj)
                  where T : class
        {
            return null; // TODO
        }


        public static T GetFirst<T>(IEnumerable<T> source)
        {
            IEnumerator<T> numer = source.GetEnumerator();
            IEnumerator numerGeneric = numer as IEnumerator;
            try
            {
                numerGeneric.Reset();
            }
            catch (Exception) { numerGeneric = null; }

            numer.MoveNext();

            // first one
            T first1 = numer.Current;

            if (numerGeneric != null)
                numer.Reset();
            if (numer is IDisposable)
                (numer as IDisposable).Dispose();

            return first1;
        }

        //<ProgressBar Grid.Column="1" Minimum="0" Maximum="100" Value="{Binding Completion}" />



        /* ListView
        person = new ObservableCollection<Person>()
        lstNames.ItemsSource = person;

             <ListView x:Name="lstNames" Margin="5,5,5,5" Grid.Column="1" Grid.Row="0">
             <ListView.View>
                 <GridView x:Name="grdNames">
                     <GridViewColumn Header = "Name"  DisplayMemberBinding="{Binding Name}"/>
        */

    }

}