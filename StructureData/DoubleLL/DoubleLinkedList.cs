using System;
using System.Collections.Generic;
using System.Text;

namespace StructureData.DoubleLL
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }

        private Node _root;
        private Node _tale;

        public DoubleLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp.Next.Prev = tmp;
                    tmp = tmp.Next;
                }
                _tale = tmp;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tale = null;
        }

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            Node current;

            if (index < Length / 2)
            {
                current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            else
            {
                current = _tale;
                for (int i = Length - 1; i > index; i--)
                {
                    current = current.Prev;
                }
            }
            return current;
        }

        public void AddToTheEnd(int value)
        {
            if (Length > 0)
            {
                Node tmp = _tale;
                tmp.Next = new Node(value);
                tmp.Next.Prev = tmp;
                _tale = tmp.Next;
            }
            else
            {
                _root = new Node(value);
                _tale = _root;
            }
            Length++;
        }

        public void AddToTheBeginning(int value)
        {
            if (Length > 0)
            {
                Node tmp = _root;
                tmp.Prev = new Node(value);
                tmp.Prev.Next = tmp;
                _root = tmp.Prev;
            }
            else
            {
                _root = new Node(value);
                _tale = _root;
            }
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
                return;
            }
            else if (index == Length)
            {
                AddToTheEnd(value);
                return;
            }

            Node current = GetNodeByIndex(index - 1);
            Node tmp = current.Next;
            current.Next = new Node(value);
            current.Next.Prev = current;
            current.Next.Next = tmp;
            tmp.Prev = current.Next;
            Length++;
        }

        public void DeleteLastElement()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length > 1)
            {
                _tale = _tale.Prev;
                _tale.Next = null;
            }
            else
            {
                _root = null;
                _tale = null;
            }
            Length--;
        }

        public void DeleteFirstElement()
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length > 1)
            {
                _root = _root.Next;
                _root.Prev = null;
            }
            else
            {
                _root = null;
                _tale = null;
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
                return;
            }
            if (index == Length - 1)
            {
                DeleteLastElement();
                return;
            }

            Node current = GetNodeByIndex(index);
            current.Next.Prev = current.Prev;
            current.Prev.Next = current.Next;
            current = current.Next;
            Length--;
        }

        public int this[int index]
        {
            get
            {
                return GetNodeByIndex(index).Value;
            }
            set
            {
                GetNodeByIndex(index).Value = value;
            }
        }

        public int GetIndexByValue(int value)
        {
            if (_root != null)
            {
                Node tmp = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (tmp.Value == value)
                    {
                        return i;
                    }
                    tmp = tmp.Next;
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
            GetNodeByIndex(index).Value = value;
        }

        public void Reverse()
        {
            if (_root != null && _root.Next != null)
            {
                Node current = _root;
                Node tmp;
                while (current != null)
                {
                    tmp = current.Next;
                    current.Next = current.Prev;
                    current.Prev = tmp;
                    current = current.Prev;
                }
                tmp = _root;
                _root = _tale;
                _tale = tmp;
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
            int indexIfMaxElement = 0;
            for (int i = 1; i < Length; i++)
            {
                tmp = tmp.Next;
                if (tmp.Value > maxValue)
                {
                    maxValue = tmp.Value;
                    indexIfMaxElement = i;
                }
            }
            return indexIfMaxElement;
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
            if (_root != null)
            {
                Node current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DeleteByIndex(i);
                        i--;
                    }
                    current = current.Next;
                }
            }
        }

        public void AddNewArrayToCurrentArrayInTheEnd(int[] newArray)
        {
            int length = newArray.Length;
            if (Length > 0)
            {
                Node tmp = _tale;

                for (int i = 0; i < length; i++)
                {
                    tmp.Next = new Node(newArray[i]);
                    tmp.Next.Prev = tmp;
                    tmp = tmp.Next;
                }
                _tale = tmp;
                Length += length;
            }
            else if (length > 0)
            {
                AddArrayToEmptyList(newArray);
            }
        }

        public void AddNewArrayToCurrentArrayInTheBeginning(int[] newArray)
        {
            int length = newArray.Length;
            if (Length > 0)
            {
                Node tmp = _root;

                for (int i = length - 1; i >= 0; i--)
                {
                    tmp.Prev = new Node(newArray[i]);
                    tmp.Prev.Next = tmp;
                    tmp = tmp.Prev;
                }
                _root = tmp;
                Length += length;
            }
            else if (length > 0)
            {
                AddArrayToEmptyList(newArray);
            }
        }

        public void AddNewArrayToCurrentArrayByTheIndex(int index, int[] newArray)
        {
            int length = newArray.Length;
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                for (int j = 0; j < length; j++)
                {
                    AddToTheBeginning(newArray[j]);
                }
                return;
            }
            else if (index == Length)
            {
                for (int j = 0; j < length; j++)
                {
                    AddToTheEnd(newArray[j]);
                }
                return;
            }
            else
            {
                for (int j = 0; j < newArray.Length; j++)
                {
                    AddByIndex(index + j, newArray[j]);
                }
            }
        }

        public void DeleteNelementsFromArrayEnd(int n)
        {
            if (Length - n < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Length > 1 && Length - n != 0)
            {
                _tale = GetNodeByIndex(Length - n - 1);
                _tale.Next = null;
            }
            else
            {
                _root = null;
                _tale = null;
            }
            Length -= n;
        }

        public void DeleteNelementsFromArrayBeginning(int n)
        {
            if (Length - n < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (Length > 1 && Length - n != 0)
            {
                _root = GetNodeByIndex(n);
                _root.Prev = null;
            }
            else
            {
                _root = null;
                _tale = null;
            }
            Length -= n;
        }

        public void DeleteNelementsFromArrayByIndex(int index, int n)
        {
            if (index >= Length || index + n > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == 0)
            {
                DeleteNelementsFromArrayBeginning(n);
                return;
            }
            if (index == Length - 1 || index + n == Length)
            {
                DeleteNelementsFromArrayEnd(n);
                return;
            }

            Node current = GetNodeByIndex(index);
            for (int i = 0; i < n; i++)
            {
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
                current = current.Next;
            }
            Length -= n;
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
                    key = next;
                    next = next.Next;
                    if (key.Prev != null)
                        key.Prev.Next = key.Next;
                    key.Next.Prev = key.Prev;
                    current = _root;
                    while (current.Next != null && current.Next.Value < key.Value)
                    {
                        current = current.Next;
                    }
                    key.Next = current.Next;
                    key.Prev = current;
                    if (key.Next != null)
                    {
                        key.Next.Prev = key;
                    }
                    current.Next = key;
                }
                _tale = next;
                if (_root.Value > _root.Next.Value)
                {
                    key = _root;
                    _root = key.Next;
                    _root.Prev = null;
                    current = _root;
                    while (current.Next != null && current.Next.Value < key.Value)
                    {
                        current = current.Next;
                    }
                    key.Next = current.Next;
                    key.Prev = current;
                    if (key.Next != null)
                    {
                        key.Next.Prev = key;
                    }
                    current.Next = key;
                    if (key.Next == null)
                        _tale = key;
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
                    key = next;
                    next = next.Next;
                    if (key.Prev != null)
                        key.Prev.Next = key.Next;
                    key.Next.Prev = key.Prev;
                    current = _root;
                    while (current.Next != null && current.Next.Value > key.Value)
                    {
                        current = current.Next;
                    }
                    key.Next = current.Next;
                    key.Prev = current;
                    if (key.Next != null)
                    {
                        key.Next.Prev = key;
                    }
                    current.Next = key;
                }
                _tale = next;
                if (_root.Value < _root.Next.Value)
                {
                    key = _root;
                    _root = key.Next;
                    _root.Prev = null;
                    current = _root;
                    while (current.Next != null && current.Next.Value > key.Value)
                    {
                        current = current.Next;
                    }
                    key.Next = current.Next;
                    key.Prev = current;
                    if (key.Next != null)
                    {
                        key.Next.Prev = key;
                    }
                    current.Next = key;
                    if (key.Next == null)
                        _tale = key;
                }
            }
        }

        public int GetLength()
        {
            return Length;
        }

        private void AddArrayToEmptyList(int[] mewArray)
        {
            _root = new Node(mewArray[0]);
            Node tmp = _root;
            for (int i = 1; i < mewArray.Length; i++)
            {
                tmp.Next = new Node(mewArray[i]);
                tmp.Next.Prev = tmp;
                tmp = tmp.Next;
            }
            _tale = tmp;
            Length += mewArray.Length;
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;

            if (Length != doubleLinkedList.Length)
            {
                return false;
            }
            if (Length != 0)
            {
                Node tmp1 = _root;
                Node tmp2 = doubleLinkedList._root;

                while (tmp1 != null || tmp2 != null)
                {
                    if (tmp1.Value != tmp2.Value)
                    {
                        return false;
                    }
                    tmp1 = tmp1.Next;
                    tmp2 = tmp2.Next;
                }

                tmp1 = _tale;
                tmp2 = doubleLinkedList._tale;

                while (tmp1 != null || tmp2 != null)
                {
                    if (tmp1.Value != tmp2.Value)
                    {
                        return false;
                    }
                    tmp1 = tmp1.Prev;
                    tmp2 = tmp2.Prev;
                }
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
                s += " Rev: ";
                tmp = _tale;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Prev;
                }
            }
            return s;
        }
    }
}

