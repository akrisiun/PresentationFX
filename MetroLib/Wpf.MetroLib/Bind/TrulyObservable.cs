using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Metro.Bind
{
    public class RecordNotify<T> : ViewModelBase, INotifyPropertyChanged where T : class 
    {
        protected T _target;
        public T Target
        {
            get { return _target; }
            set
            {
                if (_target == value)
                    return;
                _target = value;
                this.RaisePropertyChangedEvent("");
                //if (PropertyChanged != null)
                //    this.PropertyChanged(this, new PropertyChangedEventArgs(""));
            }
        }

        // public event PropertyChangedEventHandler PropertyChanged;
        // public event PropertyChangedEventHandler PropertyChanged { add; remove; }
    }

    public class TrulyObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public TrulyObservableCollection(IEnumerable<T> source = null)
            : base(source)
        {
            // Specialized
            CollectionChanged += new NotifyCollectionChangedEventHandler(TrulyObservableCollection_CollectionChanged);
        }

        void TrulyObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object item in e.NewItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (object item in e.OldItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }

        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(a);
        }
    }

}

/*
<Style TargetType="{x:Type toolkit:DataGridRow}">
        <Setter Property="ValidationErrorTemplate">

 http://blogs.u2u.be/diederik/post/2009/09/30/Validation-in-a-WPF-DataGrid.aspx
 
Row validation

A DataErrorValidationRule can also be instantiated from the RowValidationRules of the DataGrid:

<!-- Validating through IDataErrorInfo -->
<toolkit:DataGrid.RowValidationRules>
    <DataErrorValidationRule />
</toolkit:DataGrid.RowValidationRules>

    
    <!-- Validation Error Template for a DataGrid Row -->
    <Style TargetType="{x:Type toolkit:DataGridRow}">
        <Setter Property="ValidationErrorTemplate">
            <Setter.Value>
                <ControlTemplate>
                    <Image
                       Source="/DataGridValidationSample;component/error.png"
                       ToolTip="{Binding RelativeSource={
                                             RelativeSource FindAncestor,
                                             AncestorType={x:Type toolkit:DataGridRow}},
                                         Path=(Validation.Errors)[0].ErrorContent}"
                       Margin="0"
                       Width="11" Height="11" />
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>

    internal class TemperatureValidationRule : ValidationRule
    {
        /// <summary>
        /// Validates the proposed value.
        /// </summary>
        /// <param name="value">The proposed value.</param>
        /// <param name="cultureInfo">A CultureInfo.</param>
        /// <returns>The result of the validation.</returns>
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        { 
    
    
    <toolkit:DataGrid
            ItemsSource="{x:Static local:WeatherForecast.TomorrowsForecast}"
            AutoGenerateColumns="False"
            RowHeaderWidth="16">
      
    <Style x:Key="CellErrorStyle" TargetType="{x:Type TextBlock}">
        <Style.Triggers>
            <Trigger Property="Validation.HasError" Value="true">
                <Setter Property="ToolTip"
                        Value="{Binding RelativeSource={RelativeSource Self},
                                Path=(Validation.Errors)[0].ErrorContent}"/>
                <Setter Property="Background" Value="Yellow"/>
            </Trigger>
        </Style.Triggers>
    </Style>
    -- And use it: --

    <DataGrid.Columns>
        <DataGridTextColumn 
            ElementStyle="{StaticResource CellErrorStyle}">
        </DataGridTextColumn>
    </DataGrid.Columns>


    <toolkit:DataGrid.Columns>
                <toolkit:DataGridTextColumn
                   Header="Planet"
                   Binding="{Binding Path=Planet}"/>
                <toolkit:DataGridTextColumn
                   Header="Conditions"
                   Binding="{Binding Path=Conditions}"/>
*/
