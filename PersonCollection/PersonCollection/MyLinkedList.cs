using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCollection
{
    interface IMyLinkedList<T> : IMyCollection<T>
    {
        void AddFirst(T item);
        void AddLast(T item);
        void AddAfter(T pointer, T item);
        void AddBefore(T pointer, T item);
        void RemoveFirst();
        void RemoveLast();
    }

    internal class MyLinkedList<T> : IMyLinkedList<T>
    {
        private NestedNode head;
        private NestedNode tail;
        private int position = -1;

        private class NestedNode
        {
            public NestedNode nextNode;
            public NestedNode previousNode;

            public T data;

            public NestedNode(T data, NestedNode nextNode = null, NestedNode previousNode = null)
            {
                this.data = data;
                this.nextNode = nextNode;
                this.previousNode = previousNode;
            }
        }

        private T this[int index]
        {
            get
            {
                bool isIncrement;
                int counter;
                NestedNode current;

                if (Count / 2 > index)
                {
                    current = head;
                    isIncrement = true;
                    counter = 0;
                }
                else
                {
                    current = tail;
                    isIncrement = false;
                    counter = Count - 1;
                }

                while (current != null)
                {
                    if (counter == index)
                    {
                        return current.data;
                    }
                    if (isIncrement)
                    {
                        current = current.nextNode;
                        counter++;
                    }
                    else
                    {
                        current = current.previousNode;
                        counter--;
                    }
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                bool isIncrement;
                bool invalidIndex = true;
                int counter;
                NestedNode current;

                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                if (Count / 2 > index)
                {
                    current = head;
                    isIncrement = true;
                    counter = 0;
                }
                else
                {
                    current = tail;
                    isIncrement = false;
                    counter = Count - 1;
                }

                while (current != null)
                {
                    if (counter == index)
                    {
                        current.data = value;
                        invalidIndex = false;
                        break;
                    }

                    if (isIncrement)
                    {
                        current = current.nextNode;
                        counter++;
                    }
                    else
                    {
                        current = current.previousNode;
                        counter--;
                    }
                }

                if (invalidIndex)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public MyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public MyLinkedList(IMyLinkedList<T> list)
        {
            foreach (var item in list)
            {
                this.AddLast(item);
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void AddFirst(T item)
        {
            if (head == null)
            {
                head = new NestedNode(item, null, null);
                tail = head;
            }
            else
            {
                NestedNode newHead = new NestedNode(item, head, null);
                head.previousNode = newHead;

                head = newHead;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            if (head == null)
            {
                head = new NestedNode(item, null, null);
                tail = head;
            }
            else
            {
                NestedNode newTail = new NestedNode(item, null, tail);
                tail.nextNode = newTail;

                tail = newTail;
            }
            Count++;
        }

        public void AddAfter(T pointer, T item)
        {
            //toDo
        }

        public void AddBefore(T pointer, T item)
        {
            //toDo
        }

        public void Clear()
        {
            if (Count <= 0)
            {
                return;
            }

            NestedNode pointer = head.nextNode;
            for (int i = 0; i < Count; i++)
            {
                pointer = head.nextNode;

                if (head != null)
                {
                    head.previousNode = null;
                    head.nextNode = null;
                    head = pointer;
                }
            }
            tail.previousNode = null;
            tail.nextNode = null;

            Count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] list, int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < Count; i++)
            {
                list[i] = this[i];
            }
        }

        private int IndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        //public void Insert(int index, T item)
        //{
        //    if (index > Count || index < 0)
        //    {
        //        throw new IndexOutOfRangeException();
        //    }

        //    if (index == 0)
        //    {
        //        this.AddFirst(item);
        //        return;
        //    }
        //    if (index == Count)
        //    {
        //        this.Add(item);
        //        return;
        //    }

        //    bool isIncrement;
        //    int counter;
        //    NestedNode current;



        //    if (Count / 2 > index)
        //    {
        //        current = head;
        //        isIncrement = true;
        //        counter = 0;
        //    }
        //    else
        //    {
        //        current = tail;
        //        isIncrement = false;
        //        counter = Count - 1;
        //    }

        //    while (current != null)
        //    {
        //        if (counter == index)
        //        {
        //            break;
        //        }
        //        if (isIncrement)
        //        {
        //            current = current.nextNode;
        //            counter++;
        //        }
        //        else
        //        {
        //            current = current.previousNode;
        //            counter--;
        //        }
        //    }

        //    NestedNode newNode = new NestedNode(item, current, current.previousNode);
        //    current.previousNode = newNode;
        //    current.previousNode.previousNode.nextNode = newNode;
        //    Count++;
        //}

        public bool Remove(T item)
        {
           int index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        private void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                this.RemoveFirst();
                return;
            }
            if (index == Count - 1)
            {
               this.RemoveLast();
               return;
            }

            bool isIncrement;
            int counter;
            NestedNode current;



            if (Count / 2 > index)
            {
                current = head;
                isIncrement = true;
                counter = 0;
            }
            else
            {
                current = tail;
                isIncrement = false;
                counter = Count - 1;
            }

            while (current != null)
            {
                if (counter == index)
                {
                    break;
                }
                if (isIncrement)
                {
                    current = current.nextNode;
                    counter++;
                }
                else
                {
                    current = current.previousNode;
                    counter--;
                }
            }

            current.previousNode.nextNode = current.nextNode;
            current.nextNode.previousNode = current.previousNode;
            current = null;

            Count--;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new NotImplementedException();
            }

            if (Count == 1)
            {
                head = null;
                Count = 0;
                return;
            }

            head = head.nextNode;
            head.previousNode = null;
            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Count == 1)
            {
                head = tail = null;
                Count = 0;
                return;
            }

            tail = tail.previousNode;
            tail.nextNode = null;

            Count--;
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

        object IEnumerator.Current
        {
            get { return this[position]; }
        }

        public T Current
        {
            get { return this[position]; }
        }

        public void Dispose()
        {
            //
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this as IEnumerator<T>;
        }

    }
}
