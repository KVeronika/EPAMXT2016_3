using System;
using System.Threading;

namespace Task4._1
{
    public class SortingUnit
    {
        public event EventHandler<EventArgs> SortingIsFinished;

        public void StarSortingtInTheSameThread<T>(T[] array, Func<T, T, int> comparePrinciple)
        {
            this.SortArray(array, comparePrinciple);
        }

        public void StartSortingInAnotherThread<T>(T[] array, Func<T, T, int> comparePrinciple)
        {
            new Thread(() => this.SortArray(array, comparePrinciple)).Start();
        }

        protected virtual void OnSortingIsFinished()
        {
            this.SortingIsFinished?.Invoke(this, EventArgs.Empty);
        }

        private void SortArray<T>(T[] array, Func<T, T, int> comparePrinciple)
        {
            if (comparePrinciple == null)
            {
                throw new ArgumentNullException(nameof(comparePrinciple));
            }

            T temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (comparePrinciple(array[j], array[j - 1]) < 0)
                    {
                        temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }
            }

            this.OnSortingIsFinished();
        }
    }
}