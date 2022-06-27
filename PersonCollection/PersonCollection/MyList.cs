using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCollection
{
    interface IMyList<T>
    {
        //T this[int index]
        //{
        //    get;
        //    set;
        //}

        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);

        //int Add(object? value);
        //void Clear();
        //bool Contains(object? value);
        //int IndexOf(object? value);
        //void Insert(int index, object? value);
        //void Remove(object? value);
        //void RemoveAt(int index);
    }

    class MyList<T> : IMyList<T>
    {
        private T[] arrayMyList;
        private int count;

        public MyList()
        {
            arrayMyList = new T[10];
            count = 0;
        }


        private void CapasityController()
        {
            if (arrayMyList.Length == Count)
            {
                T[] newArrayMyList = new T[Count * 2];
                arrayMyList.CopyTo( newArrayMyList, 0 );
                arrayMyList = newArrayMyList;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new NotImplementedException();
                }
                return arrayMyList[index];
            }

            set
            {
                CapasityController();
                arrayMyList[index] = value;
                Count++;
            }
        }

        //T IMyList<T>.this[int index]
        //{
        //    get {
        //        if (index >= Count)
        //        {
        //            throw new NotImplementedException();
        //        }
        //        return arrayMyList[index];
        //    }

        //    set 
        //    {
        //        CapasityController();
        //        Count++;
        //        arrayMyList[index] = value;
        //    }
        //}

        public int Count
        {
            get 
            { 
                return count;
            }

            private set
            {
                count = value;
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
