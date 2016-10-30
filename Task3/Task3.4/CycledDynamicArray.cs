using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3._4
{
    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable
    {
        public CycledDynamicArray()
            : base()
        {
        }

        public CycledDynamicArray(int n)
            : base(n)
        {
        }

        public CycledDynamicArray(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.internalArray, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public new class Enumerator : IEnumerator<T>
        {
            private int last = -1;
            private T[] array;
            private int length;

            internal Enumerator(T[] array, int length)
            {
                this.array = array;
                this.length = length;
            }

            public T Current
            {
                get
                {
                    return this.array[this.last % this.length];
                }
            }

            object IEnumerator.Current
                => this.Current;

            void IDisposable.Dispose()
            {
            }

            public bool MoveNext()
            {
                if (this.length == 0)
                {
                    return false;
                }

                return (++this.last % this.length) < this.length;
            }

            public void Reset()
            {
                this.last = -1;
            }
        }
    }
}