using System;

namespace Metro.Wpf
{
    public static class Guard
    {
        public static void CheckNotNull(object obj, string name = "uknown")
        {
            if (obj == null)
                new ArgumentNullException(name);
        }
    }
}
