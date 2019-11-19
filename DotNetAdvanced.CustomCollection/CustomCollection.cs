using System;
using System.Collections;

namespace DotNetAdvanced.CustomCollection
{
    public class CustomCollection : ICollection
    {
        private readonly int[] _innerArray;

        public int Count => this._innerArray.Length;

        public object SyncRoot => this;

        public bool IsSynchronized => false;

        public void CopyTo(Array array, int index)
        {
            foreach (var i in this._innerArray)
            {
                array.SetValue(i, index);
                index = index + 1;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(_innerArray);
        }
    }

    public class Enumerator : IEnumerator
    {
        private readonly int[] array;
        private int Cursor;

        public Enumerator(int[] array)
        {
            this.array = array;
            this.Cursor = -1;
        }

        public void Reset()
        {
            this.Cursor = -1;
        }

        public bool MoveNext()
        {
            if (this.Cursor < this.array.Length)
            {
                this.Cursor++;
            }

            return (!(this.Cursor == this.array.Length));
        }

        public object Current
        {
            get
            {
                if ((this.Cursor < 0) || (this.Cursor == this.array.Length))
                {
                    throw new InvalidOperationException();
                }

                return this.array[this.Cursor];
            }
        }
    }
}
