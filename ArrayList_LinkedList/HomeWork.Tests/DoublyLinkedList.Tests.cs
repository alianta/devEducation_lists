using NUnit.Framework;
using System;
using System.Linq;

namespace HomeWorks.Tests
{
    [TestFixture]
    class DoublyLinkedListTests
    {

        [TestCase(new int[] { }, 5, new int[] { 5 })]
        [TestCase(new int[] { 2 }, 5, new int[] { 2, 5 })]
        [TestCase(new int[] { 2, 3, 4 }, 5, new int[] { 2, 3, 4, 5 })]
        public void AddLastTest(int[] original, int addValue, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.AddLast(addValue);
            Assert.AreEqual(expected, sList.ToArray());
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 3 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveFirstTest(int[] original, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.RemoveFirst();
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        public void GetSizeTest(int[] original, int expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            Assert.AreEqual(expected, sList.GetSize());
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, 10, new int[] { 10, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, 10, new int[] { 1, 10, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, 10, new int[] { 1, 2, 10 })]
        public void SetTest(int[] original, int index, int value, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.Set(index, value);
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, 10)]
        [TestCase(new int[] { 1, 2, 3 }, 3, 10)]
        public void SetTestException(int[] original, int index, int value)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            try
            {
                sList.Set(index, value);
            }
            catch (ArgumentException e)
            {
                return;
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void RemoveLastTest(int[] original, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.RemoveLast();
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, true)]
        [TestCase(new int[] { 1, 2, 3, 4, -5 }, -5, true)]
        [TestCase(new int[] { 1, 2, 3 }, 5, false)]
        [TestCase(new int[] { 1, 2, 3 }, 0, false)]
        public void ContainsTest(int[] original, int value, bool expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            Assert.AreEqual(expected, sList.Contains(value));
        }

        [TestCase(new int[] { 1 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5)]
        public void GetTest(int[] original, int index, int expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            Assert.AreEqual(expected, sList.Get(index));
        }

        [TestCase(new int[] { 1 }, -1)]
        [TestCase(new int[] { 1, 2 }, 2)]

        public void GetTestExceptopn(int[] original, int index)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            try
            {
                sList.Get(index);
            }
            catch (ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4, -5 }, -5, 4)]
        [TestCase(new int[] { 1, 2, 3 }, 5, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 0, -1)]
        public void IndexOfTest(int[] original, int value, int expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            Assert.AreEqual(expected, sList.IndexOf(value));
        }

        [TestCase(new int[] { 1, 2, 3 }, 1)]
        [TestCase(new int[] { 0 }, 0)]
        public void GetFirstTest(int[] original, int expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            Assert.AreEqual(expected, sList.GetFirst());
        }

        [TestCase(new int[] { })]
        public void GetFirstTestExeption(int[] original)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            try
            {
                sList.GetFirst();
            }
            catch (NullReferenceException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        public void GetLastTest(int[] original, int expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            Assert.AreEqual(expected, sList.GetLast());
        }

        [TestCase(new int[] { })]
        public void GetLastTestException(int[] original)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            try
            {
                sList.GetLast();
            }
            catch (NullReferenceException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1 }, 2, new int[] { 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { }, 2, new int[] { 2 })]
        public void AddFirstTest(int[] original, int value, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.AddFirst(value);
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        public void RemoveAtTest(int[] original, int index, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.RemoveAt(index);
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2 }, -1)]
        [TestCase(new int[] { 1 }, 1)]
        public void RemoveAtTestExceptopn(int[] original, int index)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            try
            {
                sList.RemoveAt(index);
            }
            catch (ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1 }, new int[] { 1 }, new int[] { 1, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1 }, new int[] { }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        public void AddLastArrayTest(int[] original, int[] values, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.AddLast(values);
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 1, 4, 5 }, 1, new int[] { 2, 4, 5 })]
        [TestCase(new int[] { 1, 2, 2, 2, 5 }, 2, new int[] { 1, 5 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, 1, new int[] { })]
        public void RemoveAllTest(int[] original, int value, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.RemoveAll(value);
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1 }, new int[] { 1, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 }, new int[] { 2, 3, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 2, 3 }, new int[] { 2, 3 })]
        public void AddFirstArrayTest(int[] original, int[] values, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.AddFirst(values);
            Assert.AreEqual(expected, sList.ToArray());
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReverseTest(int[] original, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.Reverse();
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2 }, 1, 5, new int[] { 1, 5, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 5, new int[] { 1, 2, 3, 5, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, 5, new int[] { 5, 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, 5, new int[] { 1, 2, 5, 3 })]
        public void AddAtTest(int[] original, int index, int addValue, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.AddAt(index, addValue);
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, 5)]
        [TestCase(new int[] { 1, 2, 3 }, 3, 5)]
        [TestCase(new int[] { }, 0, 5)]
        public void AddAtTestExceptopn(int[] original, int index, int addValue)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            try
            {
                sList.AddAt(index, addValue);
            }
            catch (ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1 }, 0, new int[] { 0 }, new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4 }, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4 }, new int[] { 1, 2, 4, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 6, 7, 8 }, new int[] { 1, 2, 3, 6, 7, 8, 4, 5 })]

        public void AddAtArrayTest(int[] original, int index, int[] values, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.AddAt(index, values);
            Assert.AreEqual(expected, sList.ToArray());
        }

        [TestCase(new int[] { }, 0, new int[] { 1 })]
        [TestCase(new int[] { 1 }, -1, new int[] { 2 })]
        [TestCase(new int[] { 1 }, 1, new int[] { 0 })]
        public void AddAtArrayTestExceptopn(int[] original, int index, int[] values)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            try
            {
                sList.AddAt(index, values);
            }
            catch (ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2}, new int[] { 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ToArrayReverseTest(int[] original, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            Assert.AreEqual(expected, sList.ToArrayReverse());
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Reverse2Test(int[] original, int[] expected)
        {
            DoublyLinkedList sList = new DoublyLinkedList(original);
            sList.Reverse();
            Assert.AreEqual(expected, sList.ToArrayReverse());
        }
    }
}
