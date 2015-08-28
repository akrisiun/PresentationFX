namespace System.Windows
{
    // WPF extensions

    public static class Dependancy
    {
        public static DependencyProperty RegisterDependency<T>(string name, Type objectType)
        {
            return DependencyProperty.Register(name, typeof(T), objectType, new PropertyMetadata(false));
        }

        public static DependencyProperty RegisterDependency<T>(string name, Type objectType, object defaultValue)
        {
            PropertyMetadata meta = new PropertyMetadata(defaultValue);
            return DependencyProperty.Register(name, typeof(T), objectType, meta);
        }

        public static T GetProperty<T>(this DependencyObject obj, DependencyProperty dp)
        {
            return (T)obj.GetValue(dp);
        }
    }
}
