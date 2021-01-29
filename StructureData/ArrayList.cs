using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization.Formatters;

namespace StructureData
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;
        private int _TrueLenght
        {
            get
            {
                return _array.Length;
            }
        }

        public ArrayList()
        {
            _array = new int[9];
            Length = 0;
        }

        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * 1.33d)];
            Length = array.Length;
            Array.Copy(array, _array, array.Length);
        }

        public ArrayList(int FirstElement)
        {
            _array = new int[1] { FirstElement };
            Length = 1;
        }

        public void AddToTheEnd(int value)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }
            _array[Length] = value;
            Length++;
        }

        public void AddToTheBeginning(int value)
        {
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }
            Length++;
            for (int i = Length - 1; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = value;
        }

        public void AddValueByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (_TrueLenght <= Length)
            {
                IncreaseLenght();
            }
            Length++;
            for (int i = Length - 1; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[index] = value;
        }

        public void DeleteLastElement()
        {
            Length--;
            if (_TrueLenght > Length * 2)
            {
                DecreaseLenght();
            }
        }

        public void DeleteFirstElement()
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length--;
            if (_TrueLenght > Length * 2)
            {
                DecreaseLenght();
            }
        }

        public void DeleteByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length--;
            if (_TrueLenght > Length * 2)
            {
                DecreaseLenght();
            }
        }

        public int this[int i]
        {
            get
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[i];
            }
            set
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[i] = value;
            }
        }

        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public void ShangeValueByIndex(int index, int value)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            _array[index] = value;
        }

        public void Reverse()
        {
            int buffer;
            for (int i = 0; i < Length / 2; i++)
            {
                buffer = _array[i];
                _array[i] = _array[Length - i - 1];
                _array[Length - i - 1] = buffer;
            }
        }

        public int GetMaxElement()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }
            int maxElement = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > maxElement)
                {
                    maxElement = _array[i];
                }
            }
            return maxElement;
        }

        public int GetMinElement()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }
            int minElement = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < minElement)
                {
                    minElement = _array[i];
                }
            }
            return minElement;
        }

        public int GetIndexOfMaxElement()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException();
            }
            int maxElement = _array[0];
            int indexOfMaxElement = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > maxElement)
                {
                    maxElement = _array[i];
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
            int minElement = _array[0];
            int indexOfMinElement = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < minElement)
                {
                    minElement = _array[i];
                    indexOfMinElement = i;
                }
            }
            return indexOfMinElement;
        }

        public void SortArrayInDescendingOrder()
        {
            int buffer;
            for (int i = 1; i < Length; i++)
            {
                buffer = _array[i];
                int j;
                for (j = i - 1; j >= 0; j--)
                {
                    if (_array[j] < buffer)
                    {
                        _array[j + 1] = _array[j];
                    }
                    else
                    {
                        break;
                    }
                }
                _array[j + 1] = buffer;
            }
        }

        public void SortArrayInAscendingOrder()
        {
            int buffer;
            for (int i = 0; i < Length; i++)
            {
                for (int j = 1; j < Length - i; j++)
                {
                    if (_array[j - 1] > _array[j])
                    {
                        buffer = _array[j - 1];
                        _array[j - 1] = _array[j];
                        _array[j] = buffer;
                    }
                }
            }
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

        public void AddNewArrayToCurrentArrayInTheEnd(ArrayList array2)
        {
            int length2 = array2.Length;
            if (_TrueLenght < Length + length2)
            {
                IncreaseLenght(_TrueLenght - Length);
            }
            for (int i = 0; i < length2; i++)
            {
                AddToTheEnd(array2[i]);
            }
        }

        public void AddNewArrayToCurrentArrayInTheBeginning(ArrayList array2)
        {
            int length2 = array2.Length;
            for (int i = length2 - 1; i >= 0; i--)
            {
                AddToTheBeginning(array2[i]);
            }
        }

        public void AddNewArrayToCurrentArrayByTheIndex(int index, ArrayList array2)
        {
            int length2 = array2.Length;
            for (int i = 0; i < length2; i++)
            {
                AddValueByIndex(index + i, array2[i]);
            }
        }

        public void DeleteNelementsFromArrayEnd(int n)
        {
            for (int i = 0; i < n; i++)
            {
                DeleteLastElement();
            }
        }

        public void DeleteNelementsFromArrayBeginning(int n)
        {
            for (int i = 0; i < n; i++)
            {
                DeleteFirstElement();
            }
        }

        public void DeleteNelementsFromArrayByIndex(int index, int n)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < n; i++)
            {
                DeleteByIndex(index);
            }
        }

        private void DecreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght > Length * 2)
            {
                newLenght = (int)(newLenght * 0.66) + 1;
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, newLenght);

            _array = newArray;
        }

        private void IncreaseLenght(int number = 1)
        {
            int newLenght = _TrueLenght;
            while (newLenght <= Length + number)
            {
                newLenght = (int)(newLenght * 1.33 + 1);
            }

            int[] newArray = new int[newLenght];
            Array.Copy(_array, newArray, _TrueLenght);

            _array = newArray;
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));

        }
    }
}

