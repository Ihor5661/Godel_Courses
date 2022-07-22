using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCollection
{

    interface IMyList<T>: IMyCollection<T>
    {
        T this[int index]
        {
            get;
            set;
        }

        void RemoveAt(int index);
        int IndexOf(T item);
        void Insert(int index, T item);
        T[] Sort();
    }

    class MyList<T> : IMyList<T>
    {
        private T[] arrayMyList;
        private int position = -1;

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return arrayMyList[index];
            }

            set
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                arrayMyList[index] = value;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public MyList()
        {
            arrayMyList = new T[10];
            Count = 0;
        }

        public MyList(int capasity)
        {
            arrayMyList = new T[capasity];
            Count = 0;
        }

        public MyList(ICollection<T> list)
        {
            arrayMyList = new T[list.Count * 2];

            list.CopyTo(arrayMyList, 0);
            Count = list.Count;
        }

        private void CapasityController()
        {
            if (arrayMyList.Length <= Count)
            {
                T[] newArrayMyList = new T[Count * 2];
                arrayMyList.CopyTo(newArrayMyList, 0);
                arrayMyList = newArrayMyList;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public T Current
        {
            get { return this[position]; }
        }

        object IEnumerator.Current
        {
            get { return this[position]; }
        }

        public void Add(T item)
        {
            CapasityController();
            Count++;
            arrayMyList[Count - 1] = item;
        }

        public void Clear()
        {
            arrayMyList = new T[10];
            Count = 0;
        }

        public bool Contains(T item)
        {
            return arrayMyList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= Count || arrayIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }
            arrayMyList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return arrayMyList.Take(Count).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            int index;

            index = -1;

            if (this.Contains(item))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (arrayMyList[i].Equals(item))
                    {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            T[] newArrayMyList = new T[Count + 2];


            for (int i = 0, j = 0; i <= Count; i++, j++)
            {
                if (i == index)
                {
                    newArrayMyList[j] = item;
                    j++;
                }

                newArrayMyList[j] = arrayMyList[i];
            }

            arrayMyList = newArrayMyList;
            Count++;
        }

        public bool Remove(T item)
        {
            int index;
            bool removed;

            removed = false;
            index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
                removed = true;
            }

            return removed;
        }

        public void RemoveAt(int index)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            T[] newArrayMyList = new T[Count + 1];


            for (int i = 0, j = 0; i <= Count; i++, j++)
            {
                if (i == index)
                {
                    i++;
                }

                newArrayMyList[j] = arrayMyList[i];
            }

            arrayMyList = newArrayMyList;
            Count--;
        }

        public T[] Sort()
        {
            Array.Sort(arrayMyList, 0, Count);
            return arrayMyList;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            //
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
    }
}
