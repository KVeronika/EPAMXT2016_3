using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3._3
{
    public class DynamicArray<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
    {
        private T[] internalArray;

        public DynamicArray()
            : this(8)
        {
        }

        public DynamicArray(int n)
        {
            this.internalArray = new T[n];
            this.Length = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            this.internalArray = new T[collection.Count()];
            Array.Copy((Array)collection, this.internalArray, collection.Count());
            this.Length = collection.Count();
        }

        public int Length { get; private set; }

        public int Capacity
        {
            get
            {
                return this.internalArray.Length;
            }
        }

        int ICollection<T>.Count { get; }

        int ICollection.Count { get; }

        public bool IsReadOnly
            => false;

        public bool IsFixedSize
            => false;

        public object SyncRoot
            => this.internalArray.SyncRoot;

        public bool IsSynchronized
            => this.internalArray.IsSynchronized;

        public T this[int index]
        {
            get
            {
                return this.internalArray[index];
            }

            set
            {
                if (index < 0 || index >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.internalArray[index] = value;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }

            set
            {
                this[index] = (T)value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this.internalArray[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        int IList.IndexOf(object value)
            => this.IndexOf((T)value);

        public bool Contains(T item)
            => this.internalArray.Contains(item);

        bool IList.Contains(object value)
            => this.Contains((T)value);

        public void Add(T item)
        {
            if (this.Length + 1 > this.Capacity)
            {
                this.DoublingCapacity(1);
            }

            this.Length++;
            this.internalArray[this.Length - 1] = item;
        }

        int IList.Add(object value)
        {
            this.Add((T)value);
            return this.internalArray.Length - 1;
        }

        public void AddRange(IEnumerable<T> collectionItems)
        {
            if ((this.Length + collectionItems.Count()) > this.Capacity)
            {
                this.DoublingCapacity((this.Length + collectionItems.Count()) / this.Capacity);
            }

            foreach (var item in collectionItems)
            {
                this.Add(item);
            }
        }

        public void Insert(int index, T item)
        {
            if (this.Length + 1 > this.Capacity)
            {
                this.DoublingCapacity(1);
            }

            this.Length++;
            for (int i = this.Length - 1; i >= index; i--)
            {
                this[i] = this[i - 1];
            }

            this[index] = item;
        }

        void IList.Insert(int index, object value)
        {
            this.Insert(index, (T)value);
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);
            if (index != -1)
            {
                for (int i = index; i < this.Length - 1; i++)
                {
                    this.internalArray[i] = this.internalArray[i + 1];
                }

                this.Length--;

                return true;
            }
            else
            {
                return false;
            }
        }

        void IList.Remove(object value)
            => this.Remove((T)value);

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Length - 1; i++)
            {
                this.internalArray[i] = this.internalArray[i + 1];
            }

            this.Length--;
        }

        public void Clear()
        {
            this.Length = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= array.Length || arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Length - arrayIndex > array.Length)
            {
                Array.Copy(this.internalArray, 0, array, arrayIndex, array.Length);
            }
            else
            {
                Array.Copy(this.internalArray, 0, array, arrayIndex, this.Length - arrayIndex);
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            Array.Copy(this.internalArray, 0, array, index, this.Length - index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this.internalArray, this.Length);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void DoublingCapacity(int n)
        {
            Array.Resize(ref this.internalArray, this.Capacity * 2 * n);
        }

        public class Enumerator : IEnumerator<T>
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
                    if (this.last < 0 || this.last >= this.length)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.array[this.last];
                }
            }

            object IEnumerator.Current
                => this.Current;

            void IDisposable.Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++this.last < this.array.Length;
            }

            public void Reset()
            {
                this.last = -1;
            }
        }
    }
}