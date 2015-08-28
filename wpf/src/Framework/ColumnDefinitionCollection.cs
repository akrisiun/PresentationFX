using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace System.Windows.Controls
{
    public class ColumnDefinitionCollection : Collection<ColumnDefinition>
    {
        public ColumnDefinitionCollection(IAddChild owner = null)
        {

        }

        public void InternalTrimToSize() { }

        public int InternalCount { get; protected set; }

        public DefinitionBase[] InternalItems { get { return null; } }

        public class Enumerator : IEnumerator
        {
            public Enumerator(ColumnDefinitionCollection owner = null)
            {

            }

            public object Current { get; set; }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

    }

    public class RowDefinitionCollection : Collection<RowDefinition>
    {
        public RowDefinitionCollection(IAddChild owner = null)
        {

        }

        public void InternalTrimToSize() { }

        public int InternalCount { get; protected set; }

        public DefinitionBase[] InternalItems { get { return null; } }

        public class Enumerator : IEnumerator
        {
            public Enumerator(RowDefinitionCollection owner = null)
            {

            }

            public object Current { get; set; }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
