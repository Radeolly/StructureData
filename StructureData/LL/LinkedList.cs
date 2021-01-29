using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace StructureData.LL
{
    public class LinkedList
    {
        public int Length { get; set; }

        private Node _root;

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }

        public LinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }

                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public void AddToTheEnd(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;

                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = new Node(value);
            }
            else
            {
                _root = new Node(value);
            }
            Length++;
        }

        public void AddToTheBeginning(int value)
        {
            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
            Length++;
        }

        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                AddToTheBeginning(value);
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                current.Next = new Node(value);

                current.Next.Next = tmp;
                Length++;
            }
        }

        public void DeleteLastElement()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root != null)
            {
                Node tmp = _root;

                for (int i = 1; i < Length - 1; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
            }
            else
            {
                _root = new Node();
            }
            Length--;
        }

        public void DeleteFirstElement()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root != null)
            {
                _root = _root.Next;

            }
            else
            {
                _root = new Node();
            }
            Length--;
        }

        public void DeleteByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                DeleteFirstElement();
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next.Next;
                Length--;
            }
        }

        public int this[int index]
        {
            get
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public int GetIndexByValue(int value)
        {

            if (_root != null)
            {
                int index = 0;
                Node tmp = _root;

                while (tmp != null)
                {
                    if (tmp.Value == value)
                    {
                        return index;
                    }
                    tmp = tmp.Next;
                    index++;
                }
                return -1;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void ShangeValueByIndex(int index, int value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = _root;
            for (int i = 1; i <= index; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Value = value;
        }

        public void Reverse()
        {
            if (_root != null && _root.Next != null)
            {
                Node tmp0 = _root;
                Node tmp = _root.Next;
                while (tmp0.Next != null)
                {
                    tmp = tmp0.Next;
                    tmp0.Next = tmp0.Next.Next;
                    tmp.Next = _root;
                    _root = tmp;
                }
            }
        }

        public int GetMaxElement()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int maxValue = tmp.Value;
            for (int i = 1; i < Length; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value > maxValue)
                {
                    maxValue = tmp.Value;
                }
            }
            return maxValue;
        }

        public int GetMinElement()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int minValue = tmp.Value;
            for (int i = 1; i < Length; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value < minValue)
                {
                    minValue = tmp.Value;
                }
            }
            return minValue;
        }

        public int GetIndexOfMaxElement()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int maxValue = tmp.Value;
            int indexOfMaxElement = 0;
            for (int i = 1; i < Length; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value > maxValue)
                {
                    maxValue = tmp.Value;
                    indexOfMaxElement = i;
                }
            }
            return indexOfMaxElement;
        }

        public int GetIndexOfMinElement()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }
            Node tmp = _root;
            int minValue = tmp.Value;
            int indexIfMinElement = 0;
            for (int i = 1; i < Length; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value < minValue)
                {
                    minValue = tmp.Value;
                    indexIfMinElement = i;
                }
            }
            return indexIfMinElement;
        }

        public void DeleteFirstValue(int value)
        {
            int indexOfValue = GetIndexByValue(value);
            DeleteByIndex(indexOfValue);
        }

        public void DeleteAllValue(int value)
        {
            int indexOfValue = GetIndexByValue(value);
            while (indexOfValue != -1)
            {
                DeleteByIndex(indexOfValue);
                indexOfValue = GetIndexByValue(value);
            }
        }

        public void AddNewArrayToCurrentArrayInTheEnd(int[] newArray)
        {
            Node tmp = _root;
            for (int i = 1; i < Length; i++)
            {
                tmp = tmp.Next;
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                tmp.Next = new Node(newArray[i]);
                tmp = tmp.Next;
            }
            Length += newArray.Length;
        }

        public void AddNewArrayToCurrentArrayInTheBeginning(int[] newArray)
        {
            for (int i = newArray.Length - 1; i >= 0; i--)
            {
                Node a = new Node(newArray[i]);
                a.Next = _root;
                _root = a;
            }

            Length += newArray.Length;

        }

        public void AddNewArrayToCurrentArrayByTheIndex(int index, int[] newArray)
        {
            for (int j = 0; j < newArray.Length; j++)
            {
                AddByIndex(index + j, newArray[j]);
            }
        }

        public void DeleteNelementsFromArrayEnd(int n)
        {
            Length -= n;
            if (_root != null)
            {
                Node tmp = _root;

                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = null;
            }
        }

        public void DeleteNelementsFromArrayBeginning(int n)
        {
            Length -= n;
            if (_root != null)
            {
                Node tmp = _root;

                for (int i = 1; i < Length; i++)
                {
                    tmp = tmp.Next;
                }
                _root = tmp.Next;
            }
        }

        public void DeleteNelementsFromArrayByIndex(int index, int n)
        {
            Length -= n;
            Node tmp = _root;
            if (_root != null)
            {
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                Node tmp2 = tmp;
                for (int i = 0; i < n; i++)
                {
                    tmp2 = tmp2.Next;
                }
                tmp.Next = tmp2.Next;
            }
        }

        public void SortArrayInDescendingOrder()
        {
            if (_root != null && _root.Next != null)
            {
                Node next = _root.Next;
                Node key;
                Node current;

                while (next.Next != null)
                {
                    key = next.Next;
                    next.Next = next.Next.Next;
                    next = next.Next;
                    current = _root;
                    while (current.Next != null && current.Next.Value < key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;

                    Node prev = _root;
                    while (prev.Next != next)
                    {
                        prev = prev.Next;
                    }
                    next = prev;
                }
                if (_root.Value > _root.Next.Value)
                {
                    key = _root;
                    _root = key.Next;
                    current = _root;
                    while (current.Next != null && current.Next.Value < key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;
                }
            }
        }

        public void SortArrayInAscendingOrder()
        {
            if (_root != null && _root.Next != null)
            {
                Node next = _root.Next;
                Node key;
                Node current;
                while (next.Next != null)
                {
                    key = next.Next;
                    next.Next = next.Next.Next;
                    next = next.Next;
                    current = _root;
                    while (current.Next != null && current.Next.Value > key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;

                    Node prev = _root;
                    while (prev.Next != next)
                    {
                        prev = prev.Next;
                    }
                    next = prev;
                }
                if (_root.Value < _root.Next.Value)
                {
                    key = _root;
                    _root = key.Next;
                    current = _root;
                    while (current.Next != null && current.Next.Value > key.Value)
                    {
                        current = current.Next;
                    }
                    Node tmp = current.Next;
                    current.Next = key;
                    key.Next = tmp;
                }
            }
        }


        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
    }
}

