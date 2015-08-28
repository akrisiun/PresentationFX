using MS.Internal.PresentationCore;
using System;
using System.ComponentModel;

namespace System.Windows.Controls
{
    public class ColumnDefinition : DefinitionBase
    {
        static ColumnDefinition() { }
        public ColumnDefinition() : base(true)
        {
        }

        //     The identifier for the System.Windows.Controls.ColumnDefinition.MaxWidth dependency
        //     property.
        [CommonDependencyPropertyAttribute]
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        public static readonly DependencyProperty MaxWidthProperty;
        
        // Returns:
        //     The identifier for the System.Windows.Controls.ColumnDefinition.MinWidth dependency
        //     property.
        [CommonDependencyPropertyAttribute]
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        public static readonly DependencyProperty MinWidthProperty;
        
        // Returns:
        //     The identifier for the System.Windows.Controls.ColumnDefinition.Width dependency
        //     property.
        [CommonDependencyPropertyAttribute]
        public static readonly DependencyProperty WidthProperty = 
            DependencyProperty.Register("Width", typeof(GridLength), typeof(ColumnDefinition), null); // new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnNotifyRowAndRowHeaderPropertyChanged)));

    
        //     A System.Double that represents the actual calculated width in device independent
        //     pixels. The default value is 0.0.
        public double ActualWidth { get { return Width.Value; } }
        
        // Returns:
        //     A System.Double that represents the maximum width. The default value is System.Double.PositiveInfinity.
        [TypeConverter(typeof(LengthConverter))]
        public double MaxWidth { get; set; }
        
        // Returns:
        //     A System.Double that represents the minimum width. The default value is 0.
        [TypeConverter(typeof(LengthConverter))]
        public double MinWidth { get; set; }
        
        //     A System.Double that represents the offset of the column. The default value is
        //     0.0.
        public double Offset { get; protected set; } // +set

        //     The System.Windows.GridLength that represents the width of the Column. The default
        //     value is 1.0.
        public GridLength Width { get; set; }


    }

    public class RowDefinition : DefinitionBase
    {
        public RowDefinition() : base(false)
        {
        }

        //     The identifier for the System.Windows.Controls.RowDefinition.Height dependency
        //     property.
        [CommonDependencyPropertyAttribute]
        public static readonly DependencyProperty HeightProperty = 
                DependencyProperty.Register("Height", typeof(GridLength), typeof(RowDefinition), null);

        //     The identifier for the System.Windows.Controls.RowDefinition.MaxHeight dependency
        //     property.
        [CommonDependencyPropertyAttribute]
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        public static readonly DependencyProperty MaxHeightProperty;
        
        //     The identifier for the System.Windows.Controls.RowDefinition.MinHeight dependency
        //     property.
        [CommonDependencyPropertyAttribute]
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        public static readonly DependencyProperty MinHeightProperty;

        
        //     A System.Double that represents the calculated height in device independent pixels.
        //     The default value is 0.0.
        public double ActualHeight { get { return Height.Value; } }
        
        //     The System.Windows.GridLength that represents the height of the row. The default
        //     value is 1.0.
        public GridLength Height { get; set; }
        
        //     A System.Double that represents the maximum height.
        [TypeConverter(typeof(LengthConverter))]
        public double MaxHeight { get; set; }
        
        //     A System.Double that represents the minimum allowable height. The default value
        //     is 0.
        [TypeConverter(typeof(LengthConverter))]
        public double MinHeight { get; set; }
        
        //     A System.Double that represents the offset of the row. The default value is 0.0.
        public double Offset { get; protected set; }
    }

}
