using NUnit.Framework;
using StructureData.DoubleLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace StructureDataTest
{
    public class DoubleLinkedListTests
    {
        [TestCase(new int[] { }, 5, new int[] { 5 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 5, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void AddToTheEndTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddToTheEnd(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 5, new int[] { 5 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 5, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, new int[] { 6, 1, 2, 3, 4, 5 })]
        public void AddToTheBeginningTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddToTheBeginning(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 5, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 6)]
        public void AddValueByIndexNegativeTest(int[] array, int index, int value)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.AddByIndex(index, value));
        }

        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void DeleteLastElementTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteLastElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        public void DeleteFirstElementTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteFirstElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
        public void DeleteByIndexTest(int[] array, int index, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1)]
        public void DeleteByIndexNegativeTest(int[] array, int index)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index));
        }

        public void thisTest()
        {
            DoubleLinkedList LinkedListik = new DoubleLinkedList();

            Assert.Throws<IndexOutOfRangeException>(() => LinkedListik[5] = 6);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, -1)]
        public void GetIndexByValueTest(int[] array, int value, int expIndex)
        {
            int expected = expIndex;
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual = actualArray.GetIndexByValue(value);


            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 5, new int[] { 5, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, -8, new int[] { 1, 2, 3, -8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 0, new int[] { 1, 2, 0, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 100500, new int[] { 1, 2, 3, 4, 100500 })]
        public void ShangeValueByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.ShangeValueByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4, 100)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 4)]
        public void ShangeValueByIndexNegativeTest(int[] array, int index, int value)
        {
            DoubleLinkedList actual = new DoubleLinkedList(array);

            Assert.Throws<IndexOutOfRangeException>(() => actual.ShangeValueByIndex(index, value));
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        public void ReverseTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 30, 5, 4 }, 30)]
        [TestCase(new int[] { -10, -2, -3, -4, -5 }, -2)]
        public void GetMaxElementTest(int[] array, int expMax)
        {
            int expected = expMax;
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual = actualArray.GetMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxElementNegativeTest(int[] array)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actualArray.GetMaxElement());
        }

        [TestCase(new int[] { 1, 2, 0, 4 }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 30, -5, 4 }, -5)]
        [TestCase(new int[] { -10, -2, -3, -4, -5 }, -10)]
        public void GetMinElementTest(int[] array, int expMin)
        {
            int expected = expMin;
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual = actualArray.GetMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinElementNegativeTest(int[] array)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actualArray.GetMinElement());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 30, 5, 4 }, 2)]
        [TestCase(new int[] { -10, -2, -3, -4, -5 }, 1)]
        public void GetIndexOfMaxElementTest(int[] array, int expMax)
        {
            int expected = expMax;
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual = actualArray.GetIndexOfMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMaxElementNegativeTest(int[] array)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actualArray.GetIndexOfMaxElement());
        }

        [TestCase(new int[] { 1, 2, 0, 4 }, 2)]
        [TestCase(new int[] { 1 }, 0)]
        [TestCase(new int[] { 1, 2, 30, -5, 4 }, 3)]
        [TestCase(new int[] { -10, -2, -3, -4, -5 }, 0)]
        public void GetIndexOfMinElementTest(int[] array, int expMin)
        {
            int expected = expMin;
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            int actual = actualArray.GetIndexOfMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetIndexOfMinElementNegativeTest(int[] array)
        {
            DoubleLinkedList actualArray = new DoubleLinkedList(array);
            Assert.Throws<InvalidOperationException>(() => actualArray.GetIndexOfMinElement());
        }


        [TestCase(new int[] { 1, 22, -3, 14 }, new int[] { -3, 1, 14, 22 })]
        [TestCase(new int[] { 11, -3, 3, -4 }, new int[] { -4, -3, 3, 11 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortArrayInDescendingOrderTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.SortArrayInDescendingOrder();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 22, -3, 14 }, new int[] { 22, 14, 1, -3 })]
        [TestCase(new int[] { 11, -3, 3, -4 }, new int[] { 11, 3, -3, -4 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void SortArrayInAscendingOrderTest(int[] array, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.SortArrayInAscendingOrder();

            Assert.AreEqual(expected, actual);
        }



        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 3, 3, 4 }, 3, new int[] { 1, 3, 4 })]
        public void DeleteFirstValueTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteFirstValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 2, 3, 3, 4 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 1, 1, 3, 3, 1 }, 1, new int[] { 3, 3 })]
        [TestCase(new int[] { 1, 3, 3, 4 }, 3, new int[] { 1, 4 })]
        public void DeleteAllValueTest(int[] array, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteAllValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4 }, new int[] { 1, 2, 3, 4, 1, 2, 4 })]
        [TestCase(new int[] { 1, 2, 3, 3, 4 }, new int[] { 1, 2, 4 }, new int[] { 1, 2, 3, 3, 4, 1, 2, 4 })]
        [TestCase(new int[] { 1, 1, 3, 3, 1 }, new int[] { 3, 3 }, new int[] { 1, 1, 3, 3, 1, 3, 3 })]
        [TestCase(new int[] { 1, 3, 3, 4 }, new int[] { 1, 4 }, new int[] { 1, 3, 3, 4, 1, 4 })]
        public void AddNewArrayToCurrentArrayInTheEndTest(int[] array1, int[] array2, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array1);

            actual.AddNewArrayToCurrentArrayInTheEnd(array2);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 4 }, new int[] { 1, 2, 4, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 3, 4 }, new int[] { 1, 2, 4 }, new int[] { 1, 2, 4, 1, 2, 3, 3, 4 })]
        [TestCase(new int[] { 1, 1, 3, 3, 1 }, new int[] { 3, 3 }, new int[] { 3, 3, 1, 1, 3, 3, 1 })]
        [TestCase(new int[] { 1, 3, 3, 4 }, new int[] { 1, 4 }, new int[] { 1, 4, 1, 3, 3, 4 })]
        public void AddNewArrayToCurrentArrayInTheBeginningTest(int[] array1, int[] array2, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array1);

            actual.AddNewArrayToCurrentArrayInTheBeginning(array2);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2, 4 }, new int[] { 1, 2, 1, 2, 4, 3, 4 })]
        public void AddNewArrayToCurrentArrayByTheIndexTest(int[] array1, int index, int[] array2, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array1);

            actual.AddNewArrayToCurrentArrayByTheIndex(index, array2);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2 })]
        public void DeleteNelementsFromArrayEndTest(int[] array, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteNelementsFromArrayEnd(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 3, 4 })]
        public void DeleteNelementsFromArrayBeginningTest(int[] array, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteNelementsFromArrayBeginning(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 2, new int[] { 1, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 1, new int[] { 1, 3, 4 })]
        public void DeleteNelementsFromArrayByIndexTest(int[] array, int index, int n, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.DeleteNelementsFromArrayByIndex(index, n);

            Assert.AreEqual(expected, actual);
        }

        //[TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5 }, -1)]
        //public void DeleteNelementsFromArrayByIndexNegativeTest(int[] array, int index)
        //{
        //    LinkedList actual = new LinkedList(array);

        //    Assert.Throws<IndexOutOfRangeException>(() => actual.DeleteByIndex(index));
        //}
    }
}
