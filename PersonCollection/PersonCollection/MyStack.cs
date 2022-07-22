using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCollection
{
    interface IMyStack<T> : IMyCollection<T>
    {
        T Peek();
        T Pop();
        void Push(T item);
    }

    internal class MyStack<T> : IMyStack<T>
    {
        private int position = -1;
        private T[] Items
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public MyStack()
        {
            Items = new T[10];
            Count = 0;
        }

        public MyStack(int capacity)
        {
            Items = new T[capacity * 2];
            Count = 0;
        }

        public MyStack(ICollection<T> collection) : this(collection.Count)
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
            
            Count = collection.Count;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return Items[Count - 1];
        }

        public T Pop()
        {
            if (Count == 0) 
            {
                throw new InvalidOperationException();
            }

            T item = Items[Count - 1];
            Count--;
            Items[Count - 1] = default(T);

            return item;
        }

        public void Push(T item)
        {
            CapasityController();
            Items[Count] = item;
            Count++;
        }

        private void CapasityController()
        {
            if (Items.Length <= Count)
            {
                T[] newItems = new T[Count * 2];
                Items.CopyTo(newItems, 0);
                Items = newItems;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Clear()
        {
            Items = new T[10];
            Count = 0;
        }

        public bool Contains(T val)
        {
            foreach (var item in Items)
            {
                if (val.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= Count || arrayIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Items.CopyTo(array, arrayIndex);
        }

        public T Current
        {
            get { return Items[Count - 1 - position]; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this as IEnumerator<T>;
        }

        public bool MoveNext()
        {
            if (position < Count - 1)
            {
                position++;
                return true;
            }
            else
            {
                Reset();
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
        void IDisposable.Dispose()
        {
            
        }
        void ICollection<T>.Add(T item) 
        {
            Push(item); 
        }
        bool ICollection<T>.Remove(T item)
        {
            Pop();
            return true; 
        }
        object IEnumerator.Current 
        {
            get;
        }
    }
}
