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
            Owner = owner;
        }

        public void InternalTrimToSize() { }

        protected IAddChild Owner { get; set; }
        public int InternalCount { get; protected set; }

        public DefinitionBase[] InternalItems { get { return this.ToArray<DefinitionBase>(); } }

        public class Enumerator : IEnumerator
        {
            public Enumerator(ColumnDefinitionCollection owner = null)
            {
                Owner = owner;
                if (owner != null)
                    Reset();
            }
            private ColumnDefinitionCollection Owner;
            private IEnumerator numerator;

            public object Current { get { return numerator == null ? null : numerator.Current; } }

            public bool MoveNext()
            {
                return numerator == null ? false : numerator.MoveNext();
            }

            public void Reset()
            {
                if (Owner == null)
                    numerator = null;
                else
                    numerator = Owner.GetEnumerator();
            }
        }

    }

    public class RowDefinitionCollection : Collection<RowDefinition>
    {
        public RowDefinitionCollection(IAddChild owner = null)
        {
            Owner = owner;
        }

        public void InternalTrimToSize() { }

        protected IAddChild Owner { get; set; }
        public int InternalCount { get; protected set; }

        public DefinitionBase[] InternalItems { get { return this.ToArray<DefinitionBase>(); } }

        public class Enumerator : IEnumerator
        {
            public Enumerator(RowDefinitionCollection owner = null)
            {
                Owner = owner;
                if (owner != null)
                    Reset();
            }
            private RowDefinitionCollection Owner;
            private IEnumerator numerator;

            public object Current { get { return numerator == null ? null : numerator.Current; } }

            public bool MoveNext()
            {
                return numerator == null ? false : numerator.MoveNext();
            }

            public void Reset()
            {
                if (Owner == null)
                    numerator = null;
                else
                    numerator = Owner.GetEnumerator();
            }
        }
    }
}
