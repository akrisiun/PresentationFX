using Metro.Bind;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace Metro.Wpf.DataAct
{
    //http://iswwwup.com/t/d05d6b125b39/c-wpf-datagrid-binding-to-current-object-property-from-datagridcell-styl.html
    //<DataTrigger Binding = "{Binding RelativeSource={RelativeSource Self}, Converter={StaticResource UpdatedConverter}}" Value="True">
    //    <Setter Property = "Background" Value="Green" />
    //</DataTrigger>

    public class ChangedConverter : IValueConverter
    {
        public ChangedConverter() { }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DataGridCell dgc = value as DataGridCell;
            if (dgc != null)
            {
                var data = dgc.DataContext as IChangedNotify;
                if (data != null)
                {
                    return data.isChanged;

                    //DataGridTextColumn t = dgc.Column as DataGridTextColumn;
                    //if (t != null)
                    //{
                    //    var binding = t.Binding as System.Windows.Data.Binding;
                    //    if (binding != null && binding.Path != null && binding.Path.Path != null)
                    //    {
                    //        string val = binding.Path.Path.ToLower();

                    //        //if (val.StartsWith("id"))
                    //        //    return data.Id.Updated;
                    //        //if (val.StartsWith("title"))
                    //        //    return data.Title.Updated;
                    //        //if (val.StartsWith("body"))
                    //        //    return data.Body.Updated;
                    //        return false;
                    //    }
                    //}
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

